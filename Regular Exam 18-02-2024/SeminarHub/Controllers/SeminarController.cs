using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models;
using System.Globalization;
using System.Security.Claims;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext data;

        public SeminarController(SeminarHubDbContext context)
        {
            this.data = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var seminars = await data.Seminars
                .Select(s => new SeminarViewModel(
                     s.Id,
                     s.Topic,
                     s.Lecturer,
                     s.Category.Name,
                     s.DateAndTime,
                     s.Organizer.UserName
                ))
                .ToListAsync();

            return View(seminars);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var seminar = await data.Seminars
                .Where(e => e.Id == id)
                .Include(e => e.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (!seminar.SeminarsParticipants.Any(sp => sp.ParticipantId == userId))
            {
                seminar.SeminarsParticipants.Add(new SeminarParticipant()
                {
                    SeminarId = seminar.Id,
                    ParticipantId = userId
                });

                await data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Joined));
        }


        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var model = await data.SeminarsParticipants
                .Where(ep => ep.ParticipantId == GetUserId())
                .AsNoTracking()
                .Select(ep => new SeminarInfoViewModel(
                    ep.SeminarId,
                    ep.Seminar.Topic,
                    ep.Seminar.Lecturer,
                    ep.Seminar.DateAndTime,
                    ep.Seminar.Organizer.UserName
                    ))
                .ToArrayAsync();


            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Leave(int id)
        {
            var seminar = await data.Seminars
                .Where(e => e.Id == id)
                .Include(e => e.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var ep = seminar.SeminarsParticipants
                .FirstOrDefault(ep => ep.ParticipantId == userId);

            if (ep == null)
            {
                return BadRequest();
            }

            seminar.SeminarsParticipants.Remove(ep);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SeminarFormViewModel();
            model.Categories = await GetCategoties();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarFormViewModel model)
        {
            DateTime dateAndTime = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.DateAndTime,
                DataConstants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateAndTime))
            {
                ModelState
                    .AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be: {DataConstants.DateTimeFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategoties();

                return View(model);
            }

            var seminar = new Seminar()
            {
                Topic = model.Topic,
                Lecturer = model.Lecturer,
                Details = model.Details,
                OrganizerId = GetUserId(),
                CategoryId = model.CategoryId,
                DateAndTime = dateAndTime,
                Duration = model.Duration,
            };

            await data.Seminars.AddAsync(seminar);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var seminar = await data.Seminars
                .FindAsync(id);

            if (seminar == null)
            {
                return BadRequest();
            }

            if (seminar.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new SeminarFormViewModel()
            {
                Topic = seminar.Topic,
                Lecturer = seminar.Lecturer,
                Details = seminar.Details,
                Duration = seminar.Duration,
                DateAndTime = seminar.DateAndTime.ToString(DataConstants.DateTimeFormat),
                CategoryId = seminar.CategoryId
            };

            model.Categories = await GetCategoties();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SeminarFormViewModel model, int id)
        {
            var seminar = await data.Seminars
                .FindAsync(id);

            if (seminar == null)
            {
                return BadRequest();
            }

            if (seminar.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            DateTime dateAndTime = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.DateAndTime,
                DataConstants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateAndTime))
            {
                ModelState
                    .AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be: {DataConstants.DateTimeFormat}");
            }


            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategoties();

                return View(model);
            }

            seminar.Topic = model.Topic;
            seminar.Lecturer = model.Lecturer;
            seminar.Details = model.Details;
            seminar.DateAndTime = dateAndTime;
            seminar.Duration = model.Duration;
            seminar.CategoryId = model.CategoryId;

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await data.Seminars
                .Where(s => s.Id == id)
                .AsNoTracking()
                .Select(s => new SeminarDetailsViewModel()
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    Details = s.Details,
                    DateAndTime = s.DateAndTime.ToString(DataConstants.DateTimeFormat),
                    Duration = s.Duration,
                    Organizer = s.Organizer.UserName,
                    Category = s.Category.Name
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var seminar = await data.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar == null || seminar.OrganizerId != GetUserId())
            {
                return BadRequest();
            }

            var model = new DeletViewModel()
            {
                Id = id,
                Topic = seminar.Topic,
                DateAndTime = seminar.DateAndTime.ToString(DataConstants.DateTimeFormat),
            };

            return View(model);
        }

            [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seminar = await data.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar == null || seminar.OrganizerId != GetUserId())
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var seminarsParticipants = await data.SeminarsParticipants
                .Where(sp => sp.Seminar == seminar)
                .ToListAsync();

            if (seminarsParticipants != null)
            {
                data.RemoveRange(seminarsParticipants);
            }

            data.Remove(seminar);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private async Task<IEnumerable<CategoryViewModel>> GetCategoties()
        {
            return await data.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

        }

    }
}

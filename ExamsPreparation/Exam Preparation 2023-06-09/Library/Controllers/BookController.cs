using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        public LibraryDbContext data;

        public BookController(LibraryDbContext context)
        {
            data = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var books = await data.Books
                .Select(e => new AllBookViewModel()
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    Author = e.Author,
                    Rating = e.Rating,
                    Category = e.Category.Name
                })
                .ToListAsync();

            return View(books);
        }
        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await GetBookByIdAsync(id);
            var userId = GetUserId();

            if (book != null && userId != string.Empty)
            {
                bool alreadyAdded = await data.IdentityUserBooks
                 .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

                if (alreadyAdded == false)
                {
                    var userBook = new IdentityUserBook
                    {
                        CollectorId = userId,
                        BookId = book.Id
                    };

                    await data.IdentityUserBooks.AddAsync(userBook);
                    await data.SaveChangesAsync();
                }

            }
            return RedirectToAction(nameof(All));
        }
        

        //not completed

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await GetBookByIdAsync(id);
            if (book !=null )
            {
            }
                return RedirectToAction(nameof(All));
        }

        private async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await data.Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId
                }).FirstOrDefaultAsync();
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

    }
}

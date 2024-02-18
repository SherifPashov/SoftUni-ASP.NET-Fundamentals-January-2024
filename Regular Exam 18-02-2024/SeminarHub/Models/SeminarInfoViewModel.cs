using SeminarHub.Data.Models;

namespace SeminarHub.Models
{
    public class SeminarInfoViewModel
    {

        public SeminarInfoViewModel(int id, string topic, string lecturer
           ,
           DateTime dateAndTime,
           string organizer

           )
        {
            Id = id;
            Topic = topic;
            Lecturer = lecturer;
            Organizer = organizer;
            DateAndTime = dateAndTime.ToString(DataConstants.DateTimeFormat);
        }

        public int Id { get; set; }

        public string Topic { get; set; }

        public string Lecturer { get; set; }

        public string DateAndTime { get; set; }
        public string Organizer { get; set; }
    }
}

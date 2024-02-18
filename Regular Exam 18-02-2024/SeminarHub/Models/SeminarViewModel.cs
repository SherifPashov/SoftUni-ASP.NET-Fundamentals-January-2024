using SeminarHub.Data.Models;

namespace SeminarHub.Models
{
    public class SeminarViewModel
    {
        public SeminarViewModel(int id, string topic, string lecturer
            , string category,
            DateTime dateAndTime,
            string organizer

            )
        {
            Id = id;
            Topic = topic;
            Lecturer = lecturer;
            Category = category;
            Organizer = organizer;
            DateAndTime = dateAndTime.ToString(DataConstants.DateTimeFormat);
        }

        public int Id { get; set; }

        public string Topic { get; set; } 

        public string Lecturer { get; set; }

        public string Category { get; set; } 
        public string DateAndTime { get; set; }
        public string Organizer { get; set; } 


    }
}

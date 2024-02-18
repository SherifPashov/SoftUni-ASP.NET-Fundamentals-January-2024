namespace SeminarHub.Data.Models
{
    public static class DataConstants
    {
        //Seminar Topic
        public const int SeminarTopicMinLength = 3;
        public const int SeminarTopicMaxLength = 100;

        //Seminar Lecturer
        public const int SeminarLecturerMinLength = 5;
        public const int SeminarLecturerMaxLength = 60;

        //Seminar Details 
        public const int SeminarDetailsMinLength = 10;
        public const int SeminarDetailsMaxLength = 500;

        //Seminar Duration  
        public const int SeminarDurationMinLength = 30;
        public const int SeminarDurationMaxLength = 180;


        //Category Name  
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 50;

        //Date Time Format
        public static string DateTimeFormat = "dd/MM/yyyy HH:mm";


        //Error Messages
        public const string RequireErrorMessage = "The field {0} is required";
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long";
    }
}


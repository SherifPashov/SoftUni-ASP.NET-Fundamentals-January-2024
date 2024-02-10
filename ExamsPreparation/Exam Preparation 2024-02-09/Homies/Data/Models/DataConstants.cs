namespace Homies.Data.Models
{
    public static class DataConstants
    {
       

        //Event Name
        public const int EventNameMaxLength = 20;
        public const int EventNameMinLength = 5;

        //Event Discription
        public const int EventDescriptionMinLength = 15;
        public const int EventDescriptionMaxLength = 150;

        //Type Name
        public const int TypeNameMinLength = 5;
        public const int TypeNameMaxLength = 15;

        //DateFormat
        public const string DateFormat = "yyyy-MM-dd H:mm";

        //Error message
        public const string RequireErrorMessage = "The field {0} is required";
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long";
        public const string DateTimeFormatInvalid = "Invalid date! Format must be: yyyy-MM-dd H:mm";
    }
}

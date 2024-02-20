namespace Library.Data.Models
{
    public static class DataConstants
    {
        //Book Title
        public const int BookTitleMinLength = 10;
        public const int BookTitleMaxLength = 50;

        //Book Author
        public const int BookAuthorMinLength = 5;
        public const int BookAuthorMaxLength = 50;

        // Booc Description
        public const int BookDescriptionMinLength = 5;
        public const int BookDescriptionMaxLength = 5000;

        //Book Rating
        public const int BookRatingMinRange = 0;
        public const int BookRatingMaxRange = 10;

        //Category Name
        public const int CategoryNameMinLength = 5;
        public const int CategoryNameMaxLength = 50;
    }
}

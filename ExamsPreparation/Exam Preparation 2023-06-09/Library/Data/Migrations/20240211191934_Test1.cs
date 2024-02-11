using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://img.freepik.com/premium-photo/opened-book-with-flying-pages-butterflies-dark-backgroundgenerative-ai_391052-12859.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://img.freepik.com/free-psd/book-cover-mock-up-arrangement_23-2148622888.jpg?w=826&t=st=1666106877~exp=1666107477~hmac=5dea3e5634804683bccfebeffdbde98371db37bc2d1a208f074292c862775e1b");
        }
    }
}

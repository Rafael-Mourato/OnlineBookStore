using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBookStore.Migrations
{
    /// <inheritdoc />
    public partial class Update6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Book_bookId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "bookId",
                table: "Order",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_bookId",
                table: "Order",
                newName: "IX_Order_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Book_BookId",
                table: "Order",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Book_BookId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Order",
                newName: "bookId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_BookId",
                table: "Order",
                newName: "IX_Order_bookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Book_bookId",
                table: "Order",
                column: "bookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

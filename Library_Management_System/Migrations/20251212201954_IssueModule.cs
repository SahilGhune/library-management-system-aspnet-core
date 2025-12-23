using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class IssueModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssuedRecords_Books_BookId",
                table: "IssuedRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_IssuedRecords_Member_MemberId",
                table: "IssuedRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IssuedRecords",
                table: "IssuedRecords");

            migrationBuilder.RenameTable(
                name: "IssuedRecords",
                newName: "IssuedRecord");

            migrationBuilder.RenameIndex(
                name: "IX_IssuedRecords_MemberId",
                table: "IssuedRecord",
                newName: "IX_IssuedRecord_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_IssuedRecords_BookId",
                table: "IssuedRecord",
                newName: "IX_IssuedRecord_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IssuedRecord",
                table: "IssuedRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IssuedRecord_Books_BookId",
                table: "IssuedRecord",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IssuedRecord_Member_MemberId",
                table: "IssuedRecord",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssuedRecord_Books_BookId",
                table: "IssuedRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_IssuedRecord_Member_MemberId",
                table: "IssuedRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IssuedRecord",
                table: "IssuedRecord");

            migrationBuilder.RenameTable(
                name: "IssuedRecord",
                newName: "IssuedRecords");

            migrationBuilder.RenameIndex(
                name: "IX_IssuedRecord_MemberId",
                table: "IssuedRecords",
                newName: "IX_IssuedRecords_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_IssuedRecord_BookId",
                table: "IssuedRecords",
                newName: "IX_IssuedRecords_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IssuedRecords",
                table: "IssuedRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IssuedRecords_Books_BookId",
                table: "IssuedRecords",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IssuedRecords_Member_MemberId",
                table: "IssuedRecords",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

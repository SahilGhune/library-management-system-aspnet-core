using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddIssueRecordTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "IssueRecord");

            migrationBuilder.RenameIndex(
                name: "IX_IssuedRecord_MemberId",
                table: "IssueRecord",
                newName: "IX_IssueRecord_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_IssuedRecord_BookId",
                table: "IssueRecord",
                newName: "IX_IssueRecord_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IssueRecord",
                table: "IssueRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueRecord_Books_BookId",
                table: "IssueRecord",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueRecord_Member_MemberId",
                table: "IssueRecord",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueRecord_Books_BookId",
                table: "IssueRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueRecord_Member_MemberId",
                table: "IssueRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IssueRecord",
                table: "IssueRecord");

            migrationBuilder.RenameTable(
                name: "IssueRecord",
                newName: "IssuedRecord");

            migrationBuilder.RenameIndex(
                name: "IX_IssueRecord_MemberId",
                table: "IssuedRecord",
                newName: "IX_IssuedRecord_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_IssueRecord_BookId",
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
    }
}

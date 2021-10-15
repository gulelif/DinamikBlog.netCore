using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogID",
                table: "Commnets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Commnets_BlogID",
                table: "Commnets",
                column: "BlogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commnets_Blogs_BlogID",
                table: "Commnets",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commnets_Blogs_BlogID",
                table: "Commnets");

            migrationBuilder.DropIndex(
                name: "IX_Commnets_BlogID",
                table: "Commnets");

            migrationBuilder.DropColumn(
                name: "BlogID",
                table: "Commnets");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersCompanies.DAL.Migrations
{
    public partial class dbuserlogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserJobs_Jobs_JobId",
                table: "UserJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserJobs_Users_UserId",
                table: "UserJobs");

            migrationBuilder.AddForeignKey(
                name: "FK_UserJobs_Jobs_JobId",
                table: "UserJobs",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserJobs_Users_UserId",
                table: "UserJobs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserJobs_Jobs_JobId",
                table: "UserJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserJobs_Users_UserId",
                table: "UserJobs");

            migrationBuilder.AddForeignKey(
                name: "FK_UserJobs_Jobs_JobId",
                table: "UserJobs",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserJobs_Users_UserId",
                table: "UserJobs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning_IT.Migrations
{
    public partial class UpdateBadges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBadge_Badges_BadgeId",
                table: "UserBadge");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBadge_Users_UserID",
                table: "UserBadge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBadge",
                table: "UserBadge");

            migrationBuilder.RenameTable(
                name: "UserBadge",
                newName: "UserBadges");

            migrationBuilder.RenameIndex(
                name: "IX_UserBadge_UserID",
                table: "UserBadges",
                newName: "IX_UserBadges_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBadges",
                table: "UserBadges",
                columns: new[] { "BadgeId", "UserID" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadges_Badges_BadgeId",
                table: "UserBadges",
                column: "BadgeId",
                principalTable: "Badges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadges_Users_UserID",
                table: "UserBadges",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBadges_Badges_BadgeId",
                table: "UserBadges");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBadges_Users_UserID",
                table: "UserBadges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBadges",
                table: "UserBadges");

            migrationBuilder.RenameTable(
                name: "UserBadges",
                newName: "UserBadge");

            migrationBuilder.RenameIndex(
                name: "IX_UserBadges_UserID",
                table: "UserBadge",
                newName: "IX_UserBadge_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBadge",
                table: "UserBadge",
                columns: new[] { "BadgeId", "UserID" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadge_Badges_BadgeId",
                table: "UserBadge",
                column: "BadgeId",
                principalTable: "Badges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadge_Users_UserID",
                table: "UserBadge",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

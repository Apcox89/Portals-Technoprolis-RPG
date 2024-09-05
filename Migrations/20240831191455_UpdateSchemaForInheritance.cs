using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portals_Technoprolis_RPG.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemaForInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Character_PlayerId",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_PlayerId",
                table: "Skills",
                newName: "IX_Skills_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "SkillID");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Character_PlayerId",
                table: "Skills",
                column: "PlayerId",
                principalTable: "Character",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Character_PlayerId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_PlayerId",
                table: "Skill",
                newName: "IX_Skill_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "SkillID");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Character_PlayerId",
                table: "Skill",
                column: "PlayerId",
                principalTable: "Character",
                principalColumn: "Id");
        }
    }
}

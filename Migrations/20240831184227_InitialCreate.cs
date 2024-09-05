using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portals_Technoprolis_RPG.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentHealth = table.Column<int>(type: "int", nullable: false),
                    MaxHealth = table.Column<int>(type: "int", nullable: false),
                    IsDead = table.Column<bool>(type: "bit", nullable: false),
                    CharacterType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    NpcID = table.Column<int>(type: "int", nullable: true),
                    NpcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxDamage = table.Column<int>(type: "int", nullable: true),
                    AwardXP = table.Column<int>(type: "int", nullable: true),
                    AwardLoot = table.Column<int>(type: "int", nullable: true),
                    PlayerID = table.Column<int>(type: "int", nullable: true),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loot = table.Column<int>(type: "int", nullable: true),
                    Xp = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillID);
                    table.ForeignKey(
                        name: "FK_Skill_Character_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Character",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skill_PlayerId",
                table: "Skill",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Character");
        }
    }
}

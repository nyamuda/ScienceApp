using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScienceApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Curriculum_CurriculumId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_CurriculumId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "CurriculumId",
                table: "Subject");

            migrationBuilder.CreateTable(
                name: "CurriculumSubject",
                columns: table => new
                {
                    CurriculumsId = table.Column<int>(type: "int", nullable: false),
                    SubjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumSubject", x => new { x.CurriculumsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_CurriculumSubject_Curriculum_CurriculumsId",
                        column: x => x.CurriculumsId,
                        principalTable: "Curriculum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurriculumSubject_Subject_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumSubject_SubjectsId",
                table: "CurriculumSubject",
                column: "SubjectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurriculumSubject");

            migrationBuilder.AddColumn<int>(
                name: "CurriculumId",
                table: "Subject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CurriculumId",
                table: "Subject",
                column: "CurriculumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Curriculum_CurriculumId",
                table: "Subject",
                column: "CurriculumId",
                principalTable: "Curriculum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

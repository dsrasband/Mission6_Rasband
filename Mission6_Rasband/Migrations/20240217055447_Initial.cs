using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission6_Rasband.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Director = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<string>(type: "TEXT", nullable: false),
                    Edited = table.Column<bool>(type: "INTEGER"),
                    LentTo = table.Column<string>(type: "TEXT"),
                    Notes = table.Column<string>(type: "TEXT")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.FilmID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    public partial class addedNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Campsite",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HolidayDestinationID",
                table: "Campsite",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Campsite",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Rate",
                table: "Campsite",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "lat",
                table: "Campsite",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lng",
                table: "Campsite",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CampsiteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Campsite_CampsiteID",
                        column: x => x.CampsiteID,
                        principalTable: "Campsite",
                        principalColumn: "VacationSpotID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HolidayDestination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoUri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayDestination", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampsiteVacationSpotID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_Campsite_CampsiteVacationSpotID",
                        column: x => x.CampsiteVacationSpotID,
                        principalTable: "Campsite",
                        principalColumn: "VacationSpotID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CampsiteID",
                table: "Comment",
                column: "CampsiteID");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CampsiteVacationSpotID",
                table: "Link",
                column: "CampsiteVacationSpotID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "HolidayDestination");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Campsite");

            migrationBuilder.DropColumn(
                name: "HolidayDestinationID",
                table: "Campsite");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Campsite");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Campsite");

            migrationBuilder.DropColumn(
                name: "lat",
                table: "Campsite");

            migrationBuilder.DropColumn(
                name: "lng",
                table: "Campsite");
        }
    }
}

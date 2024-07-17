using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel_Agency_Project.Migrations
{
    /// <inheritdoc />
    public partial class EditTourModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Tours",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "GroupNumber",
                table: "Tours",
                newName: "InfantTickets");

            migrationBuilder.RenameColumn(
                name: "Fees",
                table: "Tours",
                newName: "ChildrenTickets");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Tours",
                newName: "AdultsTickets");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Tours",
                newName: "Meals");

            migrationBuilder.AddColumn<string>(
                name: "EndDate",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HotelName",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "HotelName",
                table: "Tours");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Tours",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "Meals",
                table: "Tours",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "InfantTickets",
                table: "Tours",
                newName: "GroupNumber");

            migrationBuilder.RenameColumn(
                name: "ChildrenTickets",
                table: "Tours",
                newName: "Fees");

            migrationBuilder.RenameColumn(
                name: "AdultsTickets",
                table: "Tours",
                newName: "Duration");
        }
    }
}

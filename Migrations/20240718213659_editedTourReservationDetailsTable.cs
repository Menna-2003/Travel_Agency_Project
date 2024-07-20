using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel_Agency_Project.Migrations
{
    /// <inheritdoc />
    public partial class editedTourReservationDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "TourReservationDetails");

            migrationBuilder.DropColumn(
                name: "CardSecurityCode",
                table: "TourReservationDetails");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "TourReservationDetails");

            migrationBuilder.DropColumn(
                name: "PayPalPassword",
                table: "TourReservationDetails");

            migrationBuilder.DropColumn(
                name: "PayPalUsername",
                table: "TourReservationDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardNumber",
                table: "TourReservationDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CardSecurityCode",
                table: "TourReservationDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpireDate",
                table: "TourReservationDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PayPalPassword",
                table: "TourReservationDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PayPalUsername",
                table: "TourReservationDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

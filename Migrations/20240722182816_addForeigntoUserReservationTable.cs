using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel_Agency_Project.Migrations
{
    /// <inheritdoc />
    public partial class addForeigntoUserReservationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserReservationDetails_TourID",
                table: "UserReservationDetails",
                column: "TourID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReservationDetails_Tours_TourID",
                table: "UserReservationDetails",
                column: "TourID",
                principalTable: "Tours",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReservationDetails_Tours_TourID",
                table: "UserReservationDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserReservationDetails_TourID",
                table: "UserReservationDetails");
        }
    }
}

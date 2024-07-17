using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel_Agency_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddImageColumnToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Tours",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Tours");
        }
    }
}

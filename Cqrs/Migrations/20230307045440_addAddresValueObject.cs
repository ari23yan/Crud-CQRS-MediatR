using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cqrs.Migrations
{
    /// <inheritdoc />
    public partial class addAddresValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Addres_City",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Addres_State",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Addres_Street",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Addres_ZipCode",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addres_City",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Addres_State",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Addres_Street",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Addres_ZipCode",
                table: "Persons");
        }
    }
}

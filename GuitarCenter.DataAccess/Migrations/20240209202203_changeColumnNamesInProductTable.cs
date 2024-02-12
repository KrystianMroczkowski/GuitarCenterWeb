using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarCenterWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeColumnNamesInProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price100",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price50",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Gibson Explorer");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "KH Ouija");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price100",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price50",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Price100", "Price50" },
                values: new object[] { "Fortune of Time", 80.0, 85.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Price100", "Price50" },
                values: new object[] { "Dark Skies", 20.0, 25.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price100", "Price50" },
                values: new object[] { 35.0, 40.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Price100", "Price50" },
                values: new object[] { 55.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Price100", "Price50" },
                values: new object[] { 20.0, 25.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Price100", "Price50" },
                values: new object[] { 20.0, 22.0 });
        }
    }
}

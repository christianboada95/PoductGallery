using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductGallery.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_Id",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("1d643885-fe4b-4a90-8fae-a8218b80b915"), new DateTime(2023, 1, 28, 15, 25, 4, 780, DateTimeKind.Local).AddTicks(8980), "Accesorios", null },
                    { new Guid("47ae148e-3623-46ba-a13e-995937216853"), new DateTime(2023, 1, 28, 15, 25, 4, 780, DateTimeKind.Local).AddTicks(9010), "Juegos", null },
                    { new Guid("5cb3774e-88e7-4d69-aac2-38e294f207ec"), new DateTime(2023, 1, 28, 15, 25, 4, 780, DateTimeKind.Local).AddTicks(9010), "Tecnología", null },
                    { new Guid("a1ff8e63-2c4d-46b4-a684-595d389be365"), new DateTime(2023, 1, 28, 15, 25, 4, 780, DateTimeKind.Local).AddTicks(8990), "Libros", null },
                    { new Guid("a422b632-e3da-480f-b237-c551b14f84c0"), new DateTime(2023, 1, 28, 15, 25, 4, 780, DateTimeKind.Local).AddTicks(8930), "Computación", null },
                    { new Guid("a4745a21-cd2a-4b95-bc0b-a7ec9b12434f"), new DateTime(2023, 1, 28, 15, 25, 4, 780, DateTimeKind.Local).AddTicks(9000), "Cocina", null },
                    { new Guid("b652bc42-9e7c-47dd-8331-73cfc3fee183"), new DateTime(2023, 1, 28, 15, 25, 4, 780, DateTimeKind.Local).AddTicks(8970), "Ropa", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Image", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("1b01ecb1-0e9d-4ddc-b09a-a0e1f1685c74"), new Guid("47ae148e-3623-46ba-a13e-995937216853"), new DateTime(2023, 1, 28, 15, 25, 4, 781, DateTimeKind.Local).AddTicks(30), null, null, "Mario Kart", null },
                    { new Guid("1d4ce219-4369-4eee-a049-2e4fc02561d8"), new Guid("a1ff8e63-2c4d-46b4-a684-595d389be365"), new DateTime(2023, 1, 28, 15, 25, 4, 781, DateTimeKind.Local), null, null, "Libro", null },
                    { new Guid("95654ed8-5510-4dbe-9b19-b267296f87e1"), new Guid("a422b632-e3da-480f-b237-c551b14f84c0"), new DateTime(2023, 1, 28, 15, 25, 4, 781, DateTimeKind.Local).AddTicks(20), null, null, "Monitor", null },
                    { new Guid("afcd4255-9860-48e0-aba0-5981a1857bbb"), new Guid("a422b632-e3da-480f-b237-c551b14f84c0"), new DateTime(2023, 1, 28, 15, 25, 4, 781, DateTimeKind.Local).AddTicks(10), null, null, "Computador", null },
                    { new Guid("b6353504-c6cc-4c87-8610-4c7eead3d16e"), new Guid("a4745a21-cd2a-4b95-bc0b-a7ec9b12434f"), new DateTime(2023, 1, 28, 15, 25, 4, 781, DateTimeKind.Local).AddTicks(30), null, null, "Cuchara", null },
                    { new Guid("ee0947fb-3b31-4104-918c-60ec99757d85"), new Guid("5cb3774e-88e7-4d69-aac2-38e294f207ec"), new DateTime(2023, 1, 28, 15, 25, 4, 780, DateTimeKind.Local).AddTicks(9990), null, null, "Iphone", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1d643885-fe4b-4a90-8fae-a8218b80b915"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b652bc42-9e7c-47dd-8331-73cfc3fee183"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1b01ecb1-0e9d-4ddc-b09a-a0e1f1685c74"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1d4ce219-4369-4eee-a049-2e4fc02561d8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("95654ed8-5510-4dbe-9b19-b267296f87e1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("afcd4255-9860-48e0-aba0-5981a1857bbb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b6353504-c6cc-4c87-8610-4c7eead3d16e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ee0947fb-3b31-4104-918c-60ec99757d85"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("47ae148e-3623-46ba-a13e-995937216853"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5cb3774e-88e7-4d69-aac2-38e294f207ec"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a1ff8e63-2c4d-46b4-a684-595d389be365"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a422b632-e3da-480f-b237-c551b14f84c0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a4745a21-cd2a-4b95-bc0b-a7ec9b12434f"));

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Id",
                table: "Categories",
                column: "Id",
                unique: true);
        }
    }
}

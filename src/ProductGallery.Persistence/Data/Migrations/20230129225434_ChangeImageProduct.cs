using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductGallery.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImageProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Products",
                newName: "ImageUrl");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1d643885-fe4b-4a90-8fae-a8218b80b915"),
                column: "CreatedAt",
                value: new DateTime(2023, 1, 29, 17, 54, 34, 263, DateTimeKind.Local).AddTicks(6560));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("47ae148e-3623-46ba-a13e-995937216853"),
                column: "CreatedAt",
                value: new DateTime(2023, 1, 29, 17, 54, 34, 263, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5cb3774e-88e7-4d69-aac2-38e294f207ec"),
                column: "CreatedAt",
                value: new DateTime(2023, 1, 29, 17, 54, 34, 263, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a1ff8e63-2c4d-46b4-a684-595d389be365"),
                column: "CreatedAt",
                value: new DateTime(2023, 1, 29, 17, 54, 34, 263, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a422b632-e3da-480f-b237-c551b14f84c0"),
                column: "CreatedAt",
                value: new DateTime(2023, 1, 29, 17, 54, 34, 263, DateTimeKind.Local).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a4745a21-cd2a-4b95-bc0b-a7ec9b12434f"),
                column: "CreatedAt",
                value: new DateTime(2023, 1, 29, 17, 54, 34, 263, DateTimeKind.Local).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b652bc42-9e7c-47dd-8331-73cfc3fee183"),
                column: "CreatedAt",
                value: new DateTime(2023, 1, 29, 17, 54, 34, 263, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ImageUrl", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("40ab51c4-d0c6-499d-b5ed-33def204cb32"), new Guid("a1ff8e63-2c4d-46b4-a684-595d389be365"), new DateTime(2023, 1, 29, 17, 54, 34, 263, DateTimeKind.Local).AddTicks(8150), null, null, "Libro", null },
                    { new Guid("6795328d-1491-4c16-a2e4-c446004a9259"), new Guid("a422b632-e3da-480f-b237-c551b14f84c0"), new DateTime(2023, 1, 29, 17, 54, 34, 263, DateTimeKind.Local).AddTicks(8160), null, null, "Computador", null },
                    { new Guid("922c3d52-a7df-45b2-a606-b2fdb5eee620"), new Guid("a4745a21-cd2a-4b95-bc0b-a7ec9b12434f"), new DateTime(2023, 1, 29, 17, 54, 34, 263, DateTimeKind.Local).AddTicks(8190), null, null, "Cuchara", null },
                    { new Guid("94a6a1b3-dfa8-4539-a262-31fb90c0cddf"), new Guid("5cb3774e-88e7-4d69-aac2-38e294f207ec"), new DateTime(2023, 1, 29, 17, 54, 34, 263, DateTimeKind.Local).AddTicks(8130), null, null, "Iphone", null },
                    { new Guid("cc05c8af-e70b-40ea-8bf1-e6d361be2ea8"), new Guid("a422b632-e3da-480f-b237-c551b14f84c0"), new DateTime(2023, 1, 29, 17, 54, 34, 263, DateTimeKind.Local).AddTicks(8180), null, null, "Monitor", null },
                    { new Guid("d744cdcf-dd6f-4bb7-b39c-a91c3df296a1"), new Guid("47ae148e-3623-46ba-a13e-995937216853"), new DateTime(2023, 1, 29, 17, 54, 34, 263, DateTimeKind.Local).AddTicks(8200), null, null, "Mario Kart", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("40ab51c4-d0c6-499d-b5ed-33def204cb32"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6795328d-1491-4c16-a2e4-c446004a9259"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("922c3d52-a7df-45b2-a606-b2fdb5eee620"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("94a6a1b3-dfa8-4539-a262-31fb90c0cddf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cc05c8af-e70b-40ea-8bf1-e6d361be2ea8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d744cdcf-dd6f-4bb7-b39c-a91c3df296a1"));

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "Image");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1d643885-fe4b-4a90-8fae-a8218b80b915"),
                column: "CreatedAt",
                value: new DateTime(2023, 1, 28, 15, 25, 4, 780, DateTimeKind.Local).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("47ae148e-3623-46ba-a13e-995937216853"),
                column: "CreatedAt",
                value: new DateTime(2023, 1, 28, 15, 25, 4, 780, DateTimeKind.Local).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5cb3774e-88e7-4d69-aac2-38e294f207ec"),
                column: "CreatedAt",
                value: new DateTime(2023, 1, 28, 15, 25, 4, 780, DateTimeKind.Local).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a1ff8e63-2c4d-46b4-a684-595d389be365"),
                column: "CreatedAt",
                value: new DateTime(2023, 1, 28, 15, 25, 4, 780, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a422b632-e3da-480f-b237-c551b14f84c0"),
                column: "CreatedAt",
                value: new DateTime(2023, 1, 28, 15, 25, 4, 780, DateTimeKind.Local).AddTicks(8930));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a4745a21-cd2a-4b95-bc0b-a7ec9b12434f"),
                column: "CreatedAt",
                value: new DateTime(2023, 1, 28, 15, 25, 4, 780, DateTimeKind.Local).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b652bc42-9e7c-47dd-8331-73cfc3fee183"),
                column: "CreatedAt",
                value: new DateTime(2023, 1, 28, 15, 25, 4, 780, DateTimeKind.Local).AddTicks(8970));

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
        }
    }
}

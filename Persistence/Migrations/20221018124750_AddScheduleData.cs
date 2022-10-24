using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddScheduleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { new Guid("2251ef77-c607-4bca-ba50-70b62f33fe31"), DateTime.Now, "Viernes" },
                    { new Guid("4174672a-1fe7-4945-b579-bc95a12a81f9"), DateTime.Now, "Martes" },
                    { new Guid("91a7ad32-70b7-4f3a-92d7-abdec43fe028"), DateTime.Now, "Miércoles" },
                    { new Guid("91a7ad32-70b7-4f3a-92d7-abdec43fe029"), DateTime.Now, "Lunes" },
                    { new Guid("b5c8c13d-8cb8-43f2-be1f-ebc5fb0772b5"), DateTime.Now, "Sábado" },
                    { new Guid("d08b8e67-44cb-4ed9-ada8-cac86a6e2e42"), DateTime.Now, "Jueves" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("2251ef77-c607-4bca-ba50-70b62f33fe31"));

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("4174672a-1fe7-4945-b579-bc95a12a81f9"));

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("91a7ad32-70b7-4f3a-92d7-abdec43fe028"));

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("91a7ad32-70b7-4f3a-92d7-abdec43fe029"));

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("b5c8c13d-8cb8-43f2-be1f-ebc5fb0772b5"));

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("d08b8e67-44cb-4ed9-ada8-cac86a6e2e42"));
        }
    }
}

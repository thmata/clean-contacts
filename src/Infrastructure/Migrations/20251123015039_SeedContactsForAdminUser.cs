using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedContactsForAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "id", "created_at", "email", "name", "phone", "updated_at", "user_id" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), new DateTime(2025, 11, 21, 1, 0, 0, 0, DateTimeKind.Utc), "joao.silva@email.com", "João Silva", "+5511999999999", null, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000002"), new DateTime(2025, 11, 21, 2, 0, 0, 0, DateTimeKind.Utc), "maria.oliveira@email.com", "Maria Oliveira", "+5511988888888", null, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000003"), new DateTime(2025, 11, 21, 3, 0, 0, 0, DateTimeKind.Utc), "carlos.souza@email.com", "Carlos Souza", "+5511977777777", null, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000004"), new DateTime(2025, 11, 21, 4, 0, 0, 0, DateTimeKind.Utc), "ana.santos@email.com", "Ana Santos", "+5511966666666", null, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000005"), new DateTime(2025, 11, 21, 5, 0, 0, 0, DateTimeKind.Utc), "pedro.costa@email.com", "Pedro Costa", "+5511955555555", null, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000006"), new DateTime(2025, 11, 21, 6, 0, 0, 0, DateTimeKind.Utc), "juliana.lima@email.com", "Juliana Lima", "+5511944444444", null, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000007"), new DateTime(2025, 11, 21, 7, 0, 0, 0, DateTimeKind.Utc), "roberto.alves@email.com", "Roberto Alves", "+5511933333333", null, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000008"), new DateTime(2025, 11, 21, 8, 0, 0, 0, DateTimeKind.Utc), "fernanda.rocha@email.com", "Fernanda Rocha", "+5511922222222", null, new Guid("00000000-0000-0000-0000-000000000001") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000008"));
        }
    }
}

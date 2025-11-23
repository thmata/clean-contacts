using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhoneFormatAndSeedContacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "contacts",
                type: "character varying(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "id", "created_at", "email", "name", "phone", "updated_at", "user_id" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), new DateTime(2025, 11, 21, 1, 0, 0, 0, DateTimeKind.Utc), "joao.silva@email.com", "João Silva", "11999999999", null, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000002"), new DateTime(2025, 11, 21, 2, 0, 0, 0, DateTimeKind.Utc), "maria.oliveira@email.com", "Maria Oliveira", "11988888888", null, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000003"), new DateTime(2025, 11, 21, 3, 0, 0, 0, DateTimeKind.Utc), "carlos.souza@email.com", "Carlos Souza", "11977777777", null, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000004"), new DateTime(2025, 11, 21, 4, 0, 0, 0, DateTimeKind.Utc), "ana.santos@email.com", "Ana Santos", "11966666666", null, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000005"), new DateTime(2025, 11, 21, 5, 0, 0, 0, DateTimeKind.Utc), "pedro.costa@email.com", "Pedro Costa", "11955555555", null, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000006"), new DateTime(2025, 11, 21, 6, 0, 0, 0, DateTimeKind.Utc), "juliana.lima@email.com", "Juliana Lima", "11944444444", null, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000007"), new DateTime(2025, 11, 21, 7, 0, 0, 0, DateTimeKind.Utc), "roberto.alves@email.com", "Roberto Alves", "11933333333", null, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000008"), new DateTime(2025, 11, 21, 8, 0, 0, 0, DateTimeKind.Utc), "fernanda.rocha@email.com", "Fernanda Rocha", "11922222222", null, new Guid("00000000-0000-0000-0000-000000000001") }
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

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "contacts",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11);
        }
    }
}

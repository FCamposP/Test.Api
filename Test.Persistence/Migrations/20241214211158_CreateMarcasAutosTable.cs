using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateMarcasAutosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarcaAuto",
                columns: table => new
                {
                    MarcaAutoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Descripcion = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaAuto", x => x.MarcaAutoId);
                });

            migrationBuilder.InsertData(
                table: "MarcaAuto",
                columns: new[] { "MarcaAutoId", "Codigo", "CreatedBy", "Descripcion", "IsActive", "Modified", "ModifiedBy", "Nombre" },
                values: new object[,]
                {
                    { 1, "MAU01", 1, "Marca americana", true, null, null, "Ford" },
                    { 2, "MAU02", 1, "Marca americana", true, null, null, "Chevrolet" },
                    { 3, "MAU03", 1, "Marca americana", true, null, null, "Jeep" },
                    { 4, "MAU04", 1, "Marca europea", true, null, null, "BMW" },
                    { 5, "MAU05", 1, "Marca europea", true, null, null, "Mercedes-Benz" },
                    { 6, "MAU06", 1, "Marca europea", true, null, null, "Volkswagen" },
                    { 7, "MAU07", 1, "Marca asiática", true, null, null, "Toyota" },
                    { 8, "MAU08", 1, "Marca asiática", true, null, null, "Honda" },
                    { 9, "MAU09", 1, "Marca asiática", true, null, null, "Mitsubishi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcaAuto");
        }
    }
}

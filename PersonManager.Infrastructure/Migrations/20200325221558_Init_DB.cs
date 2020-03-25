using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonManager.Infrastructure.Migrations
{
    public partial class Init_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedBy", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, null, false, "Group 1", null, null });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedBy", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 2, null, false, "Group 2", null, null });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CreatedBy", "GroupId", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, null, 1, false, "John Lewis", null, null });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CreatedBy", "GroupId", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 2, null, 1, false, "Peter Johns", null, null });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CreatedBy", "GroupId", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 3, null, 1, false, "Boris Johnson", null, null });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CreatedBy", "GroupId", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 4, null, 2, false, "Elisabeth II", null, null });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CreatedBy", "GroupId", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 5, null, 2, false, "Theresa May", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_GroupId",
                table: "Persons",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}

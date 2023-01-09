using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class termsofuse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbTermsOfUses",
                columns: table => new
                {
                    TermsOfUseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    TermsOfUseTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TermsOfUseDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TermsOfUseImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TermsOfUseToWhom = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTermsOfUses", x => x.TermsOfUseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbTermsOfUses");
        }
    }
}

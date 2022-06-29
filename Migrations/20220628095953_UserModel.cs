using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace aspmvc_react.Migrations
{
  public partial class UserModel : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Users",
          columns: table => new
          {
            Id = table.Column<Guid>(nullable: false),
            UserName = table.Column<string>(nullable: true),
            PaswordHash = table.Column<string>(nullable: true),
            EmailAdress = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Users", x => x.Id);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Users");
    }
  }
}

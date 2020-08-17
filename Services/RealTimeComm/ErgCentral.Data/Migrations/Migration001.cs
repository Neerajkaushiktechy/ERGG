using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ErgCentral.Data.Migrations
{
    public partial class Migration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distance",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceId = table.Column<string>(maxLength: 10, nullable: true),
                    ParticipantName = table.Column<string>(maxLength: 20, nullable: true),
                    ParticipantUserId = table.Column<Guid>(nullable: false),
                    MetersCompleted = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    CurrentSpeed = table.Column<double>(nullable: false),
                    AverageSpeed = table.Column<double>(nullable: false),
                    StrokeRatesPerMinute = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distance", x => x.Id);
                });

            migrationBuilder.Sql(
              @"CREATE TABLE [LogEvents] (
               [Id] int IDENTITY(1,1) NOT NULL,
               [Message] nvarchar(max) NULL,
               [MessageTemplate] nvarchar(max) NULL,
               [Level] nvarchar(128) NULL,
               [TimeStamp] datetime NOT NULL,
               [Exception] nvarchar(max) NULL,
               [Properties] nvarchar(max) NULL
               CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([Id] ASC)
            );");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Distance");
        }
    }
}
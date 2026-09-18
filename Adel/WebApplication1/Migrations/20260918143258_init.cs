using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    OrganizerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Organizers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    AttendeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registrations_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "Adel @gmail.com", "Alice Johnson", "01012345678" },
                    { 2, "Ali @gmail.com", "Bob Smith", "01098765432" },
                    { 3, "Ahmed @gmail.com", "Charlie Brown", "01056789012" },
                    { 4, "David @gmail.com", "David Lee", "01034567890" },
                    { 5, "Eva @gmail.com", "Eva Green", "01067890123" },
                    { 6, "Frank @gmail.com", "Frank White", "01023456789" }
                });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "Id", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "Adel@gmail.com", "John Doe", "010234567890" },
                    { 2, "Ali @gmail.com", "Jane Smith", "010987654321" },
                    { 3, "Ahmed@gmail.com", "Ahmed Hassan", "010123456789" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Capacity", "Location", "Name" },
                values: new object[,]
                {
                    { 1, 500, "123 Main St, Cityville", "Grand Hall" },
                    { 2, 200, "456 Elm St, Townsville", "Conference Center" },
                    { 3, 1000, "789 Oak St, Villagetown", "Outdoor Arena" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Capacity", "Category", "Description", "EndTime", "EventDate", "OrganizerId", "StartTime", "Title", "VenueId" },
                values: new object[,]
                {
                    { 1, 300, "Technology", "A conference on the latest trends in technology", new TimeSpan(0, 17, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 9, 0, 0, 0), "Tech Conference 2024", 1 },
                    { 2, 200, "Music", "A festival featuring performances by renowned musicians", new TimeSpan(0, 22, 0, 0, 0), new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 14, 0, 0, 0), "Music Festival", 3 },
                    { 3, 150, "Art", "A exhibition showcasing contemporary art", new TimeSpan(0, 18, 0, 0, 0), new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 10, 0, 0, 0), "Art Exhibition", 2 },
                    { 4, 250, "Business", "A summit for business leaders and entrepreneurs", new TimeSpan(0, 17, 0, 0, 0), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 9, 0, 0, 0), "Business Summit", 1 },
                    { 5, 400, "Food", "A festival celebrating culinary delights from around the world", new TimeSpan(0, 20, 0, 0, 0), new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 12, 0, 0, 0), "Food Festival", 3 },
                    { 6, 100, "Film", "A screening of an award-winning film followed by a Q&A session with the director", new TimeSpan(0, 21, 0, 0, 0), new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 18, 0, 0, 0), "Film Screening", 2 }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "RegistrationId", "AttendeeId", "EventId", "RegistrationDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2026, 9, 18, 17, 32, 57, 767, DateTimeKind.Local).AddTicks(2535), "Confirmed" },
                    { 2, 2, 2, new DateTime(2026, 9, 18, 17, 32, 57, 767, DateTimeKind.Local).AddTicks(2590), "Confirmed" },
                    { 3, 3, 3, new DateTime(2026, 9, 18, 17, 32, 57, 767, DateTimeKind.Local).AddTicks(2593), "Confirmed" },
                    { 4, 4, 4, new DateTime(2026, 9, 18, 17, 32, 57, 767, DateTimeKind.Local).AddTicks(2595), "Confirmed" },
                    { 5, 5, 5, new DateTime(2026, 9, 18, 17, 32, 57, 767, DateTimeKind.Local).AddTicks(2597), "Confirmed" },
                    { 6, 6, 6, new DateTime(2026, 9, 18, 17, 32, 57, 767, DateTimeKind.Local).AddTicks(2600), "Confirmed" },
                    { 7, 2, 1, new DateTime(2026, 9, 18, 17, 32, 57, 767, DateTimeKind.Local).AddTicks(2602), "Confirmed" },
                    { 8, 3, 2, new DateTime(2026, 9, 18, 17, 32, 57, 767, DateTimeKind.Local).AddTicks(2604), "Confirmed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_Email",
                table: "Attendees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizerId",
                table: "Events",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId",
                table: "Events",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_Email",
                table: "Organizers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_AttendeeId",
                table: "Registrations",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_EventId_AttendeeId",
                table: "Registrations",
                columns: new[] { "EventId", "AttendeeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venues_Name",
                table: "Venues",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Organizers");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}

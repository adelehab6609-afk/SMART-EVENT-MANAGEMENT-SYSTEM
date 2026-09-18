using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.App_context
{
    public class AppDpcontex : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Assignment _Theory & Practical;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Organizer>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Venue>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Attendee>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Registration>()
                .HasKey(r => r.RegistrationId);

            modelBuilder.Entity<Event>()
                    .HasOne(e => e.Organizer)
                    .WithMany(o => o.Events)
                    .HasForeignKey(e => e.OrganizerId);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Venue)
                .WithMany(v => v.Events)
                .HasForeignKey(e => e.VenueId);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Registrations)
                .HasForeignKey(r => r.EventId);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Attendee)
                .WithMany(a => a.Registrations)
                .HasForeignKey(r => r.AttendeeId);

            modelBuilder.Entity<Organizer>()
                .HasIndex(o => o.Email)
                .IsUnique();

            modelBuilder.Entity<Attendee>()
                .HasIndex(a => a.Email)
                .IsUnique();

            modelBuilder.Entity<Venue>()
                .HasIndex(v => v.Name)
                .IsUnique();

            modelBuilder.Entity<Registration>()
                .HasIndex(r => new { r.EventId, r.AttendeeId })
                .IsUnique();

            modelBuilder.Entity<Organizer>()
                .HasData(
                    new Organizer
                    {
                        Id = 1,
                        FullName = "John Doe",
                        Email = "Adel@gmail.com",
                        Phone = "010234567890"
                    },

                    new Organizer
                    {
                        Id = 2,
                        FullName = "Jane Smith",
                        Email = "Ali @gmail.com",
                        Phone = "010987654321"
                    },

                    new Organizer
                    {
                        Id = 3,
                        FullName = "Ahmed Hassan",
                        Email = "Ahmed@gmail.com",
                        Phone = "010123456789"
                    }
                );

            modelBuilder.Entity<Venue>()
                .HasData(
                    new Venue
                    {
                        Id = 1,
                        Name = "Grand Hall",
                        Location = "123 Main St, Cityville",
                        Capacity = 500
                    },
                    new Venue
                    {
                        Id = 2,
                        Name = "Conference Center",
                        Location = "456 Elm St, Townsville",
                        Capacity = 200
                    },
                    new Venue
                    {
                        Id = 3,
                        Name = "Outdoor Arena",
                        Location = "789 Oak St, Villagetown",
                        Capacity = 1000
                    }
                );

            modelBuilder.Entity<Event>()
                .HasData(
                    new Event
                    {
                        Id = 1,
                        Title = "Tech Conference 2024",
                        Description = "A conference on the latest trends in technology",
                        EventDate = new DateTime(2024, 5, 15),
                        StartTime = new TimeSpan(9, 0, 0),
                        EndTime = new TimeSpan(17, 0, 0),
                        Category = "Technology",
                        Capacity = 300,
                        OrganizerId = 1,
                        VenueId = 1
                    },
                    new Event
                    {
                        Id = 2,
                        Title = "Music Festival",
                        Description = "A festival featuring performances by renowned musicians",
                        EventDate = new DateTime(2024, 6, 20),
                        StartTime = new TimeSpan(14, 0, 0),
                        EndTime = new TimeSpan(22, 0, 0),
                        Category = "Music",
                        Capacity = 200,
                        OrganizerId = 2,
                        VenueId = 3
                    },
                    new Event
                    {
                        Id = 3,
                        Title = "Art Exhibition",
                        Description = "A exhibition showcasing contemporary art",
                        EventDate = new DateTime(2024, 7, 10),
                        StartTime = new TimeSpan(10, 0, 0),
                        EndTime = new TimeSpan(18, 0, 0),
                        Category = "Art",
                        Capacity = 150,
                        OrganizerId = 3,
                        VenueId = 2
                    },
                    new Event
                    {
                        Id = 4,
                        Title = "Business Summit",
                        Description = "A summit for business leaders and entrepreneurs",
                        EventDate = new DateTime(2024, 8, 5),
                        StartTime = new TimeSpan(9, 0, 0),
                        EndTime = new TimeSpan(17, 0, 0),
                        Category = "Business",
                        Capacity = 250,
                        OrganizerId = 1,
                        VenueId = 1
                    },
                    new Event
                    {
                        Id = 5,
                        Title = "Food Festival",
                        Description = "A festival celebrating culinary delights from around the world",
                        EventDate = new DateTime(2024, 9, 15),
                        StartTime = new TimeSpan(12, 0, 0),
                        EndTime = new TimeSpan(20, 0, 0),
                        Category = "Food",
                        Capacity = 400,
                        OrganizerId = 2,
                        VenueId = 3
                    },
                    new Event
                    {
                        Id = 6,
                        Title = "Film Screening",
                        Description = "A screening of an award-winning film followed by a Q&A session with the director",
                        EventDate = new DateTime(2024, 10, 10),
                        StartTime = new TimeSpan(18, 0, 0),
                        EndTime = new TimeSpan(21, 0, 0),
                        Category = "Film",
                        Capacity = 100,
                        OrganizerId = 3,
                        VenueId = 2
                    }
                );


            modelBuilder.Entity<Attendee>()
                .HasData(
                    new Attendee
                    {
                        Id = 1,
                        FullName = "Alice Johnson",
                        Email = "Adel @gmail.com",
                        Phone = "01012345678"
                    },
                    new Attendee
                    {
                        Id = 2,
                        FullName = "Bob Smith",
                        Email = "Ali @gmail.com",
                        Phone = "01098765432"
                    },
                    new Attendee
                    {
                        Id = 3,
                        FullName = "Charlie Brown",
                        Email = "Ahmed @gmail.com",
                        Phone = "01056789012"
                    },
                    new Attendee
                    {
                        Id = 4,
                        FullName = "David Lee",
                        Email = "David @gmail.com",
                        Phone = "01034567890"
                    },
                    new Attendee
                    {
                        Id = 5,
                        FullName = "Eva Green",
                        Email = "Eva @gmail.com",
                        Phone = "01067890123"
                    },
                    new Attendee
                    {
                        Id = 6,
                        FullName = "Frank White",
                        Email = "Frank @gmail.com",
                        Phone = "01023456789"
                    }
                );

            modelBuilder.Entity<Registration>()
                .HasData(
                    new Registration
                    {
                        RegistrationId = 1,
                        Status = "Confirmed",
                        EventId = 1,
                        AttendeeId = 1,
                        RegistrationDate = DateTime.Now
                    },
                    new Registration
                    {
                        RegistrationId = 2,
                        Status = "Confirmed",
                        EventId = 2,
                        AttendeeId = 2,
                        RegistrationDate = DateTime.Now
                    },
                    new Registration
                    {
                        RegistrationId = 3,
                        Status = "Confirmed",
                        EventId = 3,
                        AttendeeId = 3,
                        RegistrationDate = DateTime.Now
                    },
                    new Registration
                    {
                        RegistrationId = 4,
                        Status = "Confirmed",
                        EventId = 4,
                        AttendeeId = 4,
                        RegistrationDate = DateTime.Now
                    },
                    new Registration
                    {
                        RegistrationId = 5,
                        Status = "Confirmed",
                        EventId = 5,
                        AttendeeId = 5,
                        RegistrationDate = DateTime.Now
                    },
                    new Registration
                    {
                        RegistrationId = 6,
                        Status = "Confirmed",
                        EventId = 6,
                        AttendeeId = 6,
                        RegistrationDate = DateTime.Now
                    },
                    new Registration
                    {
                        RegistrationId = 7,
                        Status = "Confirmed",
                        EventId = 1,
                        AttendeeId = 2,
                        RegistrationDate = DateTime.Now
                    },
                    new Registration
                    {
                        RegistrationId = 8,
                        Status = "Confirmed",
                        EventId = 2,
                        AttendeeId = 3,
                        RegistrationDate = DateTime.Now
                    }
                    );
        }
        public DbSet<Event> Events { get; set; }

        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<Venue> Venues { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Registration> Registrations { get; set; }
    }
}
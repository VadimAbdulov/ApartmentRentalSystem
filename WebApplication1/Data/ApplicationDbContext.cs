using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Apartment>().HasData(
                new Apartment { Id = 1, Address = "ул. Ленина, 1", PricePerMonth = 30000, Rooms = 2, IsAvailable = true },
                new Apartment { Id = 2, Address = "ул. Мира, 10", PricePerMonth = 45000, Rooms = 3, IsAvailable = true },
                new Apartment { Id = 3, Address = "ул. Победы, 25", PricePerMonth = 28000, Rooms = 1, IsAvailable = true },
                new Apartment { Id = 4, Address = "пр. Гагарина, 7", PricePerMonth = 52000, Rooms = 4, IsAvailable = false },
                new Apartment { Id = 5, Address = "ул. Советская, 100", PricePerMonth = 35000, Rooms = 2, IsAvailable = true }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, FullName = "Иванов Иван Иванович", Phone = "9000000001", Email = "ivan1@mail.ru" },
                new Client { Id = 2, FullName = "Петров Пётр Петрович", Phone = "9000000002", Email = "petr@mail.ru" },
                new Client { Id = 3, FullName = "Сидорова Анна Сергеевна", Phone = "9000000003", Email = "anna@mail.ru" },
                new Client { Id = 4, FullName = "Кузнецов Максим Андреевич", Phone = "9000000004", Email = "max@mail.ru" },
                new Client { Id = 5, FullName = "Смирнова Ольга Викторовна", Phone = "9000000005", Email = "olga@mail.ru" }
            );

            modelBuilder.Entity<Rent>().HasData(
                new Rent
                {
                    Id = 1,
                    ApartmentId = 1,
                    ClientId = 1,
                    StartDate = new DateTime(2024, 1, 1),
                    EndDate = new DateTime(2024, 12, 31)
                },
                new Rent
                {
                    Id = 2,
                    ApartmentId = 2,
                    ClientId = 2,
                    StartDate = new DateTime(2024, 2, 1),
                    EndDate = new DateTime(2024, 8, 31)
                },
                new Rent
                {
                    Id = 3,
                    ApartmentId = 3,
                    ClientId = 3,
                    StartDate = new DateTime(2024, 3, 15),
                    EndDate = new DateTime(2024, 9, 15)
                },
                new Rent
                {
                    Id = 4,
                    ApartmentId = 5,
                    ClientId = 4,
                    StartDate = new DateTime(2024, 4, 1),
                    EndDate = new DateTime(2024, 10, 1)
                },
                new Rent
                {
                    Id = 5,
                    ApartmentId = 4,
                    ClientId = 5,
                    StartDate = new DateTime(2024, 5, 1),
                    EndDate = new DateTime(2024, 11, 1)
                }
            );
        }
    }
}

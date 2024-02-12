using GuitarCenter.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuitarCenterWeb.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
 
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electric", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Acoustic", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Classical", DisplayOrder = 3 });

            modelBuilder.Entity<Company>().HasData(
                new Company {
                    Id = 1, 
                    Name = "Company1",
                    StreetAddress = "123 Tech St",
                    City = "Tech City",
                    PostalCode = "121212",
                    State = "IL",
                    PhoneNumber = "666999000"
                },
                new Company
                {
                    Id = 2,
                    Name = "Company2",
                    StreetAddress = "999 Vivid St",
                    City = "Vid City",
                    PostalCode = "66666",
                    State = "IL",
                    PhoneNumber = "777999000"
                },
                new Company
                {
                    Id = 3,
                    Name = "Company3",
                    StreetAddress = "999 Main St",
                    City = "Lala land",
                    PostalCode = "99999",
                    State = "NY",
                    PhoneNumber = "1113335555"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Gibson Explorer",
                    Brand = "Gibson",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    SerialNumber = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 2,
                    Name = "KH Ouija",
                    Brand = "ESP Guitars",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    SerialNumber = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    CategoryId = 1,
					ImageUrl = ""
				},
                new Product
                {
                    Id = 3,
                    Name = "Fender H12",
                    Brand = "Fender",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    SerialNumber = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
					CategoryId = 1,
					ImageUrl = ""
				},
                new Product
                {
                    Id = 4,
                    Name = "Gibson J35",
                    Brand = "Gibson",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    SerialNumber = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
					CategoryId = 2,
					ImageUrl = ""
				},
                new Product
                {
                    Id = 5,
                    Name = "Gibson 39GLS",
                    Brand = "Gibson",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    SerialNumber = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
					CategoryId = 2,
					ImageUrl = ""
				},
                new Product
                {
                    Id = 6,
                    Name = "Aiersi S098",
                    Brand = "Aiersi",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    SerialNumber = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
					CategoryId = 3,
					ImageUrl = ""
				});
        }
    }
}

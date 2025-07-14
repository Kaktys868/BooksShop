using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

namespace BooksShop.Classes.Common
{
    public class DbConnect : DbContext
    {
        public DbConnect(DbContextOptions<DbConnect> options) 
            : base(options) { }

        public DbSet<Admission> Admissions { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartBook> CartBooks { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreBook> GenreBooks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Series> Seriess { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseBook> WarehouseBooks { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistUser> WishlistUsers { get; set; }
        public DbSet<WishlistBook> WishlistBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasMany(p => p.CartBooks)
                .WithOne(p => p.Cart)
                .HasForeignKey(s => s.CartId);
            modelBuilder.Entity<User>()
                .HasMany(p => p.Orders)
                .WithOne(p => p.User)
                .HasForeignKey(s=>s.OrderUserId);
            modelBuilder.Entity<User>()
                .HasMany(p=>p.Reviews)
                .WithOne(p=>p.User)
                .HasForeignKey(p=>p.ReviewUserId);
            modelBuilder.Entity<User>()
                .HasMany(p => p.Carts)
                .WithOne(p => p.User)
                .HasForeignKey(s => s.CartUserId);
            modelBuilder.Entity<User>()
                .HasMany(p => p.UserRoles)
                .WithOne(p => p.User)
                .HasForeignKey(s => s.UserId);
            modelBuilder.Entity<Role>()
                .HasMany(p => p.RoleUsers)
                .WithOne(p => p.Role)
                .HasForeignKey(s => s.RoleId);
            modelBuilder.Entity<User>()
                .HasMany(p => p.WishlistUsers)
                .WithOne(p => p.User)
                .HasForeignKey(s => s.UserId);
            modelBuilder.Entity<Wishlist>()
                .HasMany(p => p.WishlistUsers)
                .WithOne(p => p.Wishlist)
                .HasForeignKey(s => s.WishlistId);
            modelBuilder.Entity<Wishlist>()
                .HasMany(p => p.WishlistBooks)
                .WithOne(p => p.Wishlist)
                .HasForeignKey(s => s.WishlistId);
            modelBuilder.Entity<Book>()
                .HasMany(p => p.WishlistBooks)
                .WithOne(p => p.Book)
                .HasForeignKey(s => s.BookId);
            modelBuilder.Entity<Book>()
                .HasMany(p => p.Reviews)
                .WithOne(p => p.Book)
                .HasForeignKey(p => p.ReviewBookId);
            modelBuilder.Entity<Book>()
                .HasMany(p => p.CartBooks)
                .WithOne(p => p.Book)
                .HasForeignKey(s => s.BookId);
            modelBuilder.Entity<Book>()
                .HasMany(p => p.Orders)
                .WithOne(p => p.Book)
                .HasForeignKey(s => s.OrderBookId);
            modelBuilder.Entity<Series>()
                .HasMany(p => p.Books)
                .WithOne(p => p.Series)
                .HasForeignKey(s => s.BookSeries);
            modelBuilder.Entity<Book>()
                .HasMany(p => p.AuthorBooks)
                .WithOne(p => p.Book)
                .HasForeignKey(s => s.BookId);
            modelBuilder.Entity<Author>()
                .HasMany(p => p.AuthorBooks)
                .WithOne(p => p.Author)
                .HasForeignKey(s => s.AuthorId);
            modelBuilder.Entity<Book>()
                .HasMany(p => p.GenreBooks)
                .WithOne(p => p.Book)
                .HasForeignKey(s => s.BookId);
            modelBuilder.Entity<Genre>()
                .HasMany(p => p.GenreBooks)
                .WithOne(p => p.Genre)
                .HasForeignKey(s => s.GenreId);
            modelBuilder.Entity<Publisher>()
                .HasMany(p=>p.Books)
                .WithOne(p=>p.Publishers)
                .HasForeignKey(s=>s.BookSeries);
            modelBuilder.Entity<Book>()
                .HasMany(p => p.Admissions)
                .WithOne(p => p.Book)
                .HasForeignKey(s => s.AdmissionBookId);
            modelBuilder.Entity<Book>()
                .HasMany(p => p.Deliveries)
                .WithOne(p => p.Book)
                .HasForeignKey(s => s.DeliveryBookId);
            modelBuilder.Entity<Book>()
                .HasMany(p => p.WarehouseBooks)
                .WithOne(p => p.Book)
                .HasForeignKey(s => s.BookId);
            modelBuilder.Entity<Warehouse>()
                .HasMany(p => p.WarehouseBooks)
                .WithOne(p => p.Warehouse)
                .HasForeignKey(s => s.WarehouseId);
            modelBuilder.Entity<Warehouse>()
                .HasMany(p => p.Admissions)
                .WithOne(p => p.Warehouse)
                .HasForeignKey(s => s.AdmissionWarehouseId);
            modelBuilder.Entity<Warehouse>()
                .HasMany(p => p.Deliveries)
                .WithOne(p => p.Warehouse)
                .HasForeignKey(s => s.DeliveryWarehouseId);
            modelBuilder.Entity<City>()
                .HasMany(p => p.Warehouses)
                .WithOne(p => p.City)
                .HasForeignKey(s => s.WarehouseCityId);

            base.OnModelCreating(modelBuilder);
            //♾️
        }
    }
}

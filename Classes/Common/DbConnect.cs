using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;

namespace BooksShop.Classes.Common
{
    public class DbConnect : DbContext
    {
        public DbConnect(DbContextOptions<DbConnect> options) 
            : base(options) { }

        public DbSet<Admission> Admission { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<AuthorBook> AuthorBook { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartBook> CartBook { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<GenreBook> GenreBook { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<WarehouseBook> WarehouseBook { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<WishlistUser> WishlistUser { get; set; }
        public DbSet<WishlistBook> WishlistBook { get; set; }

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
                .HasForeignKey(s=>s.BookPublisher);
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

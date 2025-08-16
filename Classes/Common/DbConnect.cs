using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}

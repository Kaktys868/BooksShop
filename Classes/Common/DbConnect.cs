using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using System;

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
        public DbSet<City> Cities { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartBook> CartBooks { get; set; }
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
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistUser> WishlistUsers { get; set; }
        public DbSet<WishlistBook> WishlistBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            base.OnModelCreating(modelBuilder);
        }        
    }
}

﻿namespace BooksShop.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateOnly BookDateDesign { get; set; }
        public int BookCost { get; set; }
        public int BookSeries { get; set; }
        public int BookGenre { get; set; }
        public int BookPublisher { get; set; }
        public ICollection<WishlistBook> WishlistBooks { get; set; }
        public Book()
        {
            WishlistBooks = new List<WishlistBook>();
        }
    }
}

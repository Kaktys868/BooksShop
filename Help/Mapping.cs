using AutoMapper;
using BooksShop.DTO;
using BooksShop.Models;

namespace BooksShop.Help
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            //Admission
            CreateMap<CreateAdmissionDto, Admission>();
            CreateMap<Admission, AdmissionDto>();
            //Author
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<Author, AuthorDto>();
            //AuthorBook
            CreateMap<CreateAuthorBookDto, AuthorBook>();
            CreateMap<AuthorBook, AuthorBookDto>();
            //Book
            CreateMap<CreateBookDto, Book>();
            CreateMap<Book, BookDto>();
            //Cart
            CreateMap<CreateCartDto, Cart>();
            CreateMap<Cart, CartDto>();
            //CartBook
            CreateMap<CreateCartBookDto, CartBook>();
            CreateMap<CartBook, CartBookDto>();
            //City
            CreateMap<CreateCityDto, City>();
            CreateMap<City, CityDto>();
            //Delivery
            CreateMap<CreateDeliveryDto, Delivery>();
            CreateMap<Delivery, DeliveryDto>();
            //Genre
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<Genre, GenreDto>();
            //GenreBook
            CreateMap<CreateGenreBookDto, GenreBook>();
            CreateMap<GenreBook, GenreBookDto>();
            //Order
            CreateMap<CreateOrderDto, Order>();
            CreateMap<Order, OrderDto>();
            //Publisher
            CreateMap<CreatePublisherDto, Publisher>();
            CreateMap<Publisher, PublisherDto>();
            //Review
            CreateMap<CreateReviewDto, Review>();
            CreateMap<Review, ReviewDto>();
            //Role
            CreateMap<CreateRoleDto, Role>();
            CreateMap<Role, RoleDto>();
            //Series
            CreateMap<CreateSeriesDto, Series>();
            CreateMap<Series, SeriesDto>();
            //User
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserDto>();
            //UserRole
            CreateMap<CreateUserRoleDto, UserRole>();
            CreateMap<UserRole, UserRoleDto>();
            //Warehouse
            CreateMap<CreateWarehouseDto, Warehouse>();
            CreateMap<Warehouse, WarehouseDto>();
            //WarehouseBook
            CreateMap<CreateWarehouseBookDto, WarehouseBook>();
            CreateMap<WarehouseBook, WarehouseBookDto>();
            //Wishlist
            CreateMap<CreateWishlistDto, Wishlist>();
            CreateMap<Wishlist, WishlistDto>();
            //WishlistBook
            CreateMap<CreateWishlistBookDto, WishlistBook>();
            CreateMap<WishlistBook, WishlistBookDto>();
            //WishlistUser
            CreateMap<CreateWishlistUserDto, WishlistUser>();
            CreateMap<WishlistUser, WishlistUserDto>();
        }
    }
}
using BooksShop.Classes.Common;
using BooksShop.Help;
using BooksShop.Interfaces.Admission;
using BooksShop.Interfaces.Author;
using BooksShop.Interfaces.AuthorBook;
using BooksShop.Interfaces.Book;
using BooksShop.Interfaces.Cart;
using BooksShop.Interfaces.CartBook;
using BooksShop.Interfaces.City;
using BooksShop.Interfaces.Delivery;
using BooksShop.Interfaces.Genre;
using BooksShop.Interfaces.GenreBook;
using BooksShop.Interfaces.Order;
using BooksShop.Interfaces.Publisher;
using BooksShop.Interfaces.Review;
using BooksShop.Interfaces.Role;
using BooksShop.Interfaces.Series;
using BooksShop.Interfaces.User;
using BooksShop.Interfaces.UserRole;
using BooksShop.Interfaces.Warehouse;
using BooksShop.Interfaces.WarehouseBook;
using BooksShop.Models;
using BooksShop.Repositories;
using BooksShop.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WarehousesShop.Repositories;
using WarehousesShop.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddDbContext<DbConnect>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAdmissionRepository, AdmissionRepositroy>();
builder.Services.AddScoped<IAdmissionService, AdmissionService>();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IAuthorBookRepository, AuthorBookRepository>();
builder.Services.AddScoped<IAuthorBookService, AuthorBookService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<ICartRepository, CartRepositroy>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddScoped<ICartBookRepository, CartBookRepository>();
builder.Services.AddScoped<ICartBookService, CartBookService>();

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();

builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();

builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();

builder.Services.AddScoped<IGenreBookService, GenreBookService>();
builder.Services.AddScoped<IGenreBookRepository, GenreBookRepository>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();

builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddScoped<ISeriesService, SeriesService>();
builder.Services.AddScoped<ISeriesRepository, SeriesRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();

builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();

builder.Services.AddScoped<IWarehouseBookService, WarehouseBookService>();
builder.Services.AddScoped<IWarehouseBookRepository, WarehouseBookRepository>();

builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Admission"
    });
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v1",
        Title = "Author"
    }); 
    c.SwaggerDoc("v3", new OpenApiInfo
    {
        Version = "v1",
        Title = "AuthorBook"
    }); 
    c.SwaggerDoc("v4", new OpenApiInfo
    {
        Version = "v1",
        Title = "Book"
    }); 
    c.SwaggerDoc("v5", new OpenApiInfo
    {
        Version = "v1",
        Title = "Cart"
    }); 
    c.SwaggerDoc("v6", new OpenApiInfo
    {
        Version = "v1",
        Title = "CartBook"
    });
    c.SwaggerDoc("v7", new OpenApiInfo
    {
        Version = "v1",
        Title = "City"
    });
    c.SwaggerDoc("v8", new OpenApiInfo
    {
        Version = "v1",
        Title = "Delivery"
    });
    c.SwaggerDoc("v9", new OpenApiInfo
    {
        Version = "v1",
        Title = "Genre"
    });
    c.SwaggerDoc("v10", new OpenApiInfo
    {
        Version = "v1",
        Title = "GenreBook"
    }); 
    c.SwaggerDoc("v11", new OpenApiInfo
    {
        Version = "v1",
        Title = "Order"
    });
    c.SwaggerDoc("v12", new OpenApiInfo
    {
        Version = "v1",
        Title = "Publisher"
    });
    c.SwaggerDoc("v13", new OpenApiInfo
    {
        Version = "v1",
        Title = "Review"
    });
    c.SwaggerDoc("v14", new OpenApiInfo
    {
        Version = "v1",
        Title = "Role"
    });
    c.SwaggerDoc("v15", new OpenApiInfo
    {
        Version = "v1",
        Title = "Series"
    }); 
    c.SwaggerDoc("v16", new OpenApiInfo
    {
        Version = "v1",
        Title = "User"
    });
    c.SwaggerDoc("v17", new OpenApiInfo
    {
        Version = "v1",
        Title = "UserRole"
    });
    c.SwaggerDoc("v18", new OpenApiInfo
    {
        Version = "v1",
        Title = "Warehouse"
    });
    c.SwaggerDoc("v19", new OpenApiInfo
    {
        Version = "v1",
        Title = "WarehouseBook"
    });
    c.SwaggerDoc("v20", new OpenApiInfo
    {
        Version = "v1",
        Title = "Wishlist"
    });
    c.SwaggerDoc("v21", new OpenApiInfo
    {
        Version = "v1",
        Title = "WishlistBook"
    });
    c.SwaggerDoc("v22", new OpenApiInfo
    {
        Version = "v1",
        Title = "WishlistUser"
    });
});
var app = builder.Build(); 
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseMvcWithDefaultRoute();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admission");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Author");
    c.SwaggerEndpoint("/swagger/v3/swagger.json", "AuthorBook");
    c.SwaggerEndpoint("/swagger/v4/swagger.json", "Book");
    c.SwaggerEndpoint("/swagger/v5/swagger.json", "Cart");
    c.SwaggerEndpoint("/swagger/v6/swagger.json", "CartBook");
    c.SwaggerEndpoint("/swagger/v7/swagger.json", "City");
    c.SwaggerEndpoint("/swagger/v8/swagger.json", "Delivery");
    c.SwaggerEndpoint("/swagger/v9/swagger.json", "Genre");
    c.SwaggerEndpoint("/swagger/v10/swagger.json", "GenreBook");
    c.SwaggerEndpoint("/swagger/v11/swagger.json", "Order");
    c.SwaggerEndpoint("/swagger/v12/swagger.json", "Publisher");
    c.SwaggerEndpoint("/swagger/v13/swagger.json", "Review");
    c.SwaggerEndpoint("/swagger/v14/swagger.json", "Role");
    c.SwaggerEndpoint("/swagger/v15/swagger.json", "Series");
    c.SwaggerEndpoint("/swagger/v16/swagger.json", "User");
    c.SwaggerEndpoint("/swagger/v17/swagger.json", "UserRole");
    c.SwaggerEndpoint("/swagger/v18/swagger.json", "Warehouse");
    c.SwaggerEndpoint("/swagger/v19/swagger.json", "WarehouseBook");
    c.SwaggerEndpoint("/swagger/v20/swagger.json", "Wishlist");
    c.SwaggerEndpoint("/swagger/v21/swagger.json", "WishlistBook");
    c.SwaggerEndpoint("/swagger/v22/swagger.json", "WishlistUser");
});
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
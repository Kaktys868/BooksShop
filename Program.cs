using Scrutor;
using BooksShop.Classes.Common;
using BooksShop.Help;
using BooksShop.Repositories;
using BooksShop.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

string[] name = ["Admission", "Author", "AuthorBook", "Book",
    "Cart", "CartBook", "City", "Delivery", "Genre", "GenreBook",
    "Order", "Publisher", "Review", "Role", "Series", "User",
    "UserRole", "Warehouse", "WarehouseBook", "Wishlist",
    "WishlistBook", "WishlistUser", "DeleteAllController" ];

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddDbContext<DbConnect>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Scan(scan => scan
    .FromAssemblyOf<AdmissionService>()
        .AddClasses(classes => classes.Where(t => t.Name.EndsWith("Service")))
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime()
    .FromAssemblyOf<AdmissionRepository>()
        .AddClasses(classes => classes.Where(t => t.Name.EndsWith("Repository")))
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime()
);
builder.Services.AddAutoMapper(typeof(Mapping));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    for (int i = 0; i < name.Length; i++)
    {
        c.SwaggerDoc($"v{i + 1}", new OpenApiInfo
        {
            Version = $"v{i + 1}",
            Title = name[i]
        });

    }
});
var app = builder.Build(); 
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseMvcWithDefaultRoute();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    for (int i = 0; i < name.Length; i++)
    {
        c.SwaggerEndpoint($"/swagger/v{i + 1}/swagger.json", name[i]);

    }
});
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
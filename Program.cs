using BooksShop.Classes.Common;
using BooksShop.Help;
using BooksShop.Interfaces;
using BooksShop.Interfaces.Series;
using BooksShop.Repositories;
using BooksShop.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddDbContext<DbConnect>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<ISeriesService, SeriesService>();
builder.Services.AddScoped<ISeriesRepository, SeriesRepository>();

builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "������",
        Description = "������ ����������� ��� ������������� �������� ����������� � �������"
    });
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2",
        Title = "����������� ��� ������������� ��������",
        Description = "������ ����������� ��� ������������� �������� ����������� � �������"
    });
});
var app = builder.Build(); 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseMvcWithDefaultRoute();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "������");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "������� POST");
});
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
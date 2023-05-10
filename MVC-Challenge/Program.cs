using Microsoft.EntityFrameworkCore;
using MVC_Challenge.Data;
using MVC_Challenge.Data.Repositorys;
using MVC_Challenge.Domain.Profiles;
using MVC_Challenge.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

string mysqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProductContextDb>(options => options.UseMySQL(mysqlConnection));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IServicesProducts, ServicesProducts>();
builder.Services.AddAutoMapper(typeof(ProductsProfiles).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Products/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();

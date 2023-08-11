using WS.MVC.Data.Context;
using WS.MVC.Data.Services;
using WS.MVC.Data.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var myConnectionString = builder.Configuration.GetConnectionString("MyConnectionString");

builder.Services.AddDbContext<MyContext>(option => option.UseMySql(myConnectionString, ServerVersion.AutoDetect(myConnectionString)));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

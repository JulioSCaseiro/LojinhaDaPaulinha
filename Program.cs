using LojinhaDaPaulinha.Data;
using LojinhaDaPaulinha.Data.Identity;
using LojinhaDaPaulinha.Data.Repositories.Interfaces;
using LojinhaDaPaulinha.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LojinhaDaPaulinha.Services.Api;
using LojinhaDaPaulinha.Services.Data;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection here

builder.Services.AddDbContext<DataContext>(cfg =>
{
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(cfg =>
{
    cfg.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZÀàÁáÂâÄäÉéÈèÍíÌìÎîÏïÓóÒòÔôÖöÚúÙùÛûÜüÑñÇçİı -_.@";

    cfg.Password.RequireDigit = false;
    cfg.Password.RequireLowercase = false;
    cfg.Password.RequireNonAlphanumeric = false;
    cfg.Password.RequireUppercase = false;
    cfg.Password.RequiredLength = 1;
}).AddEntityFrameworkStores<DataContext>();

builder.Services.AddScoped<IIdentityManager, IdentityManager>();

builder.Services.AddScoped<IDataUnit, DataUnit>();
builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<DataService>();


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();




// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

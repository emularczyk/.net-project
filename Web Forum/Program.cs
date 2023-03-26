using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web_Forum.Areas.Identity;
using Web_Forum.Data;
using Web_Forum.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<User, UserRole>();

builder.Services.AddTransient<IUserStore<User>, UserStore>();
builder.Services.AddTransient<IRoleStore<UserRole>, RoleStore>();

builder.Services.AddDbContext<IdentityApplicationDbContext>(options => options.UseMySQL(builder.Configuration
                                                                                       .GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

<<<<<<< HEAD
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

=======
>>>>>>> c782a94 (Login and register functionality and fix database and models)
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

<<<<<<< HEAD
=======
//app.UseHttpsRedirection();
>>>>>>> c782a94 (Login and register functionality and fix database and models)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
<<<<<<< HEAD
app.UseSession();
=======

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
>>>>>>> c782a94 (Login and register functionality and fix database and models)

app.MapRazorPages();

app.Run();

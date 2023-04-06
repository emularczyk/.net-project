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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

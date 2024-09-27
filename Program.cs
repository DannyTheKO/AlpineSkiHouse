using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AlpineSkiHouse.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Connect MySQL Database
builder.Services.AddDbContext<MVC_TicketContext>(options =>
	options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
		new MySqlServerVersion(new Version(8, 0, 39)))); // Use UseMySql instead of UseMySQL

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

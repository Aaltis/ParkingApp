using Microsoft.EntityFrameworkCore;
using ParkingApp.Pages;
using ParkingApp.Pages.ConfigModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Config>(builder.Configuration.GetSection("Config"));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the in-memory database


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

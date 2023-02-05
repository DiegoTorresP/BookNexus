using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookNexus.Data;
using SmartBreadcrumbs.Extensions;
using System.Reflection;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookNexusContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookNexusContext") ?? throw new InvalidOperationException("Connection string 'BookNexusContext' not found.")));

builder.Services.AddBreadcrumbs(Assembly.GetExecutingAssembly(), options =>
{
    options.TagName = "nav";
    options.TagClasses = "";
    options.OlClasses = "breadcrumb";
    options.LiClasses = "breadcrumb-item";
    options.ActiveLiClasses = "breadcrumb-item active";
});
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
    pattern: "{controller=Login}/{action=Index}/{id?}"
    );

app.Run();

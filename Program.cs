using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookNexus.Data;
using BookNexus;
using SmartBreadcrumbs.Extensions;
using System.Reflection;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

//var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
//builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
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
builder.Services.AddMvc();
builder.Services.AddTransient<SessionMiddleware>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
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
app.UseSession();
app.UseWhen(context => !context.Request.Path.StartsWithSegments("/Login") && !context.Request.Path.StartsWithSegments("/Usuarios"), builder =>
{
    builder.UseMiddleware<SessionMiddleware>();
});
//app.UseMiddleware<SessionMiddleware>();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}"
    );
app.Run();

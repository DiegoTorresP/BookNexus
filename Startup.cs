using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Configure los servicios que la aplicación va a utilizar.
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure el pipeline de middleware que procesa las solicitudes HTTP.
        app.UseMiddleware<SessionMiddleware>();
    }
}

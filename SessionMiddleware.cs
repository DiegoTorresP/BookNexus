using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class SessionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Session.GetString("NameUser") == null)
        {
            // Si la información es nula, redireccionar a Login
            context.Response.Redirect("/Login/Index");
            return;
        }

        // Si la sesión está vigente, pasar la solicitud al siguiente middleware
        await next(context);
    }
}
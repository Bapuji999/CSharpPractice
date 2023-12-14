
using MiddlewarePractice.MiddleWares;

namespace MiddlewarePractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<MyMiddleware>();
            builder.Services.AddCors(options => {
                options.AddPolicy("AllowAll", options =>
                {
                    options.AllowAnyOrigin()
                           .WithMethods("POST")
                           .AllowAnyHeader();
                });
            });
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<AuthHandler>("Test");
            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                context.Response.Headers["a"] = "a";
                await next(context); 
                context.Response.Headers["d"] = "e";
            });
            //app.Use(async (context, next) =>
            //{
            //    bool userAgent = context.Request.Headers.Keys.Contains("Postman-Token");
            //    if (userAgent)
            //    {
            //        context.Response.StatusCode = StatusCodes.Status403Forbidden;
            //        await context.Response.WriteAsync("Access denied from Postman.");
            //    }
            //    else
            //    {
            //        await next();
            //    }
            //});
            app.UseMiddleware<MyMiddleware>();
            app.MyMiddleware();
            app.Run(async context =>
            {
                context.Response.Headers["b"] = "c";
            });
            app.Run();
        }
    }
}
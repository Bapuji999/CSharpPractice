
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebAPI1.Examples;

namespace WebAPI1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IEmploye, Employe>();
            builder.Services.AddSingleton<ISingle, Single1>();
            //builder.Services.TryAddSingleton<ISingle, Single>();
            builder.Services.AddSingleton<ISingle, Single>();
            builder.Services.AddTransient<ITrans, Trans>();
            builder.Services.AddScoped<IScope, Scope>();
            builder.Services.AddScoped<IProof, Proof>();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

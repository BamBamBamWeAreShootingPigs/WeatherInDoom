using Domain.Interfaces;
using Domain.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Services;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using DataAccess;
using Microsoft.OpenApi.Models;

namespace WetherInDoom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<EthernetShopContext>(
                options => options.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=EthernetShop;Trusted_Connection=True;"));

            builder.Services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "EthernetShop",
                    Description = "EthernetShop API",
                    Contact = new OpenApiContact
                    {
                        Name = "Contacts",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License",
                        Url = new Uri("https://example.com/license")
                    }
                });
            });



            var app = builder.Build();

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
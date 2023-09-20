using Microsoft.EntityFrameworkCore;
using StoreCS.DAL.Impl;
using StoreCS.DAL.Impl.Context;
using StoreCS.Entities;

namespace StoreCS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
        
            // Add secrets configuration
            builder.Configuration.AddUserSecrets<Program>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


            builder.Services.AddDbContext<StoreDbContext>(
                options => options.UseSqlServer(connectionString));

            builder.Services.SeedData();


            // Add services to the container.

            builder.Services.InstallRepositories();

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

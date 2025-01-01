using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using StanbicIBTC.Bank.Services.Models;
using StanbicIBTC.Bank.Services.Services;
using StanbicIBTC.Bank.Services.Interfaces;
using StanbicIBTC.Bank.Services.Data;

namespace StanbicIBTC.Bank.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register application services
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();


            // Add controllers (Web API)
            builder.Services.AddControllers();

            // Add Swagger/OpenAPI support for documentation and testing
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StanbicIBTC.Bank.Services v1"));
            }

            // Use HTTPS redirection
            app.UseHttpsRedirection();

            // Map controllers to endpoints
            app.MapControllers();

            app.Run();
        }
    }
}

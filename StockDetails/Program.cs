using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StockDetails.Interfaces;
using StockDetails.Models;
using StockDetails.Services;
using System.Text;

namespace StockDetails
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(); 
            builder.Services.AddScoped<IRepo<int,StockData>,StockDetailsRepo>();
            builder.Services.AddScoped<IRepo<int, DailyStock>, DailyStockRepo>();
            builder.Services.AddScoped<IStockInfo, StockDetailsService>();
            builder.Services.AddDbContext<StockDetailsContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("AngularCORS", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseCors("AngularCORS");


            app.MapControllers();

            app.Run();
        }
    }
}
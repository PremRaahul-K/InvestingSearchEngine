using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SWOTAnalysis.Interfaces;
using SWOTAnalysis.Models;
using SWOTAnalysis.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SWOTContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("UserCon")));
builder.Services.AddScoped<IRepo<int, Strength>, StrengthRepo>();
builder.Services.AddScoped<IRepo<int, Weakness>, WeaknessRepo>();
builder.Services.AddScoped<IRepo<int, Oppurtunity>, OppurtunityRepo>();
builder.Services.AddScoped<IRepo<int, Threat>, ThreatRepo>();
builder.Services.AddScoped<ISWOTDetails, SWOTDetailsRepo>();
builder.Services.AddScoped<IRepo<int, SWOT>, SWOTRepo>();
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

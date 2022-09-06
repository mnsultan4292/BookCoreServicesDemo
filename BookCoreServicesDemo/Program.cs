using BookCoreServicesDemo.Helper;
using BookCoreServicesDemo.Models;
using BookCoreServicesDemo.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BookCoreServicesDemo.Extensions;
using BookCoreServicesDemo.AppSettings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("BookDbConnection");
builder.Services.AddDbContext<BookDBContext>(item => item.UseSqlServer(connectionString));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRegistrationRepository, UserRegistrationRepository>();
builder.Services.AddScoped<IJwtHelper,JwtHelper>();
builder.Services.AddScoped<SettingDemo>();

// To register the IException filter 
//builder.Services.AddMvc(options =>
//{
//    options.Filters.Add<ExceptionFilter>();  
//});


//JWT Authentication

// 1. You can use this or 
//builder.Services.AddJWTTokenService(builder.Configuration);

//2. this
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//to authentication or authorization for token
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

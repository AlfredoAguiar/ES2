using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApplication2.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection"))
);

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
                    builder.WithOrigins("http://localhost:5192")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Add authentication middleware
app.UseAuthorization();

// Enable CORS middleware
app.UseCors("AllowSpecificOrigins");

app.MapControllers();

// Start the application
app.Run();
using Backend;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Backend.Data.Context;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(setup =>
{
    setup.AddPolicy("All", opt =>
    {
        opt.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();

        
    });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = JwtInfo.Issuer,
        ValidAudience = JwtInfo.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.Key)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
    };
});

// Add services to the container.

builder.Services.AddDbContext<Context>(opt =>
{
    opt.UseSqlServer("server=(localdb)\\mssqllocaldb; database=Backend; integrated security=true;");
});

builder.Services.AddMediatR(typeof(Program));
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
app.UseCors("All");
app.UseAuthorization();

app.MapControllers();

app.Run();

void GetDbContextOptions(DbContextOptionsBuilder builder)
{
    builder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=Backend; integrated security=true;");
}
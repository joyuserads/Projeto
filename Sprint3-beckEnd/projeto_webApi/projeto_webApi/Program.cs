using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Text;
using System;
using projeto_webApi.Repositories;
using projeto_webApi.Interfaces;
using projeto_webApi;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicione os demais repositórios também se estiverem prontos
builder.Services.AddScoped<IUsuario, UsuarioRepository>(); //   Add UsuarioRepository
builder.Services.AddScoped<ITipoUsuario, TipoUsuarioRepository>(); // Add TipoUsuarioRepository
builder.Services.AddScoped<IEquipamentos, EquipamentoRepository>(); // Add EquipamentoRepository 



builder.Services.AddAuthorization();
//builder.Services.AddScoped<TokenService>();
builder.Services.AddControllers(); //   Add controllers to the service collection
builder.Services.AddEndpointsApiExplorer(); //   Add endpoints explorer for API documentation
builder.Services.AddSwaggerGen(); //    Add Swagger for API documentation

var app = builder.Build(); //   Build the application

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection(); // Enable HTTPS redirection
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using proj_webapi.Data;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Pegando a sessão ConnectionString
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configurando o Scalar para o projeto
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", // Define uma política de CORS chamada "AllowReact"
        policy => policy.WithOrigins("http://localhost:3000") // Permite requisições do endereço http://localhost:3000
                        .AllowAnyHeader() // Permite qualquer cabeçalho na requisição
                        .AllowAnyMethod()); // Permite qualquer método HTTP (GET, POST, PUT, DELETE, etc.)
});

// Definindo uma chave secreta para autenticação JWT
var key = "minha_chave_super_secreta_que_tem_32_ou_mais_chars";
// Configurando a autenticação JWT
builder.Services.AddAuthentication(options =>
{
    // Configurações de autenticação padrão
    options.DefaultAuthenticateScheme = "JwtBearer"; // Define o esquema de autenticação padrão como "JwtBearer"
    options.DefaultChallengeScheme = "JwtBearer"; // Define o esquema de desafio padrão como "JwtBearer"
})

// Configurando o JWT Bearer Authentication
.AddJwtBearer("JwtBearer", options =>
{
    // Configurações de validação do token JWT
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Define as regras de validação do token
        ValidateIssuer = true, // Verifica o emissor do token
        ValidateAudience = true, // Verifica o público do token
        ValidateLifetime = true, // Verifica se o token ainda é válido (não expirou)
        ValidateIssuerSigningKey = true, // Verifica a assinatura do token

        ValidIssuer = "webapi", // Emissor do token (pode ser o nome da sua aplicação)
        ValidAudience = "webapi", // Público do token (pode ser o nome da sua aplicação)
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), // Chave secreta usada para assinar o token
        ClockSkew = TimeSpan.Zero // Define o tempo de tolerância para a expiração do token (0 significa que não há tolerância)
    };
});




var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference(); // para utiliza scalar para teste
    app.MapOpenApi();
}

app.UseCors("AllowReact"); // Aplica a política de CORS definida anteriormente

app.UseHttpsRedirection(); // Redireciona requisições HTTP para HTTPS

app.UseAuthorization();     // Habilita a autorização baseada em autenticação JWT

app.MapControllers();   // Mapeia os controladores para as rotas definidas

app.Run(); // Inicia a aplicação web

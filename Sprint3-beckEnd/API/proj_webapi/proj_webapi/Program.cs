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

// Pegando a sess�o ConnectionString
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configurando o Scalar para o projeto
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", // Define uma pol�tica de CORS chamada "AllowReact"
        policy => policy.WithOrigins("http://localhost:3000") // Permite requisi��es do endere�o http://localhost:3000
                        .AllowAnyHeader() // Permite qualquer cabe�alho na requisi��o
                        .AllowAnyMethod()); // Permite qualquer m�todo HTTP (GET, POST, PUT, DELETE, etc.)
});

// Definindo uma chave secreta para autentica��o JWT
var key = "minha_chave_super_secreta_que_tem_32_ou_mais_chars";
// Configurando a autentica��o JWT
builder.Services.AddAuthentication(options =>
{
    // Configura��es de autentica��o padr�o
    options.DefaultAuthenticateScheme = "JwtBearer"; // Define o esquema de autentica��o padr�o como "JwtBearer"
    options.DefaultChallengeScheme = "JwtBearer"; // Define o esquema de desafio padr�o como "JwtBearer"
})

// Configurando o JWT Bearer Authentication
.AddJwtBearer("JwtBearer", options =>
{
    // Configura��es de valida��o do token JWT
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Define as regras de valida��o do token
        ValidateIssuer = true, // Verifica o emissor do token
        ValidateAudience = true, // Verifica o p�blico do token
        ValidateLifetime = true, // Verifica se o token ainda � v�lido (n�o expirou)
        ValidateIssuerSigningKey = true, // Verifica a assinatura do token

        ValidIssuer = "webapi", // Emissor do token (pode ser o nome da sua aplica��o)
        ValidAudience = "webapi", // P�blico do token (pode ser o nome da sua aplica��o)
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), // Chave secreta usada para assinar o token
        ClockSkew = TimeSpan.Zero // Define o tempo de toler�ncia para a expira��o do token (0 significa que n�o h� toler�ncia)
    };
});




var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference(); // para utiliza scalar para teste
    app.MapOpenApi();
}

app.UseCors("AllowReact"); // Aplica a pol�tica de CORS definida anteriormente

app.UseHttpsRedirection(); // Redireciona requisi��es HTTP para HTTPS

app.UseAuthorization();     // Habilita a autoriza��o baseada em autentica��o JWT

app.MapControllers();   // Mapeia os controladores para as rotas definidas

app.Run(); // Inicia a aplica��o web

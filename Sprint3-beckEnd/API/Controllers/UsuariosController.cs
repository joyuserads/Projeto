using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.DTOs;
using MinhaApi.Models;
using MinhaApi.Services;
using System.Security.Cryptography;
using System.Text;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public UsuariosController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioRegistroDTO dto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email))
                return BadRequest(new { mensagem = "Email já cadastrado." });

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Papel = dto.Papel,
                SenhaHash = GerarHash(dto.Senha)
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Usuário registrado com sucesso!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioLoginDTO dto)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (usuario == null || usuario.SenhaHash != GerarHash(dto.Senha))
                return Unauthorized(new { mensagem = "Credenciais inválidas." });

            var token = _tokenService.GerarToken(usuario);

            return Ok(new
            {
                token,
                usuario = new { usuario.Nome, usuario.Email, usuario.Papel }
            });
        }

        private string GerarHash(string senha)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(senha);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
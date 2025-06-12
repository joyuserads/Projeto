using Microsoft.EntityFrameworkCore;
using proj_webapi.Models;

namespace proj_webapi.Data
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Classe responsável pela conexão da API com o banco de dados
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        // Tabelas dentro do banco de dados
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Equipamento> Equipamentos { get ; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get;set; }
        public DbSet<SalaEquipamento> SalaEquipamentos { get; set; }




    }
}

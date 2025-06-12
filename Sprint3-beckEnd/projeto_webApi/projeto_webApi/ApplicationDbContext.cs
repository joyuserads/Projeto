using Microsoft.EntityFrameworkCore;
using projeto_webApi.Domains;

namespace projeto_webApi
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor for the application database context
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        /// DbSets for each entity in the application
        public DbSet<Usuario> Usuarios { get; set; } // DbSet for Usuario entity
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<SalaEquipamento> SalaEquipamentos { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships and properties here if needed
            base.OnModelCreating(modelBuilder);

            /// Configuring entity relationships
            modelBuilder.Entity<TipoUsuario>().HasIndex(t => t.NomeTipo).IsUnique(); // Unique index for NomeTipo in TipoUsuario
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();//     Unique index for Email in Usuario
            modelBuilder.Entity<Equipamento>().HasIndex(e => e.NumeroPatrimonio).IsUnique();//  Unique index for NumeroPatrimonio in Equipamento
            modelBuilder.Entity<SalaEquipamento>() //    Configuring SalaEquipamento entity              
                .HasIndex(se => new { se.IdSala, se.IdEquipamento }).IsUnique();    //   // Unique index for SalaEquipamento based on IdSala and IdEquipamento
        }
    }
}

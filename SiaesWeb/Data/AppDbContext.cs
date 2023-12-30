
using Microsoft.EntityFrameworkCore;
using SiaesLibraryShared.Models;
using System.Collections.Generic;

namespace SiaesServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Agregar los modelos
        public DbSet<Usuario> Usuario { get; set; } = default!;

        public DbSet<Model_Tanu> Cuadro1_Tanu { get; set; } = default!;

        
    }
}

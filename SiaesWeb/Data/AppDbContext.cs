using Microsoft.EntityFrameworkCore;
using SiaesLibraryShared.Models;

namespace SiaesServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Model_Tanu> Cuadro1_Tanu { get; set; } = default!;
    }
}

using Bdapis.Shared.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Bdapis.Server.Data
{
    public class BDPatrocinadorContext : DbContext
    {
        public BDPatrocinadorContext(DbContextOptions<BDPatrocinadorContext> options) : base(options)
        {

        }
        public DbSet<Patrocinador> Patrocinadores { get; set; }
        public DbSet<Transmisiones> Transmisiones { get; set; }
        public DbSet<Anuncios> Anuncios { get; set; }
        public DbSet<Ingresos> Ingresos { get; set; }

    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using asignacion.Models;

namespace asignacion.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<asignacion.Models.Ciudades>? Ciudades { get; set; }
        public DbSet<asignacion.Models.Clientes>? Clientes { get; set; }
        public DbSet<asignacion.Models.Facturas>? Facturas { get; set; }
    }
}
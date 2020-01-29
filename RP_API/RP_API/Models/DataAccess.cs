using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
namespace RP_API.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> data)
        : base(data) { }
        public DbSet<Perfil> Perfil{ get; set; }
        public DbSet<Permiso> Permiso { get; set; }

        
    }
}

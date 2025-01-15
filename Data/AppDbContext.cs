

using Microsoft.EntityFrameworkCore;
using testeiel.Models;


namespace testeiel.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

       public DbSet<Estudante> estudante;

       public DbSet<Usuario> usuario;
     
      
    }
}
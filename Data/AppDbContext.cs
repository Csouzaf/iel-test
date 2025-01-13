

using Microsoft.EntityFrameworkCore;

namespace testeiel.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
using Microsoft.EntityFrameworkCore;

namespace Mission6_Rasband.Models
{
    public class FilmCollectionContext : DbContext
    {
        public FilmCollectionContext(DbContextOptions<FilmCollectionContext> options) : base (options) // Constructor
        {
        }

        public DbSet<Collection> Films { get; set; } // Table name = Films
    }
}

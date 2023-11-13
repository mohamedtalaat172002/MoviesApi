using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Model
{
    public class ApplicatioinDbcontext:DbContext
    {
        public ApplicatioinDbcontext(DbContextOptions<ApplicatioinDbcontext> options):base(options)
        {
            
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}

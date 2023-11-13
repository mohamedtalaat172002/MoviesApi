using Microsoft.EntityFrameworkCore;
using MoviesApi.Dto;
using MoviesApi.Model;

namespace MoviesApi.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly ApplicatioinDbcontext _context;
      
      
        public async Task<Movie> Add(Movie movie)
        {
          
            await _context.Movies.AddAsync(movie);
            _context.SaveChanges();
            return movie;
        }

        public  Movie Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return (movie);
        }

        public async Task<IEnumerable<Movie>> GetAll(int id =0)
        {
            var moveis = await _context.Movies
                .Where(m=>m.GenreId==id|| id == 0)
                .OrderByDescending(o => o.Rate)
                .Include(g => g.Genre).ToListAsync();
            return (moveis);
            
        }
        public async Task<Movie> GetById(int id)
        {
           var movie=await _context.Movies.Include(g => g.Genre).SingleOrDefaultAsync(s => s.id == id);
            return movie;
        }

        public Movie Update(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
            return (movie);

        }
    }
}

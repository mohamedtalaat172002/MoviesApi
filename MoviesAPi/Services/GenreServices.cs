using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Services
{
    public class GenreServices : IGenreServices
    {
        private readonly ApplicatioinDbcontext _context;

        public GenreServices(ApplicatioinDbcontext context)
        {
            _context = context;
        }

        public async Task<Genre> Add(Genre genre)
        {
           await _context.Genres.AddAsync(genre);
            _context.SaveChanges();
            return(genre);
        }

        public Genre Delete(Genre genre)
        {
            _context.Genres.Remove(genre);
            _context.SaveChanges() ;
            return genre;
        }

        public async Task<IEnumerable<Genre>> GetALl()
        {
            return await _context.Genres.OrderBy(g=>g.Name).ToListAsync();   
        }

        public async  Task<Genre> GetByid(int id)
        {
            return await _context.Genres.SingleOrDefaultAsync(g => g.Id == id);

        }

        public Task<bool> isValideGenre(int id)
        {
            return  _context.Genres.AnyAsync(g => g.Id == id);
        }

        public Genre Update(Genre genre)
        {
            _context.Genres.Update(genre);
            _context.SaveChanges();
            return genre;
        }
    }
}

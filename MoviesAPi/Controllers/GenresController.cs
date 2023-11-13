using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreServices genreServices;
        public GenresController( IGenreServices genreServices)
        {       
            this.genreServices = genreServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var Genres = genreServices.GetALl();
            return Ok(Genres);
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre(GenreDto genreDto)
        {
            Genre genre = new Genre { Name = genreDto.name };
            await genreServices.Add(genre);
            return Ok(genre);
        }

        [HttpPut(template:"{id}")]

        public async Task<IActionResult> updateGenre(int id, [FromBody] GenreDto genreDto)
        {
            var genre = await genreServices.GetByid(id);
            if (genre == null)
            {
                return NotFound($"there is no genre with id {id}");
            }
            genre.Name=genreDto.name;
            genreServices.Update(genre);
            return Ok(genre);

        }

        [HttpDelete(template: "{id}")]
        public async Task<IActionResult> Deletegenre(int id)
        {
            var genre = await genreServices.GetByid(id);
            if (genre == null)
            {
                return NotFound($"there is no genre with id {id}");
            }
            genreServices.Delete(genre);
            return Ok(genre);


        }

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Dto;
using MoviesApi.Model;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieServices _movieServices;
        private readonly IGenreServices _genreServices;
        private readonly IMapper _mapper;

        public MoviesController(IGenreServices genreServices,  IMovieServices movieServices, IMapper mapper)
        {
            _genreServices = genreServices;
            _movieServices = movieServices;
            _mapper = mapper;
        }

        private new List<string> _AllowedExtentions = new List<string>
        {
            ".jpg",
            ".png",
            ".jpej"
        };
        private long _maxsize = 1024 * 1024;

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var moveis =await _movieServices.GetAll();
            var data = _mapper.Map<IEnumerable<MovieDetailsDto>>(moveis);

            return Ok(data);
        }

        [HttpGet(template:"{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Movie movie = await _movieServices.GetById(id);

            if (movie == null)
                return NotFound();

            var dto = _mapper.Map<MovieDetailsDto>(movie);

            return Ok(dto);

        }

        [HttpGet(template: "GetByGenreId")]
        public async Task<IActionResult> GetByGenreId(int id)
        {
            var movie = await _movieServices.GetAll(id);
            var dto = _mapper.Map<MovieDetailsDto>(movie);

            return Ok(dto);
        }

            [HttpPost]
        public async Task<IActionResult> AddMovie([FromForm] MovieDto movieDto)
        {
            using var datastream = new MemoryStream();
            await movieDto.Poster.CopyToAsync(datastream);
            if(movieDto.Poster==null)
            {
                return BadRequest("Poster is required");
            }
            if (!_AllowedExtentions.Contains(Path.GetExtension(movieDto.Poster.FileName).ToLower()))
            {
                return BadRequest("inavlid extentions");
            }
            if (movieDto.Poster.Length > _maxsize)
            {
                return BadRequest("inavlid size");
            }


            var validgenre = await _genreServices.isValideGenre(movieDto.GenreId);
            if (!validgenre)
            {
                return BadRequest("invlid genreID");
            }
           var movie = _mapper.Map<Movie>(movieDto);
            movie.Poster = datastream.ToArray();
            _movieServices.Add(movie);

            return Ok(movie);


        }

       
        [HttpDelete]
        public async Task<IActionResult> DelteMovie(int id)
        {
            var movie = await _movieServices.GetById(id);
            if (movie == null)
            {
                return NotFound($"there is no movie with this Id {id}");
            }
            _movieServices.Delete(movie);
            return Ok(movie);

        }

        
        [HttpPut]
        public async Task<IActionResult> updateMovie(int id,[FromForm]MovieDto dto)
        {
            var movie= await _movieServices.GetById(id);
            if (dto.Poster != null)
            {
                if (!_AllowedExtentions.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                    return BadRequest("Only .png and .jpg images are allowed!");

                if (dto.Poster.Length > _maxsize)
                    return BadRequest("Max allowed size for poster is 1MB!");

                using var dataStream = new MemoryStream();

                await dto.Poster.CopyToAsync(dataStream);

                movie.Poster = dataStream.ToArray();
            }


            movie.StoreLine= dto.StoreLine;
            movie.Title= dto.Title;
            movie.Rate= dto.Rate;
            movie.year = dto.year;
           

            _movieServices.Update(movie);

            return Ok(movie);
        }
        
    }
}

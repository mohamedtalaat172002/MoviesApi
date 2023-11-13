namespace MoviesApi.Dto
{
    public class MovieDto
    {
        [MaxLength(200)]
        public string Title { get; set; }

        public int year { get; set; }

        public double Rate { get; set; }

        [MaxLength(2500)]
        public string StoreLine { get; set; }

        public IFormFile? Poster { get; set; }

        public int GenreId { get; set; }

        
    }
}

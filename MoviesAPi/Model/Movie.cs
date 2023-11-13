namespace MoviesApi.Model
{
    public class Movie
    {
        public int id { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        public int year { get; set; }

        public double Rate { get; set; }

        [MaxLength(2500)]
        public string StoreLine { get; set; }

        public byte[] Poster{ get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }    
    }
}

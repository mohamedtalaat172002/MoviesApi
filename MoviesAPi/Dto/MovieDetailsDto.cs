namespace MoviesApi.Dto
{
    public class MovieDetailsDto
    {
        public string Title { get; set; }

        public int year { get; set; }

        public double Rate { get; set; }

     
        public string StoreLine { get; set; }

        public byte[] Poster { get; set; }

        public string GenreNama { get; set; }
        public int GenreId { get; set; }

    }
}

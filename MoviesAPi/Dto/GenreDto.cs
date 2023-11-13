namespace MoviesApi.Dto
{
    public class GenreDto
    {
        [MaxLength(100)]
        public string name { get; set; }
    }
}

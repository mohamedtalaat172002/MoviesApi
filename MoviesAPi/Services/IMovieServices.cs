namespace MoviesApi.Services
{
    public interface IMovieServices
    {
        Task<IEnumerable<Movie>> GetAll(int id=0);

        Task<Movie> GetById(int id);

        Task<Movie> Add(Movie movie);

        Movie Update(Movie movie);

        Movie Delete(Movie movie);

       

    }
}

namespace MoviesApi.Services
{
    public interface IGenreServices
    {
        Task<IEnumerable<Genre>> GetALl();

        Task<Genre> GetByid(int id);

        Task<Genre> Add(Genre genre);

        Genre Update(Genre genre);

        Genre Delete(Genre genre);

        Task<bool> isValideGenre(int id);

    }
}

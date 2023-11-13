using AutoMapper;

namespace MoviesApi.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDetailsDto>();
            CreateMap<MovieDto, MovieDetailsDto>()
                .ForMember(s=>s.Poster,opt=>opt.Ignore());
        }
    }
}

using AutoMapper;
using EntitiesLayer;
using EntitiesLayer.DTO;

namespace MovieReviewAPP.Utilities.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movies, MovieDTO>().ReverseMap();
            CreateMap<Genres, GenreDTO>().ReverseMap();
            CreateMap<GenreCreatedDTO, Genres>().ReverseMap();
            CreateMap<MovieUpdateDto, Movies>().ReverseMap();
            CreateMap<MovieCreatedDto, Movies>().ReverseMap();
            CreateMap<RegisterDto, User>().ReverseMap();
            CreateMap<Comments, CommentDTO>().ReverseMap();
            CreateMap<CommentCreateDTO, Comments>().ReverseMap();
        }
    }
}
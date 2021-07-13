using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using cima.Model;
using cima.Dtos;

namespace cima.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();

            Mapper.CreateMap<Favorite, FavoriteDto>();
            Mapper.CreateMap<FavoriteDto, Favorite>();
        }
    }
}
using System;
using System.Linq;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.WEB.Models;

namespace Task_WEB.Configuration
{
    public class MappingViewProfile : Profile
    {
        [Obsolete]
        protected override void Configure()
        {
            CreateMap<GenreModelViewForFilter, GenreDTO>()
              .ForMember(dest => dest.SubGenres, opt => opt.MapFrom(scr => scr.SubGenres.Where(genre => genre.IsSelected == true)));
            CreateMap<GenreDTO, GenreModelViewForFilter>();
            //  .ForMember(dest => dest.SubGenres, opt => opt.MapFrom(scr => scr.SubGenres.Where(genre => genre.IsSelected == true)));

        }
    }
}
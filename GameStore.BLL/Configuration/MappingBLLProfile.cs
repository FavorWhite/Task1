using System;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.DAL.Entities;

namespace GameStore.BLL.Configuration
{
    public class MappingBLLProfile : Profile
    {
        [Obsolete]
        protected override void Configure()
        {
            CreateMap<Game, GameDTO>().MaxDepth(2);
            //CreateMap<Game, GameDTO>().MaxDepth(2).ReverseMap();
           // CreateMap<Game, GameDTO>().MaxDepth(2).ReverseMap().ForMember(x=>x.Id,op=>op.AllowNull());
            CreateMap<PlatformType, PlatformTypeDTO>().MaxDepth(2);
            CreateMap<Genre, GenreDTO>().MaxDepth(2);
            CreateMap<Comment, CommentDTO>().MaxDepth(2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Task1_BLL.DTO;
using Task1_BLL.Interfaces;
using Task1_DAL.Entities;
using Task1_DAL.Intefaces;
using Task1_DAL.Repositories;

namespace Task1_BLL.Services
{
    public class GameStoreService : IGameStoreService
    {
        private readonly IUnitOfWork _database;// = new EFUnitOfWork("DefaultConnection");

        public GameStoreService(IUnitOfWork database)
        {
            _database = database;
        }

        public void AddComment(CommentDTO commentDTO)
        {
            Comment comment = new Comment
            {
                Name = commentDTO.Name,
                Body = commentDTO.Body,
                GameId = commentDTO.GameId,
                ParentName = commentDTO.ParentName,
                ParentId = /*_database.Comment.Get()*/ GetComments().FirstOrDefault(c=>c.Name==commentDTO.ParentName)?.Id,

            };
            _database.Comment.Create(comment);
            _database.Save();
        }

        public void CreateGame(GameDTO gameDTO)
        {
            Game game = new Game
            {
                Key = gameDTO.Key,
                Name = gameDTO.Name,
                Description = gameDTO.Description
            };
            _database.Game.Create(game);
            _database.Save();
        }
        public void EditGame(GameDTO gameDTO)
        {
            Game game = new Game
            {
                Id = gameDTO.Id,
                Key = gameDTO.Key,
                Name = gameDTO.Name,
                Description = gameDTO.Description
            };
            _database.Game.Update(game);
            _database.Save();
        }
        public void DeleteGame(int id)
        {
            _database.Game.Delete(id);
            _database.Save();
        }
        public IList<CommentDTO> GetComments()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Comment, CommentDTO>());
            var commentDTOs = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(_database.Comment.GetAll());
            return commentDTOs.ToList();
        }

        public IList<CommentDTO> GetCommentsByGameKey(string gameKey)
        {
            int gameId = GetGameByKey(gameKey).Id;
            var commentDTOs = GetComments().Where(g => g.GameId == gameId).ToList();
            return commentDTOs;
        }



        public IList<GameDTO> GetGameByGenre(int genreId)//Check
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Genre, GenreDTO>());
            var genreDTOs = Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(_database.Genre.GetAll());
            return genreDTOs.First(g => g.Id == genreId).Games.ToList();
        }

        public GameDTO GetGameByKey(string key)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Game, GameDTO>());
            var gameDTOs = Mapper.Map<IEnumerable<Game>, IEnumerable<GameDTO>>(_database.Game.GetAll());
            return gameDTOs.First(g => g.Key == key);
        }

        public IList<GameDTO> GetGameByPlatformType(int platformTypeId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PlatformType, PlatformTypeDTO>());
            var PfTDTOs = Mapper.Map<IEnumerable<PlatformType>, IEnumerable<PlatformTypeDTO>>(_database.PlatformType.GetAll());
            return PfTDTOs.First(g => g.Id == platformTypeId).Games.ToList();
        }

        public IList<GameDTO> GetGames()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Game, GameDTO>());
            var gameDTOs = Mapper.Map<IEnumerable<Game>, IEnumerable<GameDTO>>(_database.Game.GetAll());
            return gameDTOs.ToList();
        }

        #region Comment -> Mapping Game to GameDTO  -- GetGameDTO

        //private IList<GameDTO> GetGameDTOs()
        //{
        //    IList<GameDTO> GameDTOs = new List<GameDTO>();
        //    IList<Game> Games = Database.Game.GetAll().ToList();
        //    foreach (var item in Games)
        //    {
        //        List<GenreDTO> genres = new List<GenreDTO>();
        //        foreach (var genre in item.Genres)
        //        {
        //            GenreDTO genreDTO = new GenreDTO
        //            {
        //                Id = genre.Id,
        //                Name = genre.Name,
        //                ParentId = genre.ParentId
        //            };
        //            genres.Add(genreDTO);
        //        }
        //        List<PlatformTypeDTO> platformTypeDTOs = new List<PlatformTypeDTO>();
        //        foreach (var type in item.PlatformTypes)
        //        {
        //            PlatformTypeDTO platformTypeDTO = new PlatformTypeDTO
        //            {
        //                Id = type.Id,
        //                Type = type.Type
        //            };
        //            platformTypeDTOs.Add(platformTypeDTO);
        //        }
        //        GameDTO game = new GameDTO
        //        {
        //            Id = item.Id,
        //            Key = item.Key,
        //            Description = item.Description,
        //            Name = item.Name,
        //            Genres = genres,
        //            PlatformTypes = platformTypeDTOs
        //        };
        //        GameDTOs.Add(game);

        //    }
        //    return GameDTOs;
        //}

        #endregion

        public void Dispose()
        {
            _database.Dispose();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Task1_BLL.Configuration;
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
        //private readonly IMapper Mapper ;

        public GameStoreService(IUnitOfWork database)
        {
           // Mapper.Initialize(x=>x.AddProfile(new MappingBLLProfile()));
            _database = database;
        }
        //public GameStoreService(IUnitOfWork database, IMapper mapper)
        //{
        //    _database = database;
        //    Mapper = mapper;
        //}
        public void AddComment(CommentDTO commentDTO)
        {
            Comment comment = new Comment
            {
                Name = commentDTO.Name,
                Body = commentDTO.Body,
                GameId = commentDTO.GameId,
                ParentName = commentDTO.ParentName,
                ParentId = GetComments().FirstOrDefault(c => c.Name == commentDTO.ParentName)?.Id,

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
        public void DeleteGame(int id)//Почему не показывает покрытие тестом ????
        {
            _database.Game.Delete(id);
            _database.Save();
        }
        public IList<CommentDTO> GetComments()
        {

            //Mapper.Initialize(cfg => cfg.CreateMap<Comment, CommentDTO>());
            var comments = _database.Comment.GetAll().ToList();
            var commentDTOs = AutoMapper.Mapper.Map<IList<Comment>, IList<CommentDTO>>(comments);
         
           // var commentDTOs= Mapper.Map<IList<Comment>, IList<CommentDTO>>(comments);
            return commentDTOs;
        }
        public IList<CommentDTO> GetCommentsByGameKey(string gameKey)
        {
            int gameId = GetGameByKey(gameKey).Id;
            var commentDTOs = GetComments().Where(g => g.GameId == gameId).ToList();
            return commentDTOs;
        }
        public IList<GameDTO> GetGameByGenre(int genreId)//Check
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<Genre, GenreDTO>());
            //var genreDTOs = Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(_database.Genre.GetAll());

            var genre = _database.Genre.GetAll().ToList();
            var genreDTOs = Mapper.Map<IList<Genre>, IList<GenreDTO>>(genre);
            return genreDTOs.First(g => g.Id == genreId).Games.ToList();
        }
        public GameDTO GetGameByKey(string key)
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<Game, GameDTO>());
            //var gameDTOs = Mapper.Map<IEnumerable<Game>, IEnumerable<GameDTO>>(_database.Game.GetAll());
            var games = _database.Game.GetAll().ToList();
            var gameDTOs = Mapper.Map<IList<Game>, IList<GameDTO>>(games);
            return gameDTOs.FirstOrDefault(g=>g.Key==key);
        }
        public IList<GameDTO> GetGameByPlatformType(int platformTypeId)
        {
          //  AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<PlatformType, PlatformTypeDTO>());
            var PfTDTOs = AutoMapper.Mapper.Map<IEnumerable<PlatformType>, IEnumerable<PlatformTypeDTO>>(_database.PlatformType.GetAll());
            return PfTDTOs.First(g => g.Id == platformTypeId).Games.ToList();
        }
        public IList<GameDTO> GetGames()
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<Game, GameDTO>());
            //var gameDTOs = Mapper.Map<IEnumerable<Game>, IEnumerable<GameDTO>>(_database.Game.GetAll());
            var games = _database.Game.GetAll().ToList();
            var gameDTOs = Mapper.Map<List<GameDTO>>(games);
            return gameDTOs;
        }
        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
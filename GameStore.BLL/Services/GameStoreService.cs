using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Configuration;
using GameStore.DAL.Entities;
using GameStore.DAL.Intefaces;
using GameStore.DAL.Repositories;
using Shared;

namespace GameStore.BLL.Services
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
                ParentId = GetComments().FirstOrDefault(c => c.Name == commentDTO.ParentName)?.Id,

            };
            _database.Comment.Create(comment);
            _database.Save();
        }

        public void CreateGame(GameDTO gameDTO)
        {
            //Game game = new Game
            //{
            //    Key = gameDTO.Key,
            //    Name = gameDTO.Name,
            //    Description = gameDTO.Description
            //};
            var game= Mapper.Map<GameDTO, Game>(gameDTO);

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
            var comments = _database.Comment.GetAll().ToList();
            var commentDTOs = AutoMapper.Mapper.Map<IList<Comment>, IList<CommentDTO>>(comments);

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
            var game = _database.Game.GetAll(x => x.Genres.Any(g => g.Id == genreId)).ToList();// экономия колич запросов
            var gameDTO = Mapper.Map<IList<Game>, IList<GameDTO>>(game);
            return gameDTO;
            //var genreDTOs = Mapper.Map<IList<Genre>, IList<GenreDTO>>(genre);
            //return genreDTOs.First(g => g.Id == genreId).Games.ToList();
        }
        public GameDTO GetGameByKey(string key)
        {
            var games = _database.Game.GetAll().ToList();
            var gameDTOs = Mapper.Map<IList<Game>, IList<GameDTO>>(games);
            return gameDTOs.FirstOrDefault(g=>g.Key==key);
        }
        public IList<GameDTO> GetGameByPlatformType(int platformTypeId)
        {
            var PfTDTOs = AutoMapper.Mapper.Map<IEnumerable<PlatformType>, IEnumerable<PlatformTypeDTO>>(_database.PlatformType.GetAll());
            return PfTDTOs.First(g => g.Id == platformTypeId).Games.ToList();
        }
        ////////////////////////////////////////////////
        public  Expression<Func<Game, bool>> GenreListContainsInGame(List<int> genresId)
        {
            var predicate = PredicateBuilder.False<Game>();
            Genre genre;
            foreach (var item in genresId)
            {
                genre = _database.Genre.Get(item);


                predicate = predicate.Or(g => g.Genres.Contains(genre));
            }
            return predicate;
        }
        public IList<GameDTO> GetGames(List<int> genres = null/* , List<int> platforms = null*/)
        {
            List<Game> games;
            if (genres==null /*&& platforms==null*/)
            {
                games = _database.Game.GetAll().ToList();
            }
            else
            {
                //Expression<Func<Game, bool>> predicate = GenreListContainsInGame(genres);
                var predicate = PredicateBuilder.False<Game>();
                predicate = predicate.Or(x => genres.Any(val => x.Genres.Any(g => g.Id == val)));
                //platforms.Add(1);


               // Expression.OrElse(x => genres.Contains(x.Id), x => genres.Contains(x.Id));
                //games = _database.Game.GetAll(x => x.Id == 4).ToList();
                games = _database.Game.GetAll(predicate).ToList();
            }
            var gameDTOs = Mapper.Map<List<GameDTO>>(games);

            return gameDTOs;
        }


        public IList<GenreDTO> GetGenres()
        {
            var genre = _database.Genre.GetAll().ToList();
            var genreDTOs = Mapper.Map<IList<Genre>, IList<GenreDTO>>(genre);
            return genreDTOs;
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
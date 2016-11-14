using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Interfaces;
using GameStore.WEB.Models;

namespace Task_WEB.Controllers
{
    public class GamesController : Controller
    {
        readonly IGameStoreService _gameStoreService;// = new GameStoreService();

        public GamesController(IGameStoreService gameStoreService)
        {
            _gameStoreService = gameStoreService;
        }
        
        public ActionResult Index()
        { 
            return View();
        }
        // GET: Games
        public ActionResult GetGames()
        {
            List<GameDTO> gameDTOs = _gameStoreService.GetGames().ToList();

            return PartialView("_Games", gameDTOs);
        }
        [HttpPost]
        public ActionResult FilterGames(int[] genresId )
        {
            List<GameDTO> gameDTOs;
            List<int> genresIds=new List<int>();
            if (genresId != null)
            {
                foreach (var genre in genresId)
                {
                    genresIds.Add(genre);
                }
                gameDTOs = _gameStoreService.GetGames(genresIds).ToList();
                return PartialView("_Games", gameDTOs);
            }

            gameDTOs = _gameStoreService.GetGames().ToList();
            return PartialView("_Games", gameDTOs);
        }
        // GET: Game/{key}
        [HttpGet]
        public ActionResult Game(string key)
        {
            GameDTO gameDTO = _gameStoreService.GetGameByKey(key);
            return View(gameDTO);
        }

        // GET: Home/CreateGame
        public ActionResult CreateGame()
        {
            GameDTO game=new GameDTO();
            //game.Genres=_
            return View();
        }

        // POST: Home/CreateGame
        [HttpPost]
        public ActionResult CreateGame(GameDTO gameModel)
        {
            if (ModelState.IsValid)
            {
                GameDTO GameDTO = new GameDTO
                {
                    Name = gameModel.Name,
                    Key = gameModel.Key,
                    Description = gameModel.Description
                };
                _gameStoreService.CreateGame(GameDTO);
            }
            return RedirectToAction("Index");
        }
        // POST: Home/EditGame
        [HttpPost]
        public ActionResult EditGame(AddGameModel gameModel)
        {
            if (ModelState.IsValid)
            {
                GameDTO GameDTO = new GameDTO
                {
                    Id = gameModel.Id,
                    Name = gameModel.Name,
                    Key = gameModel.Key,
                    Description = gameModel.Description
                };
                _gameStoreService.EditGame(GameDTO);
            }

            return RedirectToAction("Games");
        }
        // GET: Home/DownloadGame/{key}
        public FileResult DownloadGame(string gameKey)
        {
            if (_gameStoreService.GetGameByKey(gameKey) != null)
            {
                string file_path = Server.MapPath("~/Files/" + gameKey + ".txt");
                string file_type = "application/txt";
                return File(file_path, file_type);
            }
            throw new ArgumentException();
        }
        // POST: Home/DeleteGame/{id}
        [HttpPost]
        public ActionResult DeleteGame(int id)
        {
            _gameStoreService.DeleteGame(id);
            return RedirectToAction("Games");
        }


        public ActionResult GetGameFilters()
        {
            var genre = _gameStoreService.GetGenres();
            var genreModels = Mapper.Map<IList<GenreDTO>, IList<GenreModelViewForFilter>>(genre);
            return PartialView("_GenreList", genreModels);

        }
    }
}

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
        // GET: Games
        public ActionResult Index()
        {
            List<GameDTO> gameDTOs = _gameStoreService.GetGames().ToList();
            return View(gameDTOs);
        }
        [HttpPost]
        public ActionResult Index(List<int> genresId )
        {
           ////////////////////////////////////////////////////////
            List<GameDTO> gameDTOs = _gameStoreService.GetGames().ToList();
            return View(gameDTOs);
        }
        //public ActionResult Games()
        //{
        //    List<GameDTO> gameDTOs = _gameStoreService.GetGames().ToList();
        //    return Json(gameDTOs, JsonRequestBehavior.AllowGet);
        //}
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
            return View();
        }

        // POST: Home/CreateGame
        [HttpPost]
        public ActionResult CreateGame(AddGameModel gameModel)
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
            return RedirectToAction("Games");
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
           //var genreModels = Mapper.Map<IList<GenreDTO>, IList<GenreModel>>(genre);
            return PartialView("_GenreList", genre);
            
            //throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore.BLL.DTO;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Services;
using GameStore.WEB.Models;

namespace GameStore.WEB.Controllers
{
    public class HomeController : Controller
    {
        readonly IGameStoreService _gameStoreService;// = new GameStoreService();

        public HomeController(IGameStoreService gameStoreService)
        {
            _gameStoreService = gameStoreService;
        }


        public ActionResult Index()
        {
            return View();
        }
        // GET: Games
        public ActionResult Games()
        {
            List<GameDTO> gameDTOs = _gameStoreService.GetGames().ToList();
            return Json(gameDTOs, JsonRequestBehavior.AllowGet);
        }
        // GET: Game/{key}
        [HttpGet]
        public ActionResult Game(string key)
        {
            GameDTO gameDTO = _gameStoreService.GetGameByKey(key);
            return Json(gameDTO, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public ActionResult AddComment(AddCommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                CommentDTO commentDTO = new CommentDTO
                {
                    Name = commentModel.Name,
                    Body = commentModel.Body,
                    //  ParentId = _gameStoreService. commentModel.ParentName// добавить обработку через ID
                    ParentName = commentModel.ParentName,
                    GameId = commentModel.GameId
                };
                _gameStoreService.AddComment(commentDTO);
            }

            return Json(_gameStoreService.GetCommentsByGameKey("first"), JsonRequestBehavior.AllowGet);
        }

        // GET: Home/GameComments/{key}
        public ActionResult GameComments(string gameKey)
        {
            if (_gameStoreService.GetGameByKey(gameKey) != null)
            {
                IList<CommentDTO> commensDTO = _gameStoreService.GetCommentsByGameKey(gameKey);

                return Json(commensDTO, JsonRequestBehavior.AllowGet);
            }
            throw new ArgumentException();
        }

        // GET: Home/Delete/{id}
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/DeleteGame/{id}
        [HttpPost]
        public ActionResult DeleteGame(int id)
        {
            _gameStoreService.DeleteGame(id);
            return RedirectToAction("Games");
        }
    }
}

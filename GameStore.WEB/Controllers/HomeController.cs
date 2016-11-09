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



        public ActionResult GetBaners()
        {
            return PartialView("_Banners");
        }
    }
}

using NUnit.Framework;
using Task1_BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Components.DictionaryAdapter;
using Moq;
using Task1_BLL.Configuration;
using Task1_BLL.DTO;
using Task1_DAL.Entities;
using Task1_DAL.Intefaces;
using Task1_DAL.Repositories;


namespace Task1_BLL.Services.Tests
{
    [TestFixture]
    public class GameStoreServiceTests
    {
        private Mock<IRepository<Game>> _mockGameRepository;
        private Mock<IRepository<Genre>> _mockGenreRepository;
        private Mock<IUnitOfWork> _mockUow;
        private GameStoreService _gameStoreService;



        [SetUp]
        public void Init()
        {

            Mapper.Initialize(x => x.AddProfile(new MappingBLLProfile()));

            _mockGameRepository = new Mock<IRepository<Game>>();
            _mockUow = new Mock<IUnitOfWork>();
            _gameStoreService = new GameStoreService(_mockUow.Object);
            _mockGenreRepository = new Mock<IRepository<Genre>>();
        }

        #region comm

        // Arrange
        //var mock = new Mock<IRepository>();
        //mock.Setup(a => a.GetComputerList()).Returns(new List<Computer>());
        //HomeController controller = new HomeController(mock.Object);

        //// Act
        //ViewResult result = controller.Index() as ViewResult;

        //// Assert
        //Assert.IsNotNull(result.Model);
        //-------------------------------


        //Arrange
        //var mokUOW = new Mock<IUnitOfWork>();
        //mokUOW.Setup(m => m.Game.GetAll()).;
        //GameStoreService gameStoreService = new GameStoreService(mokUOW.Object);
        //Act

        //Assert
        //Assert.Fail();

        #endregion
        //  _mockGameRepository.Verify(x => x.GetAll(), Times.Once);

        [Test]
        public void GetGames_GettingGames_ReturnExpectedGames()
        {
            // Arrange
            var expectedGames = new List<Game>
            {
                new Game {Id = 1, Name = "Heroes", Key = "Heroes" },
                new Game {Id = 2, Name = "NFS", Key = "NFS" }
            };

            _mockGameRepository.Setup(x => x.GetAll()).Returns(expectedGames);
            _mockUow.Setup(x => x.Game).Returns(_mockGameRepository.Object);

            // Act
            var results = _gameStoreService.GetGames();


            //Assert
            Assert.AreEqual(results.Count, 2);
            foreach (var game in results)
            {
                Assert.IsTrue(expectedGames.FirstOrDefault(x => x.Id == game.Id) != null);
            }

        }

        [Test]
        public void GetGames_GettingEmptyGameList_ReturnEmptyGameList()
        {
            // Arrange
            //var expectedGames = new List<Game>();
            // _mockGameRepository.Setup(x => x.GetAll()).Returns(expectedGames);
            _mockUow.Setup(x => x.Game).Returns(_mockGameRepository.Object);

            // Act
            var results = _gameStoreService.GetGames();

            //Assert
            Assert.AreEqual(results.Count, 0);
        }

        [Test]
        public void GetGameByKey_UseExistKey_ReturnGameWithThisKey()
        {
            // Arrange
            var games = new List<Game>
            {
                new Game {Id = 1, Name = "Heroes", Key = "Heroes" },
                new Game {Id = 2, Name = "NFS", Key = "NFS" }
            };
            string key = "NFS";

            _mockGameRepository.Setup(x => x.GetAll()).Returns(games);
            _mockUow.Setup(x => x.Game).Returns(_mockGameRepository.Object);

            // Act
            var results = _gameStoreService.GetGameByKey(key);


            //Assert
            Assert.AreEqual(results.Key, key);

        }
        [Test]
        public void GetGameByKey_UseIncorrectKey_ReturnEmptyGameList()
        {
            // Arrange
            var games = new List<Game>
            {
                new Game {Id = 1, Name = "Heroes", Key = "Heroes" },
                new Game {Id = 2, Name = "NFS", Key = "NFS" }
            };
            string key = "text";

            _mockGameRepository.Setup(x => x.GetAll()).Returns(games);
            _mockUow.Setup(x => x.Game).Returns(_mockGameRepository.Object);

            // Act
            var results = _gameStoreService.GetGameByKey(key);


            //Assert
            Assert.AreEqual(results, null);

        }

        [Test()]
        public void CreateGameTest()//Rename
        {
            var newGameDTO = new GameDTO();

            _mockUow.Setup(x => x.Game).Returns(_mockGameRepository.Object);

            _gameStoreService.CreateGame(newGameDTO);

            _mockGameRepository.Verify(x => x.Create(It.IsAny<Game>()), Times.Once);

        }

        [Test]
        public void EditGameTest()//Rename
        {
            var newGameDTO = new GameDTO();
            _mockUow.Setup(x => x.Game).Returns(_mockGameRepository.Object);

            _gameStoreService.EditGame(newGameDTO);

            _mockGameRepository.Verify(x => x.Update(It.IsAny<Game>()), Times.Once);
        }

        [Test()]
        public void DeleteGameTest()//Rename
        {
            _mockUow.Setup(x => x.Game).Returns(_mockGameRepository.Object);

            _gameStoreService.DeleteGame(It.IsAny<int>());

            _mockGameRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GetGameByGenre_GettingGameByCorrectGenreId_ResultGameList()
        {
            // Arrange
            int genreId = 2;
            var games = new List<Game>
            {
                new Game {Id = 1, Name = "Heroes", Key = "Heroes"},
                new Game {Id = 2, Name = "NFS", Key = "NFS"}
            };
            Genre Action = new Genre {Id=1, Name = "action"};
            Genre RPG = new Genre { Id =2, Name = "RPG",Games = games };
            Genre Racing = new Genre { Id = 3, Name = "Racing" };
            IEnumerable<Genre> GenreList = new List<Genre>
            {
                Action,
                RPG,
                Racing
            };
            List<GameDTO> expectedGameList = new List<GameDTO>
            {
                new GameDTO {Id = 1, Name = "Heroes", Key = "Heroes" },
                new GameDTO {Id = 2, Name = "NFS", Key = "NFS"}
            };

            _mockGenreRepository.Setup(x => x.GetAll()).Returns(GenreList);
            _mockUow.Setup(x => x.Genre).Returns(_mockGenreRepository.Object);

            // Act
            var results = _gameStoreService.GetGameByGenre(genreId);


            //Assert
            Assert.AreEqual(results.Count, 2);
            foreach (var game in results)
            {
                Assert.IsTrue(expectedGameList.FirstOrDefault(x => x.Name == game.Name) != null);
            }
        }
    }
}
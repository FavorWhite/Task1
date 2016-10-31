using System.Collections.Generic;
using Task1_BLL.DTO;

namespace Task1_BLL.Interfaces
{
    public interface IGameStoreService
    {
        void CreateGame(GameDTO gameDTO);
        void EditGame(GameDTO gameDTO);
        void DeleteGame(int id);
        GameDTO GetGameByKey(string key);
        IList<GameDTO> GetGames();
        void AddComment(CommentDTO commentDTO);
        IList<CommentDTO> GetCommentsByGameKey(string gameKey);
        IList<GameDTO> GetGameByGenre(int genreId);
        IList<GameDTO> GetGameByPlatformType(int platformTypeId);
        void Dispose();
    }
}
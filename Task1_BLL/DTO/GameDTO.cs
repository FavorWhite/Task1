using System.Collections.Generic;

namespace Task1_BLL.DTO
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public  ICollection<CommentDTO> Comments { get; set; }
        //public ICollection<GenreDTO> Genres { get; set; }
        //public  ICollection<PlatformTypeDTO> PlatformTypes { get; set; }

        //public GameDTO()
        //{
        //    Genres = new List<GenreDTO>();
        //    PlatformTypes = new List<PlatformTypeDTO>();
        //    Comments = new List<CommentDTO>();
        //}
    }
}
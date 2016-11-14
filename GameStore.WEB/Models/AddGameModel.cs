using System.Collections.Generic;
using GameStore.BLL.DTO;

namespace GameStore.WEB.Models
{
    public class AddGameModel
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<CommentDTO> Comments { get; set; }
        public ICollection<GenreDTO> Genres { get; set; }
        public ICollection<PlatformTypeDTO> PlatformTypes { get; set; }


    }
}
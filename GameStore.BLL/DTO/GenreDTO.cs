using System.Collections.Generic;
using GameStore.DAL.Entities;

namespace GameStore.BLL.DTO
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<GenreDTO> SubGenres{ get; set; }
        public virtual ICollection<GameDTO> Games { get; set; }
    }
}
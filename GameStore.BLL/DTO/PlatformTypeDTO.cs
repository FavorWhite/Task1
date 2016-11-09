using System.Collections.Generic;

namespace GameStore.BLL.DTO
{
    public class PlatformTypeDTO
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public virtual ICollection<GameDTO> Games { get; set; }
    }
}
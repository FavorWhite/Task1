using System.Collections.Generic;

namespace GameStore.WEB.Models
{
    public class GenreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
      //  public virtual ICollection<GenreModel> SubGenres { get; set; }
    }
}
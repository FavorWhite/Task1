using System.Collections.Generic;

namespace GameStore.WEB.Models
{
    public class GenreModelViewForFilter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public  bool IsSelected { get; set; }
        public virtual ICollection<GenreModelViewForFilter> SubGenres { get; set; }
    }
}
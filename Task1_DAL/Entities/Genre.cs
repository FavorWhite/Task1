using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_DAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Genre Parent { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public Genre()
        {
            Games = new List<Game>();
        }
    }
}

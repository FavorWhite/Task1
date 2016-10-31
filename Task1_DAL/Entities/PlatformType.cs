using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_DAL.Entities
{
    public class PlatformType
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Type { get; set; }
        public virtual ICollection<Game> Games { get; set; }

        public PlatformType()
        {
            Games = new List<Game>();
            
        }
    }
}

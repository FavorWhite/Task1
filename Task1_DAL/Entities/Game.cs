using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_DAL.Entities
{
    public class Game
    {
        public int Id { get; set; }
        
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<PlatformType> PlatformTypes { get; set; }

        public Game()
        {
            Genres = new List<Genre>();
            PlatformTypes=new List<PlatformType>();
            Comments = new List<Comment>();
        }

    }
}

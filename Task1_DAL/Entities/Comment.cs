using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Body { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
        public string ParentName { get; set; }
        public int? ParentId { get; set; }
        public Comment Parent { get; set; }

        public virtual ICollection<Comment> CommentResponses { get; set; }

        public Comment()
        {
            CommentResponses = new List<Comment>();
        }

    }
}

using System.Collections.Generic;

namespace Task1_BLL.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Body { get; set; }

        public int GameId { get; set; }
        public string ParentName { get; set; }
        public int ParentId { get; set; }
        public virtual ICollection<CommentDTO> CommentResponses { get; set; }
    }
}
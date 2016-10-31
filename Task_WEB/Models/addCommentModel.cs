using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_WEB.Models
{
    public class AddCommentModel
    {
        public string Name { get; set; }
        public string Body { get; set; }

        public int GameId { get; set; }
        public string ParentName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class CommentModel
    {
        public string AuthorLogin { get; set; }

        public int Id { get; set; }

        public DateTime DateOfCreate { get; set; }

        public int ProductId { get; set; }

        public string Text { get; set; }

    }
}
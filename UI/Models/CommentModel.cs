using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class CommentModel
    {
        public string AuthorLogin { get; set; }

        public int Id { get; set; }

        public DateTime DateOfCreate { get; set; }

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Напишите что-нибудь в отзыве")]
        public string Text { get; set; }

        public int Rating { get; set; }

    }
}
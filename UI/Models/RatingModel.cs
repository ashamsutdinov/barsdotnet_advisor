using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class RatingModel
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }
    }
}
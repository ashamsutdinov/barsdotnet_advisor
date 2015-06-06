using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Info { get; set; }

        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public DateTime DateOfCreate { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }
    }
}
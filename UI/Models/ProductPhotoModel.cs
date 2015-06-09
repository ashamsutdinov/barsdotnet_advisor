using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class ProductPhotoModel
    {
        public int Id { get; set; }

        public byte[] Photo { get; set; }

        public int ProductId { get; set; }

        public string MimeTypePhoto { get; set; }

    }
}
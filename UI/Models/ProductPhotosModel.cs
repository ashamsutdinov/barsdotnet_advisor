﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class ProductPhotosModel
    {
        public int Id { get; set; }

        public byte[] Photo { get; set; }

        public int ProductId { get; set; }

        public string MimeType { get; set; }

    }
}
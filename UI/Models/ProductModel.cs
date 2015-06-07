using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Advisor.Dal.Domain;
using Advisor.Data;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string UserLogin { get; set; }

        [Required(ErrorMessage = "Укажите название услуги")]
        public string Name { get; set; }

        public string Info { get; set; }

        public int MinValue { get; set; }

        
        public int MaxValue { get; set; }

        public DateTime DateOfCreate { get; set; }

        [Required(ErrorMessage = "Укажите категорию")]
        public string Category { get; set; }

        public List<int> PhotosId {get;set;}//ссылки на фото

    }
}
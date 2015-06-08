using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advisor.Dal;
using Advisor.Dal.Domain;

namespace Advisor.Data
{
    public class ProductPhotoManager:IProductPhotoManager
    {
        public IQueryable<ProductPhoto> GetPhotos(int productId)
        {       
            //взять фотографии
            using (var da = new ProductPhotoDa())
            {
                IQueryable <ProductPhoto> Photos= da.Select(p=>p.ProductId==productId);
                return Photos;
            }

        }
        public ProductPhoto Add(byte[] photo, string mimetype, int productId)
        {
            using (var da = new ProductPhotoDa())
            {
                ProductPhoto pr=new ProductPhoto();
                pr.MimeType = mimetype;
                pr.Photo = photo;
                pr.ProductId = productId;
                return da.Save(pr); 
            }
        }
        public ProductPhoto Get(int photoId)
        {
            using (var da = new ProductPhotoDa())
            {
                return da.GetById(photoId);
            }
        }
    }
}

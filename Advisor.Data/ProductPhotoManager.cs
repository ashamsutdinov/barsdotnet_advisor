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
        public IEnumerable<ProductPhoto> GetPhotos(int productId)
        {       
            //взять фотографии
            using (var da = new ProductPhotoDa())
            {     
                return da.Select(p => p.ProductId == productId);
            }

        }
        public ProductPhoto Add(byte[] photo, string mimetypephoto, int productId)
        {
            using (var da = new ProductPhotoDa())
            {
                ProductPhoto pr=new ProductPhoto();
                pr.MimeTypePhoto = mimetypephoto;
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

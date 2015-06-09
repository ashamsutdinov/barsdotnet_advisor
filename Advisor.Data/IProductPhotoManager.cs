using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advisor.Dal.Domain;

namespace Advisor.Data
{
    public interface IProductPhotoManager
    {
        IEnumerable<ProductPhoto> GetPhotos(int productId);
        //взять фотографии
        ProductPhoto Add( byte[] photo, string mimetypephoto, int productId);
        ProductPhoto Get(int photoId);
    }
}

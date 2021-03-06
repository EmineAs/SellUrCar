using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetList();
        List<ImageFile> GetListByAdID(int id);
        void ImageAddBL(ImageFile image);
        void ImageDelete(List<ImageFile> image);
    }
}

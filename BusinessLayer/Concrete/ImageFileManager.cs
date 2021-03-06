using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }
        
        public List<ImageFile> GetList()
        {
            return _imageFileDal.List();
        }

        public List<ImageFile> GetListByAdID(int id)
        {
            return _imageFileDal.List(x => x.AdID == id);

        }

        public void ImageAddBL(ImageFile image)
        {
            _imageFileDal.Insert(image);

        }

        public void ImageDelete(List<ImageFile> image)
        {
            foreach (var item in image)
            {
                _imageFileDal.Delete(item);
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void ColorAddBL(Color color)
        {
            _colorDal.Insert(color);
        }

        public void ColorDelete(Color color)
        {
            _colorDal.Delete(color);
        }

        public void ColorUpdate(Color color)
        {
            _colorDal.Update(color);
        }

        public Color GetByID(int id)
        {
            return _colorDal.Get(x => x.ColorID == id);
        }

        public List<Color> GetList()
        {
            return _colorDal.List();
        }


    }
}

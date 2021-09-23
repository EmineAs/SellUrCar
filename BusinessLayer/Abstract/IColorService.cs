using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IColorService
    {
        List<Color> GetList();

        void ColorAddBL(Color color);

        Color GetByID(int id);

        void ColorDelete(Color color);

        void ColorUpdate(Color color);

    }
}

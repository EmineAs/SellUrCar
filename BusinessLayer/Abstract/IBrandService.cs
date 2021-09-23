using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetList();

        void BrandAddBL(Brand brand);

        Brand GetByID(int id);

        void BrandDelete(Brand brand);

        void BrandUpdate(Brand brand);

    }
}

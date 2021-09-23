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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void BrandAddBL(Brand brand)
        {
            _brandDal.Insert(brand);
        }

        public void BrandDelete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public void BrandUpdate(Brand brand)
        {
            _brandDal.Update(brand);
        }

        public Brand GetByID(int id)
        {
            return _brandDal.Get(x => x.BrandID == id);
        }

        public List<Brand> GetList()
        {
            return _brandDal.List();
        }

    }
}

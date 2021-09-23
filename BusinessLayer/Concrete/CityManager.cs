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
    public class CityManager : ICityService
    {
        ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public void CityAddBL(City city)
        {
            _cityDal.Insert(city);
        }

        public void CityDelete(City city)
        {
            _cityDal.Delete(city);
        }

        public void CityUpdate(City city)
        {
            _cityDal.Update(city);
        }

        public City GetByID(int id)
        {
            return _cityDal.Get(x => x.CityID == id);
        }

        public List<City> GetList()
        {
            return _cityDal.List();
        }


    }
}

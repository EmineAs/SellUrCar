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
    public class DistrictManager : IDistrictService
    {
        IDistrictDal _districtDal;

        public DistrictManager(IDistrictDal districtDal)
        {
            _districtDal = districtDal;
        }

        public void DistrictAddBL(District district)
        {
            _districtDal.Insert(district);
        }

        public void DistrictDelete(District district)
        {
            _districtDal.Delete(district);
        }

        public void DistrictUpdate(District district)
        {
            _districtDal.Update(district);
        }

        public District GetByID(int id)
        {
            return _districtDal.Get(x => x.DistrictID == id);
        }

        public List<District> GetList()
        {
            return _districtDal.List();
        }

        public List<District> GetListByCityID(int id)
        {
            return _districtDal.List(x => x.CityID == id);
        }
    }
}

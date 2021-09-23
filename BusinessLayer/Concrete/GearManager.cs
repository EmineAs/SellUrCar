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
    public class GearManager : IGearService
    {
        IGearDal _gearDal;

        public GearManager(IGearDal gearDal)
        {
            _gearDal = gearDal;
        }

        public void GearAddBL(Gear gear)
        {
            _gearDal.Insert(gear);
        }

        public void GearDelete(Gear gear)
        {
            _gearDal.Delete(gear);
        }

        public void GearUpdate(Gear gear)
        {
            _gearDal.Update(gear);
        }

        public Gear GetByID(int id)
        {
            return _gearDal.Get(x => x.GearID == id);
        }

        public List<Gear> GetList()
        {
            return _gearDal.List();
        }


    }
}

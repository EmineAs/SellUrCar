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
    public class FuelManager : IFuelService
    {
        IFuelDal _fuelDal;

        public FuelManager(IFuelDal fuelDal)
        {
            _fuelDal = fuelDal;
        }

        public void FuelAddBL(Fuel fuel)
        {
            _fuelDal.Insert(fuel);
        }

        public void FuelDelete(Fuel fuel)
        {
            _fuelDal.Delete(fuel);
        }

        public void FuelUpdate(Fuel fuel)
        {
            _fuelDal.Update(fuel);
        }

        public Fuel GetByID(int id)
        {
            return _fuelDal.Get(x => x.FuelID == id);
        }

        public List<Fuel> GetList()
        {
            return _fuelDal.List();
        }


    }
}

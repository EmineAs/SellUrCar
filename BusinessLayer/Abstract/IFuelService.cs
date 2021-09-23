using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IFuelService
    {
        List<Fuel> GetList();

        void FuelAddBL(Fuel fuel);

        Fuel GetByID(int id);

        void FuelDelete(Fuel fuel);

        void FuelUpdate(Fuel fuel);

    }
}

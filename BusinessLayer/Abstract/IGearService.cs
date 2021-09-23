using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IGearService
    {
        List<Gear> GetList();

        void GearAddBL(Gear gear);

        Gear GetByID(int id);

        void GearDelete(Gear gear);

        void GearUpdate(Gear gear);

    }
}

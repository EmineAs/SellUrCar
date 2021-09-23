using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IDistrictService
    {
        List<District> GetList();

        void DistrictAddBL(District district);

        District GetByID(int id);

        void DistrictDelete(District district);

        void DistrictUpdate(District district);

        List<District> GetListByCityID(int id);


    }
}

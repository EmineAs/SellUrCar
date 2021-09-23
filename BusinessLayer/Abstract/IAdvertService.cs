using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IAdvertService
    {
        List<Advert> GetList();

        void AdvertAddBL(Advert advert);

        Advert GetByID(int id);

        void AdvertDelete(Advert advert);

        void AdvertUpdate(Advert advert);

    }
}

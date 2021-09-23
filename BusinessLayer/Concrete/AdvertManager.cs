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
    public class AdvertManager : IAdvertService
    {
        IAdvertDal _advertDal;

        public AdvertManager(IAdvertDal advertDal)
        {
            _advertDal = advertDal;
        }

        public void AdvertAddBL(Advert advert)
        {
            _advertDal.Insert(advert);
        }

        public void AdvertDelete(Advert advert)
        {
            _advertDal.Delete(advert);
        }

        public void AdvertUpdate(Advert advert)
        {
            _advertDal.Update(advert);
        }

        public Advert GetByID(int id)
        {
            return _advertDal.Get(x => x.AdID == id);
        }

        public List<Advert> GetList()
        {
            return _advertDal.List();
        }


    }
}

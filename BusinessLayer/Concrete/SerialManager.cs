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
    public class SerialManager : ISerialService
    {
        ISerialDal _serialDal;

        public SerialManager(ISerialDal serialDal)
        {
            _serialDal = serialDal;
        }

        public void SerialAddBL(Serial serial)
        {
            _serialDal.Insert(serial);
        }

        public void SerialDelete(Serial serial)
        {
            _serialDal.Delete(serial);
        }

        public void SerialUpdate(Serial serial)
        {
            _serialDal.Update(serial);
        }

        public Serial GetByID(int id)
        {
            return _serialDal.Get(x => x.SerialID == id);
        }

        public List<Serial> GetList()
        {
            return _serialDal.List();
        }

        public List<Serial> GetListByBrandID(int id)
        {
            return _serialDal.List(x => x.BrandID == id);

        }
    }
}

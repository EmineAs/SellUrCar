using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ISerialService
    {
        List<Serial> GetList();
        void SerialAddBL(Serial serial);
        Serial GetByID(int id);
        void SerialDelete(Serial serial);
        void SerialUpdate(Serial serial);
        List<Serial> GetListByBrandID(int id);
    }
}

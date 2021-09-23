using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<User> GetList();

        List<User> GetListActive();
        List<User> GetListPassive();

        void UserAddBL(User user);

        User GetByID(int id);

        void UserDelete(User user);

        void UserUpdate(User user);

    }
}

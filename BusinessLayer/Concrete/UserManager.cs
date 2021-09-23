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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void UserAddBL(User user)
        {
            _userDal.Insert(user);
        }

        public void UserDelete(User user)
        {
            _userDal.Delete(user);
        }

        public void UserUpdate(User user)
        {
            _userDal.Update(user);
        }

        public User GetByID(int id)
        {
            return _userDal.Get(x => x.UserID == id);
        }

        public List<User> GetList()
        {
            return _userDal.List();
        }

        public List<User> GetListActive()
        {
            return _userDal.List(x=>x.UserStatus==true);
        }

        public List<User> GetListPassive()
        {
            return _userDal.List(x => x.UserStatus == false);
        }
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class UserRegisterManager : IUserRegisterService
    {
        IUserDal _userDal;

        public UserRegisterManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetUserMail(string mail)
        {
            return _userDal.Get(x => x.UserMail == mail);
        }
    }
}

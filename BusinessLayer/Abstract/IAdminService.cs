﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();

        void AdminAddBL(Admin admin);

        string GetHash(string data);

        void AdminDelete(Admin admin);

        void AdminUpdate(Admin admin);
    }
}

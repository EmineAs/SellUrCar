using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IModelService
    {
        List<Model> GetList();
        void ModelAddBL(Model model);
        Model GetByID(int id);
        void ModelDelete(Model model);
        void ModelUpdate(Model model);
        List<Model> GetListBySerialID(int id);


    }
}

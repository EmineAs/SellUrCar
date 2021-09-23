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
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public void ModelAddBL(Model model)
        {
            _modelDal.Insert(model);
        }

        public void ModelDelete(Model model)
        {
            _modelDal.Delete(model);
        }

        public void ModelUpdate(Model model)
        {
            _modelDal.Update(model);
        }

        public Model GetByID(int id)
        {
            return _modelDal.Get(x => x.ModelID == id);
        }

        public List<Model> GetList()
        {
            return _modelDal.List();
        }

        public List<Model> GetListByBrandID(int id)
        {
            return _modelDal.List(x => x.BrandID == id);
        }


    }
}

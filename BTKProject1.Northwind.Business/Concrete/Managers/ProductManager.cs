using BTKProject1.Core.CrossCuttingConcerns.Validation.FluentValidation;
using BTKProject1.Northwind.Business.Abstract;
using BTKProject1.Northwind.Business.ValidationRules.FluentValidation;
using BTKProject1.Northwind.DataAccess.Abstract;
using BTKProject1.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKProject1.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidate(typeof(ProductValidator))]
        public Product Add(Product product)
        {

            return _productDal.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }


        [FluentValidate(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
    }
}

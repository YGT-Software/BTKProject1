using BTKProject1.Core.Aspects.Postsharp;
using BTKProject1.Core.Aspects.Postsharp.CacheAspects;
using BTKProject1.Core.Aspects.Postsharp.TransactionAspects;
using BTKProject1.Core.Aspects.Postsharp.ValidationAspects;
using BTKProject1.Core.CrossCuttingConcerns.Caching.Microsoft;
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
using System.Transactions;

namespace BTKProject1.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {

            return _productDal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            //BusinessCodes
            _productDal.Update(product2);

        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
    }
}

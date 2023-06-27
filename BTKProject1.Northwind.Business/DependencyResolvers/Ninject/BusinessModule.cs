using BTKProject1.Core.DataAccess;
using BTKProject1.Core.DataAccess.EntityFramework;
using BTKProject1.Core.DataAccess.NHibernate;
using BTKProject1.Northwind.Business.Abstract;
using BTKProject1.Northwind.Business.Concrete.Managers;
using BTKProject1.Northwind.DataAccess.Abstract;
using BTKProject1.Northwind.DataAccess.Concrete.EntityFramework;
using BTKProject1.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKProject1.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}

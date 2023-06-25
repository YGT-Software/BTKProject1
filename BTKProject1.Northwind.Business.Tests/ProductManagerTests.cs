using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using BTKProject1.Northwind.DataAccess.Abstract;
using BTKProject1.Northwind.Business.Concrete.Managers;
using FluentValidation;

namespace BTKProject1.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);

            productManager.Add(new Product());
        }
    }
}

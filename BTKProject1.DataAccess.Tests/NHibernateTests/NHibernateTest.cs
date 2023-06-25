﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BTKProject1.Northwind.DataAccess.Concrete.NHibernateTest;


[TestClass]
public class NHibernateTest
{
    [TestMethod]
    public void Get_all_returns_all_products()
    {
        NhProductDal productDal = new NhProductDal(SqlServerHelper());
        var result = productDal.GetList();
        Assert.AreEqual(85, result.Count);

    }


    [TestMethod]
    public void Get_all_with_parameter_returns_filtered_products()
    {
        NhProductDal productDal = new NhProductDal(SqlServerHelper());
        var result = productDal.GetList(p => p.ProductName.Contains("ab"));
        Assert.AreEqual(4, result.Count);

    }
}

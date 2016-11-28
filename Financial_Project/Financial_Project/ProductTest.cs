using System;
using System.Collections.Generic;
using FinancialReports.Entities;
using FinancialReports.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialReports
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void TestCanGetProductsOnlySoldInLastWeek()
        {
            ProductFactory productFactory = new ProductFactory();
            DateTime Today = DateTime.Today;
            DateTime OneWeekAgo = Today.AddDays(-7);
            List<Product> weeklyProducts = productFactory.getProductsWithinTime(7);
            if (weeklyProducts.Count == 0)
            {
                Assert.AreEqual(weeklyProducts.Count, 0);
            } else {
                for (var i = 0; i < weeklyProducts.Count; i++)
                {
                    Assert.IsTrue(weeklyProducts[i].orderDate > OneWeekAgo);
                    Assert.IsTrue(weeklyProducts[i].orderDate <= Today);

                }
            }
        }
        [TestMethod]
        public void TestCanGetProductsOnlySoldInLastMonth()
        {
            ProductFactory productFactory = new ProductFactory();
            DateTime Today = DateTime.Today;
            DateTime OneMonthAgo = Today.AddDays(-30);
            List<Product> monthlyProducts = productFactory.getProductsWithinTime(30);
            if (monthlyProducts.Count == 0)
            {
                Assert.AreEqual(monthlyProducts.Count, 0);
            }
            else
            {
                for (var i = 0; i < monthlyProducts.Count; i++)
                {
                    Assert.IsTrue(monthlyProducts[i].orderDate > OneMonthAgo);
                    Assert.IsTrue(monthlyProducts[i].orderDate <= Today);
                }
            }
        }
        [TestMethod]
        public void TestCanGetProductsOnlySoldInLastQuarter()
        {
            ProductFactory productFactory = new ProductFactory();
            DateTime Today = DateTime.Today;
            DateTime OneQuarterAgo = Today.AddDays(-90);
            List<Product> quarterlyProducts = productFactory.getProductsWithinTime(90);
            if (quarterlyProducts.Count == 0)
            {
                Assert.AreEqual(quarterlyProducts.Count, 0);
            }
            else
            {
                for (var i = 0; i < quarterlyProducts.Count; i++)
                {
                    Assert.IsTrue(quarterlyProducts[i].orderDate > OneQuarterAgo);
                    Assert.IsTrue(quarterlyProducts[i].orderDate <= Today);
                }
            }
        }
        [TestMethod]
        public void TestCanGetRevenueForProductsInDatabase()
        {
            ProductFactory productFactory = new ProductFactory();
            List<Product> productList = productFactory.getProductRevenue();
            for (var i=0; i<productList.Count; i++)
            {
                Assert.IsTrue(productList[i].revenue > 0);
            }
        }
        [TestMethod]
        public void TestCanGetRevenueForCustomersInDatabase()
        {
            CustomerFactory customerFactory = new CustomerFactory();
            List<Customer> customerList = customerFactory.getCustomerRevenue();
            for (var i = 0; i < customerList.Count; i++)
            {
                Assert.IsTrue(customerList[i].revenue > 0);
            }
        }
    }
}

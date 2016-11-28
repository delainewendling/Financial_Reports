using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using FinancialReports.Entities;
using FinancialReports.Data;

namespace FinancialReports.Factories
{
    //The purpose of this class is to query the database for each product sold in a variable amount of time as well as to get the amount of revenue gained from each product. 
    public class ProductFactory
    {
        //This method takes in an integer as an argument. This integer specifies the number of days worth of sales to query the database.
        public List<Product> getProductsWithinTime(int days)
        {
            List<Product> productList = new List<Product>();
            BangazonWebConnection conn = new BangazonWebConnection();
            string query = $"Select P.ProductId, P.Name, P.Price, O.DateCompleted From Product P Join LineItem L On P.ProductId = L.ProductId Join 'Order' O on O.OrderId = L.OrderId WHERE O.DateCompleted >= datetime('now', '-{days} days') AND O.DateCompleted <= datetime('now', 'localtime') Order By upper(P.Name)";
            conn.execute(query, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    productList.Add(new Product
                    {
                        productId = reader.GetInt32(0),
                        productName = reader[1].ToString(),
                        productPrice = reader.GetDouble(2),
                        orderDate = reader.GetDateTime(3)
                    });
                }
                reader.Close();
            });
            return productList;

        }
        public List<Product> getProductRevenue()
        {
            List<Product> productList = new List<Product>();
            BangazonWebConnection conn = new BangazonWebConnection();
            string query = "Select P.Name, Sum(P.Price) From Product P Join LineItem L On P.ProductId = L.ProductId Join 'Order' O on O.OrderId = L.OrderId Group By P.Name Order By upper(P.Name)";
            conn.execute(query, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    productList.Add(new Product
                    {
                        productName = reader[0].ToString(),
                        revenue = reader.GetDouble(1)
                    });
                }
                reader.Close();
            });
            return productList;

        }
    }
}


using System.Collections.Generic;
using FinancialReports.Entities;
using FinancialReports.Data;
using Microsoft.Data.Sqlite;

namespace FinancialReports.Factories
{
    public class CustomerFactory
    {
        public List<Customer> getCustomerRevenue()
        {
            List<Customer> productList = new List<Customer>();
            BangazonWebConnection conn = new BangazonWebConnection();
            string query = $"Select C.FirstName, C.LastName, Sum(P.Price) From Customer C Join 'Order' O on C.CustomerId = O.CustomerId Join LineItem L on L.OrderId = O.OrderId Join Product P on P.ProductId = L.ProductId Group By C.FirstName, C.LastName Order By Upper(C.LastName)";
            conn.execute(query, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    productList.Add(new Customer
                    {
                        firstName = reader[0].ToString(),
                        lastName = reader[1].ToString(),
                        revenue = reader.GetDouble(2)
                    });
                }
                reader.Close();
            });
            return productList;
        }
    }
}

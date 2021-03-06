﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialReports.Factories;
using FinancialReports.Entities;

namespace FinancialReports.Actions
{
    public class RevenuePerProduct
    {
        public static void ReadInput()
        {
            ProductFactory productFactory = new ProductFactory();
            List<Product> productRevenue = productFactory.getProductRevenue();
            Console.WriteLine("PRODUCT REVENUE REPORT");
            Console.WriteLine("Product\t\t\tRevenue");
            Console.WriteLine("------------------------------");
            for (var i = 0; i < productRevenue.Count; i++)
            {
                StringBuilder ProductString = new StringBuilder($"{productRevenue[i].productName}\t");
                string Price = string.Format("{0:C}", productRevenue[i].revenue);
                ProductString.Append(Price);
                Console.WriteLine(ProductString);
            }
            Console.WriteLine("Press any key to go back to Main Menu");
            Console.ReadLine();
        }
    }
}

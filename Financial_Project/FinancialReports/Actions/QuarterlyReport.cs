using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialReports.Factories;
using FinancialReports.Entities;

namespace FinancialReports.Actions
{
    public class QuarterlyReport
    {
        public static void ReadInput()
        {
            ProductFactory productFactory = new ProductFactory();
            List<Product> quarterlyProducts = productFactory.getProductsWithinTime(90);
            Console.WriteLine("QUARTERLY REPORT");
            Console.WriteLine("Product\t\t\tAmount");
            Console.WriteLine("------------------------------");
            for (var i = 0; i < quarterlyProducts.Count; i++)
            {
                StringBuilder ProductString = new StringBuilder($"{quarterlyProducts[i].productName}\t");
                string Price = string.Format("{0:C}",
                quarterlyProducts[i].productPrice);
                ProductString.Append(Price);
                Console.WriteLine(ProductString);
            }
            Console.WriteLine("Press any key to go back to Main Menu");
            Console.ReadLine();
        }
    }
}

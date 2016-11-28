using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialReports.Factories;
using FinancialReports.Entities;

namespace FinancialReports.Actions
{
    public class WeeklyReport
    {
        public static void ReadInput()
        {
            ProductFactory productFactory = new ProductFactory();
            List<Product> weeklyProducts = productFactory.getProductsWithinTime(7);
            Console.WriteLine("WEEKLY REPORT");
            Console.WriteLine("Product\t\t\tAmount");
            Console.WriteLine("------------------------------");
            for (var i=0; i<weeklyProducts.Count; i++)
            {
                StringBuilder ProductString = new StringBuilder($"{weeklyProducts[i].productName}\t");
                string Price = string.Format("{0:C}", weeklyProducts[i].productPrice);
                ProductString.Append(Price);
                Console.WriteLine(ProductString);
            }
            Console.WriteLine("Press any key to go back to Main Menu");
            Console.ReadLine();
        }
    }
}

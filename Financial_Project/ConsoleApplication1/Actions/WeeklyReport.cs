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
                Console.WriteLine($"{weeklyProducts[i].productName}  ${weeklyProducts[i].productPrice}");
            }
            Console.WriteLine("Please any key to go back to Main Menu");
            Console.ReadLine();
        }
    }
}

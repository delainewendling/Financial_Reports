using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialReports.Factories;
using FinancialReports.Entities;

namespace FinancialReports.Actions
{
    public class RevenuePerCustomer
    {
        public static void ReadInput()
        {
            CustomerFactory customerFactory = new CustomerFactory();
            List<Customer> customerRevenue = customerFactory.getCustomerRevenue();
            Console.WriteLine("CUSTOMER REVENUE REPORT");
            Console.WriteLine("Customer\t\t\tRevenue");
            Console.WriteLine("------------------------------");
            for (var i = 0; i < customerRevenue.Count; i++)
            {
                Console.WriteLine($"{customerRevenue[i].firstName}  {customerRevenue[i].lastName}\t\t${customerRevenue[i].revenue}");
            }
            Console.WriteLine("Please any key to go back to Main Menu");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialReports.Entities
{
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }
        public double revenue { get; set; }
        public DateTime orderDate { get; set; }
    }
}

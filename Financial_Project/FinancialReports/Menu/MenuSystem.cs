using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialReports.Factories;
using FinancialReports.Actions;

namespace FinancialReports.Menu
{
    public class MenuSystem
    {
        // Representation of each item that will be displayed in the main menu of choices
        private struct MenuItem
        {
            public string prompt;
            public delegate void MenuAction();
            public MenuAction Action;
        };

        // A collection for storing the menu items
        private Dictionary<int, MenuItem> _MenuItems = new Dictionary<int, MenuItem>();

        // Simple boolean to check whether to keep displaying the main menu
        private bool done = false;

        // To signal that the user is done with The Financial Report
        private void MarkDone()
        {
            done = true;
        }

        public MenuSystem()
        {
            _MenuItems.Add(1, new MenuItem()
            {
                prompt = "Weekly Report",
                Action = WeeklyReport.ReadInput
            });

            _MenuItems.Add(2, new MenuItem()
            {
                prompt = "Monthly Report",
                Action = MonthlyReport.ReadInput
            });

            _MenuItems.Add(3, new MenuItem()
            {
                prompt = "Quarterly Report",
                Action = QuarterlyReport.ReadInput
            });

            _MenuItems.Add(4, new MenuItem()
            {
                prompt = "Revenue per Customer",
                Action = RevenuePerCustomer.ReadInput
            });

            _MenuItems.Add(5, new MenuItem()
            {
                prompt = "Revenue per Product",
                Action = RevenuePerProduct.ReadInput
            });

            _MenuItems.Add(6, new MenuItem()
            {
                prompt = "Leave Reports!",
                Action = MarkDone
            });
        }

        public void Start()
        {

            while (!done)
            {
                ShowMainMenu();
            }
        }

        // Display the main menu of choices for Bangazon
        public void ShowMainMenu()
        {
            Console.Clear();

            string border = "===============================";
            StringBuilder mainMenu = new StringBuilder();
            mainMenu.AppendLine("\n");
            mainMenu.AppendLine(border);
            mainMenu.AppendLine(" BANGAZON FINANCIAL REPORT ");
            mainMenu.AppendLine(border);

            // Display each menu item
            foreach (KeyValuePair<int, MenuItem> item in _MenuItems)
            {
                mainMenu.AppendLine($"{item.Key}. {item.Value.prompt}");
            }

            Console.WriteLine(mainMenu);
            Console.Write("> ");

            // Read in the user's choice
            int choice;
            Int32.TryParse(Console.ReadLine(), out choice);

            // Based on their choice, execute the appropriate action
            MenuItem menuItem;
            _MenuItems.TryGetValue(choice, out menuItem);
            menuItem.Action();
        }
    }
}

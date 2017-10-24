using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.AndreyandBilliard
{
    class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> productsAndQuantity { get; set; }
        public decimal Bill { get; set; }
    }
        
    class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, decimal>();

            getProductsAndPrices(products);

            string line = Console.ReadLine();

            List<Customer> customers = new List<Customer>();

            while(line != "end of clients")
            {
                var info = line.Split(new char[] { '-', ',' });
                string name = info[0];
                string product = info[1];
                int quantity = int.Parse(info[2]);

                if (products.ContainsKey(product))
                {
                    bool customerIsPresent = false;

                    Customer customer = new Customer();
                    customer.Name = name;
                    customer.productsAndQuantity = new Dictionary<string, int>();
                    customer.productsAndQuantity.Add(product, quantity);
                    customer.Bill = customer.Bill + products[product] * quantity;

                    foreach (var c in customers)
                    {
                        if(c.Name == customer.Name)
                        {
                            customerIsPresent = true;
                            if (c.productsAndQuantity.ContainsKey(product))
                            {
                                c.productsAndQuantity[product] += quantity;
                            }
                            else
                            {
                                c.productsAndQuantity.Add(product, quantity);
                            }
                            c.Bill += products[product] * quantity;
                        }
                    }
                    if (!customerIsPresent)
                    {
                        customers.Add(customer);
                    }                    
                }
                line = Console.ReadLine();
            }
            decimal totalBill = 0M;
            foreach (var c in customers.OrderBy(s => s.Name))
            {
                Console.WriteLine(c.Name);
                foreach (var productAndQuantity in c.productsAndQuantity)
                {
                    Console.WriteLine($"-- {productAndQuantity.Key} - {productAndQuantity.Value}");
                }
                Console.WriteLine($"Bill: {c.Bill:F2}");
                totalBill += c.Bill;
            }
            Console.WriteLine($"Total bill: {totalBill:F2}");
        }

        private static void getProductsAndPrices(Dictionary<string, decimal> products)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split('-');
                var product = line[0];
                var price = decimal.Parse(line[1]);

                if (!products.ContainsKey(product))
                {
                    products.Add(product, 0);
                }
                products[product] = price;
            }
        }
    }
}

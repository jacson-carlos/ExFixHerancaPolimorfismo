using System;
using System.Collections.Generic;
using System.Globalization;
using ExFixHerancaPolimorfismo.Entities;

namespace ExFixHerancaPolimorfismo
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());
            List<Product> list = new List<Product>();
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data: ");
                Console.Write("Common, used or imported (c/u/i)? ");
                char resp = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string Name = Console.ReadLine();

                Console.Write("Price: ");
                double Price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (resp == 'c'|| resp == 'C')
                {
                    Product product = new Product(Name, Price);
                    list.Add(product);
                }
                else if( resp == 'u' || resp == 'U')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime Date = DateTime.Parse(Console.ReadLine());
                    UsedProduct usedProduct = new UsedProduct(Name, Price, Date);
                    list.Add(usedProduct);
                }
                else if( resp == 'i' || resp == 'I')
                {
                    Console.Write("Customs fee: ");
                    double CustomsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    ImportedProduct importedProduct = new ImportedProduct(Name, Price, CustomsFee);
                    list.Add(importedProduct);
                }
                
                
             }
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS: ");
            foreach (Product product1 in list)
            {
                Console.WriteLine(product1.PriceTag());
            }
        }
    }
}

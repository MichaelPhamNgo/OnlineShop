using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                //https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/reading-related-data-with-the-entity-framework-in-an-asp-net-mvc-application
                var categories = db.ProductCategories.ToList();
                foreach (ProductCategory c in categories)
                {
                    foreach (Product p in c.Products)
                    {
                        Console.WriteLine("Category Name = " + c.Name + ", Product Name = " + p.Name);
                    }
                }

                var product = db.Products.Find(2);
                Console.WriteLine("Product Name = " + product.Name + ", Category Name = " + product.ProductCategory.Name);

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}

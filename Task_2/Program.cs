using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using Task_1;

/*2.    Необходимо разработать программу для получения информации о товаре из json-файла.
Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.*/

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products;
            string jsonString = String.Empty;

            string path = "../../../JSON/Products.json";
            using (StreamReader sr = new StreamReader(path))
            {
                jsonString = sr.ReadToEnd();
            }

            products = JsonSerializer.Deserialize<Product[]>(jsonString);
            Product mostValuableProduct = products[0];

            foreach (Product product in products)
            {
                mostValuableProduct = (mostValuableProduct.ProductValue > product.ProductValue) ? mostValuableProduct : product;
            }

            Console.WriteLine("Самый дорогой товар - {0}(код: {1}). Цена - {2}", mostValuableProduct.ProductName, mostValuableProduct.ProductCode, mostValuableProduct.ProductValue);
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using System.Text.Unicode;

/*1.    Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.

Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».*/

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int arrayLength = 3;
            Product[] products = new Product[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                Console.WriteLine("Введите код {0}-го товара", i + 1);
                int productCode = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите наименование {0}-го товара", i + 1);
                string productName = Console.ReadLine();
                Console.WriteLine("Введите стоимость {0}-го товара", i + 1);
                double productValue = Convert.ToDouble(Console.ReadLine());

                products[i] = new Product()
                {
                    ProductCode = productCode,
                    ProductName = productName,
                    ProductValue = productValue
                };
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            
            string path = "../../../Products.json";           
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(JsonSerializer.Serialize(products, options));
            }
        }
    }
}

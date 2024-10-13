using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            double b = 0;
            bool indicator = true;
            Console.WriteLine("Введите число от 0 до 255");
            try
            {
                double c = Convert.ToDouble(Console.ReadLine());
                a = c;
            }
            catch (Exception)
            {
                Console.WriteLine("Введено НЕ число");
                indicator = false;
            }
            if (a < 0 | a > 255)
            {
                Console.WriteLine("Число вне диапазона");
                indicator = false;
            }
            Console.WriteLine("Введите число от 0 до 255");
            try
            {
                double c = Convert.ToDouble(Console.ReadLine());
                b = c;
            }
            catch (Exception)
            {
                Console.WriteLine("Введено НЕ число");
                indicator = false;
            }
            if (b < 0 | b > 255)
            {
                Console.WriteLine("Число вне диапазона");
                indicator = false;
            }
            if (b == 0 & indicator == true)
            {
                Console.WriteLine("Деление на 0 невозможно");
                indicator = false;
            }
            if (indicator == true)
            {
                Console.WriteLine(a / b);
            }
        }
    }
}

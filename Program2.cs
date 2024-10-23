using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static string Pfactor(int x)
        {
            string s = "";
            //Проверяем делимость на все числа циклом фор
            for (int i = 2; i <= x; i++)
            {
                //Если х не делится на i, то пропускаем
                if (x % i != 0)
                {
                    continue;
                }
                //Если делится, то делим на него, пока можем
                else
                {
                    while (x % i == 0)
                    {
                        x /= i;
                        if (s == "")
                        {
                            s = s + i.ToString();
                        }
                        //Добавляем звезду только если число не первое
                        else
                        {
                            s = s + "*" + i.ToString();
                        }
                    }
                }
            }
            return s;
        }
        static void Main(string[] args)
        {
            //Вызываем функцию от введенного числа
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Pfactor(a));
        }
    }
}

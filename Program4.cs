using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program4
    {
        class NegativeInteger
        {
            private int x;
            public NegativeInteger(int x)
            {
                if (x >= 0)
                {
                    throw new ArgumentException("Неотрицательное число");
                }
                this.x = x;
                Console.WriteLine("Создан объект");
            }
            public int GetInt()
            {
                return x;
            }
            public void PrintInt()
            {
                Console.WriteLine(x);
            }
            public NegativeInteger(NegativeInteger n)
            {
                this.x = n.x;
                Console.WriteLine("Объект скопирован");
            }
            public int Compare(NegativeInteger k)
            {
                if (x > k.x)
                {
                    return 1;
                }
                else if (x < k.x)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

        }
        static void Main(string[] args)
        {
            NegativeInteger a = new NegativeInteger(-2);
            Console.WriteLine(a.GetInt());
            a.PrintInt();
            NegativeInteger b = new NegativeInteger(a);
            b.PrintInt();
            NegativeInteger c = new NegativeInteger(-2);
            Console.WriteLine(a.Compare(c));
        }
    }
}

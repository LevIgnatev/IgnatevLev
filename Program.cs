using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names;
            names = new string[4];
            names[0] = "a";
            names[1] = "b";
            names[2] = "c";
            names[3] = "d";
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
            string a = "ddd";
            int b = 2384;
            Console.WriteLine(
                format: "{0,10} {1,6}",
                arg0: a,
                arg1: b);
        }
    }
}

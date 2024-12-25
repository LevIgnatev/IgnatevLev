using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program10
    {
        public static void PrintArray<T>(T[] array)
        {
            foreach (T item in array)
            {
                Console.WriteLine(item);
            }
        }
        public static int FindOccurrencesCount<T>(T[] array, T item)
        {
            int count = 0;
            foreach (T i in array)
            {
                if (i.Equals(item))
                {
                    count ++;
                }
            }
            return count;
        }
        public static List<T> Reverse<T>(List<T> list)
        {
            list.Reverse();
            List<T> reversedlist = new List<T>();
            foreach (T item in list)
            {
                reversedlist.Add(item);
            }
            return reversedlist;
        }
        static void Main(string[] args)
        {
            string[] a = new string[4];
            a[0] = "lol";
            a[1] = "LOOOL";
            a[2] = "ahahahhah";
            a[3] = "lol";
            PrintArray(a);
            Console.WriteLine("------------------------------------");
            Console.WriteLine(FindOccurrencesCount(a,"lol"));
            Console.WriteLine("------------------------------------");
            List<int> b = new List<int> { 1, 2, 3 };
            foreach (int i in Reverse(b))
            {
                Console.WriteLine(i);
            }
        }
    }
}

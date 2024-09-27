using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"Type", -10} {"Byte(s) of memory", 10} {"Min", 40} {"Max", 30}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"sbyte", -17} {sizeof(sbyte), 10} {sbyte.MinValue, 40} {sbyte.MaxValue, 30}");
            Console.WriteLine($"{"byte",-17} {sizeof(byte),10} {byte.MinValue,40} {byte.MaxValue,30}");
            Console.WriteLine($"{"short",-17} {sizeof(short),10} {short.MinValue,40} {short.MaxValue,30}");
            Console.WriteLine($"{"ushort",-17} {sizeof(ushort),10} {ushort.MinValue,40} {ushort.MaxValue,30}");
            Console.WriteLine($"{"int",-17} {sizeof(int),10} {int.MinValue,40} {int.MaxValue,30}");
            Console.WriteLine($"{"uint",-17} {sizeof(uint),10} {uint.MinValue,40} {uint.MaxValue,30}");
            Console.WriteLine($"{"long",-17} {sizeof(long),10} {long.MinValue,40} {long.MaxValue,30}");
            Console.WriteLine($"{"ulong",-17} {sizeof(ulong),10} {ulong.MinValue,40} {ulong.MaxValue,30}");
            Console.WriteLine($"{"float",-17} {sizeof(float),10} {float.MinValue,40} {float.MaxValue,30}");
            Console.WriteLine($"{"double",-17} {sizeof(double),10} {double.MinValue,40} {double.MaxValue,30}");
            Console.WriteLine($"{"decimal",-17} {sizeof(decimal),10} {decimal.MinValue,40} {decimal.MaxValue,30}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp9.Program6;

namespace ConsoleApp9
{
    internal class Program6
    {
        public class Figure
        {
            public int Layer;
            public string EdgeColor = "black";
            public double EdgeThickness = 1;
            public string FillColor = "white";
        }
        public class Point
        {
            public float X_Position;
            public float Y_Position;
        }
        sealed class Circle : Figure
        {
            public float Radius;
            public Point Center;
        }
        sealed class Edge : Figure
        {
            public Point FirstPoint;
            public Point SecondPoint;
            public new string FillColor { get; }
        }
        public class Polygon
        {
            public List<Point> Points;
        }
        static void Main(string[] args)
        {

        }
    }
}

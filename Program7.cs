using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp9.Program7;

namespace ConsoleApp9
{
    internal class Program7
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
        public class Polygon : Figure
        {
            public List<Point> Points;
        }
        public Figure FindNearestFigure(List<Figure> list)
        {
            Figure first = list[0];
            foreach (Figure f in list)
            {
                if (f.Layer > first.Layer)
                    first = f;
            }
            return first;
        }
        public List<Figure> FindCircles(List<Figure> list)
        {
            List<Figure> AllCircles = new List<Figure>();
            foreach (Figure f in list)
            {
                if (f.GetType() == typeof(Circle))
                {
                    AllCircles.Add(f);
                }
            }
            return AllCircles;
        }
        public Figure FindFirstTriangle(List<Figure> list)
        {
            Figure firstTriangle = null;
            foreach (Figure f in list)
            {
                if (f.GetType() == typeof(Polygon))
                {
                    Polygon d = (Polygon) f;
                    if (d.Points.Count() == 3)
                    {
                        firstTriangle = f;
                        break;
                    }
                }
            }
            return firstTriangle;
        }
        public void RepaintEdges(List<Figure> list)
        {
            foreach (Figure f in list)
            {
                if (f.GetType() == typeof(Edge))
                {
                    f.EdgeColor = "Red";
                }
            }
        }
        static void Main(string[] args)
        {

        }
    }
}

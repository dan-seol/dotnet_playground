using System;
using static System.Console;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;


namespace Structural.Adapter
{
    public class Point
    {
        public int X, Y;
        
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode() {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }

    public class Line 
    {
        public Point Start, End;
        
        public Line(Point start, Point end)
        {
            Start = start ?? throw new ArgumentNullException(paramName: nameof(start));
            End = end ?? throw new ArgumentNullException(paramName: nameof(end));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Start != null ? Start.GetHashCode() : 0) * 397) ^ ((End != null ? End.GetHashCode() : 0) * 397);
            }
        }
    }

    public class VectorObject : Collection<Line>
    {

    }

    public class VectorRectangle : VectorObject
    {
        public VectorRectangle(int x, int y, int width, int height)
        {
            Add(new Line(new Point(x, y), new Point(x + width, y)));
            Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
            Add(new Line(new Point(x, y), new Point(x, y + height)));
            Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
        }
    }

    public class LineToPointAdapter : IEnumerable<Point>
    {
        private static int count;
        static Dictionary<int, List<Point>> cache = new Dictionary<int, List<Point>>();
        public LineToPointAdapter(Line line)
        {
            var hash = line.GetHashCode();
            if (cache.ContainsKey(hash))
            {
                return;
            }

            var points = new List<Point>();

            int x1 = line.Start.X;
            int y1 = line.Start.Y;
            int x2 = line.End.X;
            int y2 = line.End.Y;

            WriteLine($"{++count}: Generating points for line [{x1},{y1}] - [{x2},{y2}]");

            int left = Math.Min(x1, x2);
            int right = Math.Max(x1, x2);
            int top = Math.Min(y1, y2);
            int bottom = Math.Max(y1, y2);
            int dx = right - left;
            int dy = top - bottom;

            if (dx == 0)
            {
                for (int y = top; y <= bottom; ++y)
                {
                    points.Add(new Point(left, y));
                }
            } 
            else if (dy == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    points.Add(new Point(x, top));
                }
            }

            cache.Add(hash, points);
   
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return cache.Values.SelectMany(x => x).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

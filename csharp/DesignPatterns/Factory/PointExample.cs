using System;

namespace Factory
{
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }

    public class Point //limited information to communicate to user; have to resort to comment
    {
        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
     /*   public Point(double a, double b, CoordinateSystem system = CoordinateSystem.Cartesian) //cartesian coordinate
        {
            switch(system)
            {
                case CoordinateSystem.Cartesian:
                    this.x = a;
                    this.y = b;
                break;
                case CoordinateSystem.Polar:
                    this.x = a * Math.Cos(b);
                    this.y = a * Math.Sin(b);
                break;
            }
            
        }*/

        //factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
        //for polar coordinates?
        //2 factory patterns
        //1 proper factory
        // abstract factory

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
}

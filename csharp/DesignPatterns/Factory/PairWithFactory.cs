using System;

namespace Factory
{
    public static class PairFactory
    {
        public static Pair NewCartesianPoint(double x, double y)
        {
            return new Pair(x, y);
        }

        public static Pair NewPolarPoint(double rho, double theta)
        {
            return new Pair(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }
    public class Pair//limited information to communicate to user; have to resort to comment
    {
        private double x, y;

            internal Pair(double x, double y) //public
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

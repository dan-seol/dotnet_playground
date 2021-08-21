using System;

namespace Factory
{
    
    public class Coordinate//limited information to communicate to user; have to resort to comment
    {
        private double x, y;

            private Coordinate(double x, double y) //public
        {
            this.x = x;
            this.y = y;
        }

        //public static Factory factory => new Factory();

        public static Coordinate Origin => new Coordinate(0, 0);
        
        public class Factory
        {
            public static Coordinate NewCartesianCoordinate(double x, double y)
            {
                return new Coordinate(x, y);
            }

            public static Coordinate NewPolarCoordinate(double rho, double theta)
            {
                return new Coordinate(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
}

using System;
using static System.Console;

namespace Proxy
{
    public class Driver
    {
        public int Age { get; set; }
    }
    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            WriteLine("Car is being driven");
        }
    }

    public class CarProxy : ICar
    {
        private Driver driver;
        private Car car = new Car();

        public CarProxy(Driver driver)
        {
            this.driver = driver;
        }

        public void Drive()
        {
            if (driver.Age >= 16)
            {
                car.Drive();
            }
            else
            {
                WriteLine("The driver is too young!s");
            }
        }
    }
}

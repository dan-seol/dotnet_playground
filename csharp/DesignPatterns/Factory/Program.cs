using System;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var point = Point.NewPolarPoint(1, Math.PI / 2);
            /*Foo foo = new Foo();
            await foo.InitAsync();*/
            //Foo x = await Foo.CreateAsync(); // a better way: change main to static async Task
            var pair = PairFactory.NewCartesianPoint(1, 1);
            var coord = Coordinate.Factory.NewCartesianCoordinate(1, 1);
            //var coord = Coordinate.factory.NewCartesianCoordinate(1, 1); //gotta make factory methods non-static
            var origin = Coordinate.Origin;

           /* var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink();*/
            var pf = new PersonFactory();
            var p1 = pf.CreatePerson("aanika");
            var p2 = pf.CreatePerson("dan");
            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
    }
}

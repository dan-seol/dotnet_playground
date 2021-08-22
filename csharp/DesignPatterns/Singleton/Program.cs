using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;


namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;
            Console.WriteLine($"Seoul: {db.GetPopulation("Seoul")}");
            var ceo = new CEO();
            ceo.Name = "Adam Smith";
            ceo.Age = 55;
            var ceo2 = new CEO();
            Console.WriteLine(ceo2);

            var t1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"t1: {PerThreadSingleton.ThreadInstance.Id}");
            });

            var t2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"t2: {PerThreadSingleton.ThreadInstance.Id}");
                Console.WriteLine($"t2: {PerThreadSingleton.ThreadInstance.Id}");
            });

            Task.WaitAll(t1, t2);

            var house = new Building();

            using (new BuildingContext(3000))
            {
                house.Walls.Add(new Wall(new Point(0,0), new Point(5000, 0)));
                house.Walls.Add(new Wall(new Point(0,0), new Point(0, 4000)));
                using (new BuildingContext(3500))
                {
                    //fst fllor 3500
                    house.Walls.Add(new Wall(new Point(0,0), new Point(6000, 0)));
                    house.Walls.Add(new Wall(new Point(0,0), new Point(0, 4000)));

                }

                house.Walls.Add(new Wall(new Point(5000,0), new Point(5000, 4000)));
            }
            
            WriteLine(house);

        }
    }
}
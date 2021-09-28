using System;
using System.Linq;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ICar car = new CarProxy(new Driver {Age = 16});
            car.Drive();
            //anti-pattern
            var c = new Creature();
            c.Agility = 10; 
            // c.set_Agility(10) using an implicit conversion 
            // c.Agility = new Property<int>(10)
            c.Agility = 10;

            Console.WriteLine(10f * 5.Percent());

            Console.WriteLine(2.Percent() + 1.Percent());


            //AOS
            /*var monsters = new Monster[100];

            // Age X Y Age X Y Age X Y - inefficient
            // Age Age Age Age
            // X X X X
            // Y Y Y Y

            //Not so memory efficient
            foreach (var m in monsters)
            {
                
                m.X++;
            }*/

            // AOS/SOA duality
            var monsters2 = new Monsters(100);

            foreach (Monsters.MonsterProxy m2 in monsters2)
            {
                m2.X++;
            }

            //var ba = new BankAccount();
            var ba = Log<BankAccount>.As<IBankAccount>();

            ba.Deposit(100);
            ba.Withdraw(50);

            Console.WriteLine(ba);


            var numbers = new[] { 1, 3, 5, 7 };
            int numberOfOps = numbers.Length - 1;

            for (int result = 0; result <= 10; ++result)
            {
                for (var key = 0UL; key < (1UL << 2 * numberOfOps); ++key)
                {
                    var tbs = new TwoBitSet(key);
                    var ops = Enumerable.Range(0, numberOfOps)
                        .Select(i => tbs[i]).Cast<Op>().ToArray();
                    var problem = new Problem(numbers, ops);
                    if (problem.Eval() == result)
                    {
                        Console.WriteLine($"{new Problem(numbers, ops)} = {result}");
                        break;
                    }
                }
            }

            Console.ReadKey();
        }
    }
}

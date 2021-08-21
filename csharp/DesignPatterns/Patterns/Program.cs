using System;
using System.Text;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //Solid
            /* var j = new Journal();
             j.AddEntry("I cried today");
             j.AddEntry("I ate a bug");
             Console.WriteLine(j);

             var p = new Persistence();
             var filename = @"journalSaved.txt";
             p.SaveToFile(j, filename, true);

             Process.Start(filename);*/

            /* var apple = new Product("Apple", Color.Green, Size.Small);
             var tree = new Product("Tree", Color.Green, Size.Large);
             var house = new Product("House", Color.Blue, Size.Large);

             Product[] products = { apple, tree, house };

             ProductFilter pf = new ProductFilter();
             Console.WriteLine("Green products (old):");

             var ps = pf.FilterByColor(products, Color.Green);
             Console.WriteLine(ps);
             foreach (var p in pf.FilterByColor(products, Color.Green))
             {
                 Console.WriteLine($" - {p.Name} is {p.Color}");
             }

             var bf = new BetterFilter();
             var gs = new ColorSpecification(Color.Green);
             Console.WriteLine("Green products (new):");
             foreach (var p in bf.Filter(products, gs))
             {
                 Console.WriteLine($" - {p.Name} is {p.Color}");

             }

             var andSpec = new AndSpecficiation<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large));

             Console.WriteLine("Large Blue Items");
             foreach (var p in bf.Filter(products, andSpec))
             {
                 Console.WriteLine($" - {p.Name} is {p.Color} and {p.Size}");

             }*/

            /*     Rectangle rc = new Rectangle(2, 3);
                 Console.WriteLine($"{rc} has area {Area(rc)}");

                 //Square sq = new Square();
                 Rectangle sq = new Square(); //- Liskov : upcasting shouldn't change the behavior, but it does.
                 sq.Width = 4;
                 Console.WriteLine($"{sq} has area {Area(sq)}");*/

            /*var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);*/

        }   
        public static int Area(Rectangle r) => r.Width * r.Height;
    }
}


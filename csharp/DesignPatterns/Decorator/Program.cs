using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Autofac;
using Autofac.Core;
namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder();
            cb.AppendLine("class Foo")
            .AppendLine("{")
            .AppendLine("}");

            Console.WriteLine(cb);

            MyStringBuilder s = "hello ";
            s += "world";
            Console.WriteLine(s);

            var d = new Dragon();
            d.Weight = 123;

            d.Fly();
            d.Crawl();

            var b = new Bat {Age = 5};
            if (b is IMammal mammal)
            {
                mammal.Crawl();
            }
            if (b is IWinged winged)
            {
                winged.Fly();
            }

            var square = new Square(1.23f);
            Console.WriteLine(square.AsString());
            var blueCircle = new ColoredShape(new Circle(2f), "blue");
            Console.WriteLine(blueCircle.AsString());
            var blueHalfTransparentCircle = new TransparentShape(blueCircle, 0.5f);
            Console.WriteLine(blueHalfTransparentCircle.AsString());
            var redSquare = new ColouredShape(square, "red");
            Console.WriteLine(redSquare.AsString());
            var greenRedSquare = new ColouredShape(redSquare, "green");

            Console.WriteLine(greenRedSquare.AsString());

            var oakTree = new PlantWithThickness<Tree>(5);
            Console.WriteLine(oakTree.AsString());
            var expensiveGrapes = new PlantWithValue<PlantWithThickness<Vine>>();
            Console.WriteLine(expensiveGrapes.AsString());

            var ctb = new ContainerBuilder();
            ctb.RegisterType<ReportingService>().Named<IReportingService>("reporting");
            ctb.RegisterDecorator<IReportingService>(
                (context, service) => new ReportingServiceWithLogging(service),
                "reporting"
            );

            using (var c = ctb.Build())
            {
                var r = c.Resolve<IReportingService>();
                r.Report();
            }

        }
    }
}

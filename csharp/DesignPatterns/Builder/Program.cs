using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            //Builder - unit 2
            //Life without builder
            /*  var hello = "hello"; // say you want to turn this into an HTML paragraph
              var sb = new StringBuilder();
              sb.Append("<p>");
              sb.Append(hello);
              sb.Append("</p>");
              Console.WriteLine(sb);
              var words = new[] { "Hello", "world" };
              sb.Clear();
              sb.Append("<ul>");
              foreach (var word in words)
              {
                  sb.AppendFormat("<li>{0}</li>", word);
              }
              sb.Append("<ul>");
              Console.WriteLine(sb);*/

            /*       var builder = new HtmlBuilder("ul");
                   *//*builder.AddChild("li", "hello");
                   builder.AddChild("li", "world");*//*
                   builder.AddChild("li", "hello").AddChild("li", "world");
                   Console.WriteLine(builder.ToString());*/

            // builder.Called("dan"). 
            //wouldn't have .WorksAsA since it returns EmployeeInfoBuilder!
            //the problem with the inheritance of fluent interfaces
            //: you are not allowed to use the containing type as the return type
            /*            var me = Employee.New.Called("dan").WorksAsA("developer").Build();
                        Console.WriteLine(me.ToString());

                        var car = CarBuilder.Create().OfType(CarType.Crossover).WithWheels(18).Build();*/
            /* var human = new HumanBuilder().Called("Sarah").WorksAs("Developer").Build();
             Console.WriteLine(human.ToString());*/

            /*var rb = new ResidentBuilder();
            Resident resident = rb.Works.At("Morgan Stanley").AsA("Engineer").Earning(123000)
                .Lives.At("Ontario").WithPostcode("H3Z 2E7").In("Montreal");
            Console.WriteLine(resident);*/

            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}

using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            //var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));
            //var jane = (Person) john.Clone();
            var john = new PersonOne(new[] { "John", "Smith" }, new AddressOne("London Road", 123));
            var jane = new PersonOne(john)
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 321;
            Console.WriteLine(john);
            Console.WriteLine(jane);
        }
    }
}

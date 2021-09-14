using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            //var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));
            //var jane = (Person) john.Clone();
            //var john = new PersonOne(new[] { "John", "Smith" }, new AddressOne("London Road", 123));
            //var jane = new PersonOne(john);
            //var john = new PersonTwo(new[] { "John", "Smith" }, new AddressTwo("London Road", 123));
            //var jane = john.DeepCopy();
            //Console.WriteLine(john);
            //Console.WriteLine(jane);
           /*  var john = new Employee();
            john.Names = new[] { "John", "Doe" }; 
            john.Address = new AddressThree 
            {
                HouseNumber = 123, 
                StreetName = "Rue Durocher"
            };
            john.Salary = 321000;
            var copy = john.DeepCopy();
            copy.Names[1] = "Copy";
            copy.Address.HouseNumber++;
            copy.Salary = 123000;
            Console.WriteLine(john);
            Console.WriteLine(copy); */

            var john = new PersonFour(new[] { "John", "Smith" }, new AddressFour("London Road", 123));
            var jane = john.DeepCopy();
            var jack = jane.DeepCopyXml();
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 321;
            jack.Names[0] = "Jack";
            jack.Address.StreetName = "Rue Hutchison";
            Console.WriteLine(john);
            Console.WriteLine(jane);
            Console.WriteLine(jack);
        }
    }
}

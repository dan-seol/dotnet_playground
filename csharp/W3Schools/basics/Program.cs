using System;

namespace HelloWorld {
    class Program {
        static void Main(string[] args) {
            //Print "Hello World!" on the console using Console.WriteLime(...);
            /*
            takes no argument
            */
            Console.WriteLine("Hello World!");
            string name = "Dan Seol";
            Console.WriteLine("My name is " + name);
            int age = 24;
            Console.WriteLine("I am " + age + " years old." );
            const int birthYear = 1997;
            Console.WriteLine("I was born in " + birthYear);
            double gpa = 3.79D;
            bool gender = true;
            Console.WriteLine("My cgpa was : " + gpa);
            Console.WriteLine("Am I a male ? " + gender);
            int anneAge = 20, momAge = 60, aanikaAge = 24;
            Console.WriteLine($"People I love are {anneAge}, {momAge}, {aanikaAge} years old.");
            Console.WriteLine("What's your name? ");
            string yourName = Console.ReadLine();
            Console.WriteLine("Okay, you are " + yourName);
            Console.ReadLine();
        }
    }
}
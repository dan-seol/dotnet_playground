using System;
using static System.Console;

namespace Decorator
{
    public interface ICreature
    {
        int Age {get; set;}
    }

    public interface IWinged : ICreature
    {
        void Fly()
        {
            if (Age >= 10)
            {
                WriteLine("I am flying");
            }
        }
    }

    public interface IMammal : ICreature
    {
        void Crawl()
        {
            if (Age < 10)
            {
                WriteLine("I am crawling");
            }
        }

    }

    // inheritance
    // smartbat
    // 1. extension methods
    // 2, C#8 default interface method

    public class Animal
    {

    }

    public class Bat : Animal, IWinged, IMammal
    {
       public int Age { get; set;}
    }
}

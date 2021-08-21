using System;
using System.Collections.Generic;
using static System.Console;

namespace Factory
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine("This tea is nice but I wish I had some jam also.");
        }

    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            WriteLine("I feel more awake now!");
        }

    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Put in a tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        /*  public enum AvailableDrink
          {
              Coffee, Tea //O-C principle broken!
          }
  *//*
          private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();
          public HotDrinkMachine()
          {
              foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
              {
                  var factory = (IHotDrinkFactory)Activator.CreateInstance(
                      Type.GetType("Factory." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory")
                      );
                  factories.Add(drink, factory);
              }
          }

          public IHotDrink MakeDrink(AvailableDrink drink, int amount)
          {
              return factories[drink].Prepare(amount);
          }*/
        //alternative: use reflection

        private List<(string, IHotDrinkFactory)> factories =
            new List<(string, IHotDrinkFactory)>();
        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add((t.Name.Replace("Factory", string.Empty), (IHotDrinkFactory) Activator.CreateInstance(t)));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            WriteLine("Available drinks:");
            for (int i = 0; i < factories.Count; i++)
            {
                (string, IHotDrinkFactory) t = factories[i];
                WriteLine($"{i}- {t.Item1}");
            }
            while (true)
            {
                string s;
                if ((s = ReadLine()) != null && int.TryParse(s, out int i) && i >= 0 && i < factories.Count)
                {
                    Write("Specify amount: ");
                    s = ReadLine();
                   if (s != null && int.TryParse(s, out int amount) && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }

                }
                WriteLine("Incorrect input, try again!");
            }
        }
    }
}

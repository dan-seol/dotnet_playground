using System;

namespace Oop {
    public class Tofu : PlantBasedProtein {
        const double price = 2D;
        const string name = "Tofu";
        public override void offer() {
            Console.WriteLine($"Welcome to Aanika's healthy grocery store. We sell {base.type()}");
            Console.WriteLine($"How much {name} do you want in kg?");
            double amount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"You have chosen {amount} kg. The price per kg would be ${price}.");
            Console.WriteLine($"The total would be ${amount * price}.");
            double moneyPaid = Convert.ToDouble(Console.ReadLine());
            double moneyOwed = amount * price;
            Console.WriteLine($"I have received ${moneyPaid}");
            if (moneyPaid >= moneyOwed) {
                Console.WriteLine($"Your change is ${moneyPaid - moneyOwed}");
                thank();
            } else {
                Console.WriteLine("You don't have enough money! :(");
            }
        }
    }
}
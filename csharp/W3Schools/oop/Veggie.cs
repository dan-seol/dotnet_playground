using System;

namespace Oop {
    public class Veggie {
        private string name;
        private double price;
        public Veggie(string name, double price) {
            this.name = name;
            this.price = price;
        }
        public string Name {
            get { return name; }
            set { name = value; }
        }

        public double Price {
            get { return price; }
            set { price = value; }
        }

        public virtual void promote() {
            Console.WriteLine($"Special sale! You can buy one unit of {name} only at ${price}!");
        }
    }
}
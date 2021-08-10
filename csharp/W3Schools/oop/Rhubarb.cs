using System;

namespace Oop {
public class Rhubarb : Veggie {
    private int acidity;
    public Rhubarb(double price, int acidity) : base("Rhubarb", price) {
        this.acidity = acidity;
    }

    public override void promote() {
        Console.WriteLine($"Special sale! You can buy one unit of {base.Name} only at ${base.Price}! It has the acidity level of {acidity}.");
    }
}

}
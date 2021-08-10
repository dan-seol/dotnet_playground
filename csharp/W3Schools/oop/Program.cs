namespace Oop {
    class Program {
        static void Main() {
            Veggie veggie = new Veggie("Spinach", 1.5);
            Rhubarb rhubarb = new Rhubarb(1.2, 5);

            veggie.promote();
            rhubarb.promote();
        }
    }
}
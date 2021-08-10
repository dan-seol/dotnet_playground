using System;

namespace Oop {
    public abstract class Meat : Protein {
        public void thank() {
            Console.WriteLine("Thank you for using Dan's butchershop!");
        }
        public abstract void offer();
        public abstract ProteinType type();
    }
}
using System;

namespace Oop {
    public abstract class PlantBasedProtein : Protein {
        public void thank() {
            Console.WriteLine("Thank you for using Aanika's healthy grocery store!");
        }
        public abstract void offer();
        public ProteinType type() {
            return ProteinType.PLANT_BASED;
        }
    }
}
using System;
using static System.Console;

namespace Decorator
{
    public interface IBird
    {
        void Fly();
        int Weight { get; set; }

    }

    public interface ILizard
    {
        void Crawl();
        int Weight { get; set; }

    }

    public class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly()
        {
            WriteLine($"Soaring in the sky with weight {Weight} kg");
        }
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }
        public void Crawl()
        {
            WriteLine($"Crawling in the dirt with weight {Weight} kg");
        }
    }

    public class Dragon : IBird, ILizard
    {
        private int weight;
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();

        public void Fly()
        {
            this.bird.Fly();
        }

        public void Crawl()
        {
            this.lizard.Crawl();
        }

        public int Weight 
        { 
            get {return weight;} 
            set {
                weight = value;
                bird.Weight = value;
                lizard.Weight = value;
                } 
        }

    }
}

using System;
using static System.Console;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var goblin = new Creature("Goblin", 2, 2);
            WriteLine(goblin);
            var root = new CreatureModifier(goblin);
            root.Add(new NoBonusesModifier(goblin));
            WriteLine("Let's double goblin's attack...");
            root.Add(new DoubleAttackModifier(goblin));
            WriteLine("Let's increase goblin's defense");
            root.Add(new IncreaseDefenseModifier(goblin));
            // eventually...
            root.Handle();
            WriteLine(goblin);

            var schedule = new TrainSchedule();
            var greenLine = new Train(schedule, "Green", "Angrignon", 20);
             using (new NextStationModifier(schedule, greenLine, "Monk"))
             {
                 WriteLine(greenLine);
                 using (new PassengerLeaveModifier(schedule, greenLine, 10)) {
                     WriteLine(greenLine);
                     using (new PassengerArrivalModifier(schedule, greenLine, 15)) {
                         WriteLine(greenLine);
                     }
                 }
             }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Builder
{
    public class Human
    {
        public string Name, Position;
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class FunctionalBuilder<TSubject, 
        TSelf> where TSelf: FunctionalBuilder<TSubject,
        TSelf>
        where TSubject : new()
    {

        private readonly List<Func<TSubject, TSubject>> actions = new List<Func<TSubject, TSubject>>();

        public TSelf Do(Action<TSubject> action) => AddAction(action);

        public TSubject Build() => actions.Aggregate(new TSubject(), (p, f) => f(p));
        private TSelf AddAction(Action<TSubject> action)
        {
            actions.Add(p => { action(p); return p; });
            return (TSelf) this;
        }

    }

    public sealed class HumanBuilder : FunctionalBuilder<Human, HumanBuilder>
    {
        public HumanBuilder Called(string name) => Do(p => p.Name = name);
    }
  /*public sealed class HumanBuilder
    {
        private readonly List<Func<Human, Human>> actions = new List<Func<Human, Human>>();

        public HumanBuilder Called(string name) => Do(p => p.Name = name);
        public HumanBuilder Do(Action<Human> action) => AddAction(action);

        public Human Build() => actions.Aggregate(new Human(), (p, f) => f(p));
        private HumanBuilder AddAction(Action<Human> action)
        {
            actions.Add(p => { action(p); return p; });
            return this;
        }
    }
  */

    public static class HumanBuilderExtensions
    {
        public static HumanBuilder WorksAs(this HumanBuilder builder, string position) => builder.Do(p => p.Position = position);
    }
}

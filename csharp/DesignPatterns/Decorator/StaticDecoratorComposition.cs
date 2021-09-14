using System;

namespace Decorator
{
//Curiously recurring template pattern
//cannot depend on interface anymore

    public abstract class Plant
    {
        public abstract string AsString();
    }

    public sealed class Vine : Plant
    {
        private double length;

        public Vine() : this(0)
        {

        }

        public Vine(double length)
        {
            this.length = length;
        }

        public void Scale(double factor)
        {
            this.length *= factor;
        }

        public override string AsString() => $"A vine {length} cm long";
    }

    public sealed class Tree : Plant
    {
        private double height;

        public Tree() : this(0)
        {

        }

        public Tree(double height)
        {
            this.height = height;
        }

        public override string AsString() => $"A tree {height} cm high";

    }

    public class PlantWithThickness<T> : Plant  where T : Plant, new()
    {
        private double thickness;
        private T plant = new T();

        public PlantWithThickness() : this(1)
        {

        }

        public PlantWithThickness(double thickness)
        {
            this.thickness = thickness;
        }

        public override string AsString() => $"{plant.AsString()} is {thickness} cm thick";
    }

    public class PlantWithValue<T> : Plant where T : Plant, new()
    {
        private double value;
        private T plant = new T();

        public PlantWithValue() : this(10)
        {

        }

        public PlantWithValue(double value)
        {
            this.value = value;
        }

        public override string AsString() => $"{plant.AsString()} costs $ {value}";
    }
}

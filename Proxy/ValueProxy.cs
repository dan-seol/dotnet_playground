using System;
using System.Xml.Schema;

namespace Proxy
{
    public struct Price
    {
        private int value;

        public Price(int value)
        {
            this.value = value;
        }

       
    }

    public static class PercentageExtensions
    {
        public static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0f);
        }

        public static Percentage Percent(this float value)
        {
            return new Percentage(value / 100.0f);
        }
    }
    public struct Percentage
    {
        private readonly float value;

        internal Percentage(float value)
        {
            this.value = value;
        }

        public static float operator *(float f, Percentage p)
        {
            return f * p.value;
        }

        public static Percentage operator +(Percentage p1, Percentage p2)
        {
            return new Percentage(p1.value + p2.value);
        }

        public override string ToString()
        {
            return $"{value * 100}";
        }

        public bool Equals(Percentage other)
        {
            return value.Equals(other.value);
        }

        public override bool Equals(object? obj)
        {
            return ReferenceEquals(null, obj)
                ? false
                : (obj is Percentage other && Equals(other));
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(Percentage left, Percentage right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Percentage left, Percentage right)
        {
            return !left.Equals(right);
        }
    }
    //wrapper around the primitive type
   /*public static void foo(int price)
   {

   }*/
}

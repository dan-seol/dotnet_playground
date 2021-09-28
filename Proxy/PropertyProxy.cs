using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static System.Console;

namespace Proxy
{
    public class Property<T> where T : new()
    {
        private T value;

        public T Value
        {
            get => value;

            set
            {
                if (Equals(this.value, value)) return;
                WriteLine($"Assigning value to {value}");
                this.value = value;
            }
        }

        public Property() : this(Activator.CreateInstance<T>())
        {

        }

        public Property(T value)
        {
            this.value = value;
        }

        public static implicit operator T(Property<T> property)
        {
            return property.value; // int n = p_int;/
        }

        public static implicit operator Property<T>(T value)
        {
            return new Property<T>(value); //Property<int> p = 123;
        }

        public bool Equals(Property<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(value, other.value);
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != this.GetType()) return false;
            return Equals((Property<T>) other);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode();
        }

        public static bool operator ==(Property<T> left, Property<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Property<T> left, Property<T> right)
        {
            return !Equals(left, right);
        }
    }

    public class Creature
    {
        //public Property<int> Agility { get; set; }
        private Property<int> agility = new Property<int>();

        public int Agility
        {
            get => agility.Value;
            set => agility.Value = value;
        }
    }
}

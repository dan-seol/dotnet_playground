using System;
using System.Collections.Generic;

namespace Patterns
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Yuuge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            if (name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            Name = name;
            Color = color;
            Size = size;
        }

    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                {
                    yield return p;
                }
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                {
                    yield return p;
                }
            }
        }

        //Violates open-closed principle
        public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        {
            foreach (var p in products)
            {
                if (p.Size == size && p.Color == color)
                {
                    yield return p;
                }
            }
        }

        //will implement a specification pattern
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return this.color == t.Color;
        }
    }
    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }
        public bool IsSatisfied(Product t)
        {
            return this.size == t.Size;
        }
    }

    public class AndSpecficiation<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;

        public AndSpecficiation(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first;
            this.second = second;
        }
        public bool IsSatisfied(T t)
        {
            return this.first.IsSatisfied(t) && this.second.IsSatisfied(t);
        }
    }
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisfied(i))
                {
                    yield return i;
                }
            }
        }
    }
}

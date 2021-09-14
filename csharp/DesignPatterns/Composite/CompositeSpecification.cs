using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text;

namespace Structural.Composite
{

    public abstract class ISpecification<T>
    {
        abstract bool IsSatisfied(T t);
        public static ISpecification<T> operator &(
          ISpecification<T> first, ISpecification<T> second
        )
        {
          return new AndSpecficiation(first, second);
        }
    }

   
    //combinator
    public class AndSpecficiation<T> : CompositeSpecification<T>
    {

        public AndSpecficiation(params ISpecification<T>[] items) : base(items)
        {

        }
        public bool IsSatisfied(T t)
        {
            // any -> orspecification
            return items.All(i = i.IsSatisfied(t));
        }
    }
}

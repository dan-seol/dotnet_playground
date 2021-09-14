using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Decorator
{
    public abstract class ShapeDecoratorCyclePolicy
    {
        public abstract bool TypeAdditionAllowed(Type type, IList<Type> allTypes);
        public abstract bool ApplicationAllowed(Type type, IList<Type> allTypes);   

    }

    public class ThrowOnCyclePolicy : ShapeDecoratorCyclePolicy
    {
        private bool handler(Type type, IList<Type> allTypes)
        {
            if (allTypes.Contains(type))
            {
                throw new InvalidOperationException($"Cycle detected! Type is already a {type.FullName}!");
            }
            return true;
        }
        public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
        {
            return handler(type, allTypes);
        }
        public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
        {
            return handler(type, allTypes);
        }  
    }

     public class AbsorbCyclePolicy : ShapeDecoratorCyclePolicy
  {
    public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
    {
      return true;
    }

    public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
    {
      return !allTypes.Contains(type);
    }
  }

  public class CyclesAllowedPolicy : ShapeDecoratorCyclePolicy
  {
    public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
    {
      return true;
    }

    public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
    {
      return true;
    }
  }

    public abstract class ShapeDecorator : IShape
    {
        protected internal readonly List<Type> types = new();
        protected internal IShape shape;

        public ShapeDecorator(IShape shape)
        {
            this.shape = shape;
            if (shape is ShapeDecorator sd)
            {
                types.AddRange(sd.types);
            }
        }

        public string AsString()
        {
            return shape.AsString();
        }
    }

    public abstract class ShapeDecorator<TSelf, TCyclePolicy> : ShapeDecorator
    where TCyclePolicy :  ShapeDecoratorCyclePolicy, new()
    {
        protected readonly TCyclePolicy policy = new();
        public ShapeDecorator(IShape shape) : base(shape)
        { 
            if (policy.TypeAdditionAllowed(typeof(TSelf), types))
            types.Add(typeof(TSelf));
        }
    }

//ThrowOnCyclePolicy
//CyclesAllowedPolicy
    public class ShapeDecoratorWithPolicy<T> : ShapeDecorator<T, AbsorbCyclePolicy>
    {
        public ShapeDecoratorWithPolicy(IShape shape) : base(shape)
        {
        }
    }

    public class ColouredShape : ShapeDecoratorWithPolicy<ColouredShape>, IShape
    {
        private readonly string colour;
        public ColouredShape(IShape shape, string colour) : base(shape)
        {

                this.colour = colour ?? throw new ArgumentNullException(paramName: nameof(colour));
            
        }
        
         public new string AsString() 
         {
             var sb = new StringBuilder($"{shape.AsString()}");
             if (policy.ApplicationAllowed(types[0], types.Skip(1).ToList())) 
             sb.Append($" has the colour {colour}");
             
             return sb.ToString();
        }
    }

    //2
    // Foo, Foo<T> : Foo
    // is
    // if (x is Foo<> f) -- anti pattern
}

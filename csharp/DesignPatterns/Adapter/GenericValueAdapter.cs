using System;
using static System.Console;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;


namespace Structural.Adapter
{
    // implement a vector
    // n-dimensional
    // components of a vector
    // vector2f, vector3n?

    public interface IDim
    {
        int Value { get; }
    }
    public class Dimensions 
    {
        public class Two : IDim
        {
            public int Value => 2;
        }

        public class Three : IDim
        {
            public int Value => 2;
        }
    }
   
    public class Vector<T, D> where D : IDim, new()
    {
        protected T[] data;
        public Vector()
        {
            data = new T[new D().Value];
        }
        public Vector(params T[] values)
        {
            var requiredSize = new D().Value;
            data = new T[requiredSize];
            var providedSize = values.Length;
            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
            {
                data[i] = values[i];
            }
        }
        public T this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        // public T X
        // {
        //     get => data[0];
        //     set => data[0] = value;
        // }
    }

    public class VectorOfDouble<D> : Vector<double, D> where D : IDim, new()
    {
       public VectorOfDouble()
       {

       }

       public VectorOfDouble(params double[] values) : base(values)
       {

       } 

       public static VectorOfDouble<D> operator +
        (VectorOfDouble<D> lhs, VectorOfDouble<D> rhs)
       {
        var result = new VectorOfDouble<D>();
        var dim = new D().Value;
        for (int i = 0; i < dim; i++)
        {
            result[i] =  lhs[i] + rhs[i];
        }
        return result;
       }
    }

    public class Vector2d : VectorOfDouble<Dimensions.Two>
    {
        public Vector2d()
        {

        }

        public Vector2d(params double[] values) : base(values)
        {

        }
        //vector addition - operators cannot work on generic!
    }
    //you adapt literal to a type

      public class VectorOfFloat<D> : Vector<float, D> where D : IDim, new()
    {
       public VectorOfFloat()
       {

       }

       public VectorOfFloat(params float[] values) : base(values)
       {

       } 
    }
    public class Vector3f : VectorOfFloat<Dimensions.Three>
    {
        public override string ToString()
        {
            return $"{string.Join(",", data)}";
        }
    }

    public class AnotherVector<TSelf, T, D> where D : IDim, new() where TSelf : AnotherVector<TSelf, T, D>, new()
    {
        protected T[] data;
        public AnotherVector()
        {
            data = new T[new D().Value];
        }
        public AnotherVector(params T[] values)
        {
            var requiredSize = new D().Value;
            data = new T[requiredSize];
            var providedSize = values.Length;
            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
            {
                data[i] = values[i];
            }
        }
        public T this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        // public T X
        // {
        //     get => data[0];
        //     set => data[0] = value;
        // }

        public static TSelf Create(params T[] values)
        {
            //return new Vector<T, D>(values); not going to work if we do changes on Vector3f
            //since it returns Vector<T, D>
            var result = new TSelf();
            var requiredSize = new D().Value;
            result.data = new T[requiredSize];
            var providedSize = values.Length;
            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
            {
                result.data[i] = values[i];
            }

            return result;
        }
    }

    public class AnotherVectorOfInt<TSelf, D> : AnotherVector<TSelf, int, D> where D : IDim, new() where TSelf : AnotherVector<TSelf, int, D>, new()
    {

    }

    public class AnotherVector3i : AnotherVectorOfInt<AnotherVector3i, Dimensions.Three>
    {
         public override string ToString()
        {
            return $"{string.Join(",", data)}";
        }
    }
}

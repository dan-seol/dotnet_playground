using System;
using static System.Console;
using Autofac;

namespace Structural.Bridge
{

      public interface IRenderer
      {
          string WhatToRenderAs {get;}
      }
      
      public class VectorRenderer : IRenderer 
      {
          public VectorRenderer()
          {
              
          }
          public string WhatToRenderAs => "as lines";
      }
      
      public class RasterRenderer : IRenderer
      {
          public RasterRenderer()
          {
              
          }
          public string WhatToRenderAs => "as pixels";
      }
      
    public abstract class Shape
    {
        
      public virtual string Name { get; set; }
      protected IRenderer renderer;
      protected Shape(IRenderer renderer)
      {
          this.renderer = renderer;
      }
      
      public override string ToString() => $"Drawing {Name} {renderer.WhatToRenderAs}";
      }
    

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
      {
          
      }
      
      public override string Name => "Triangle";
      
    }

    public class Square : Shape
    {
      public Square(IRenderer renderer) : base(renderer)
      {
         
      }
      public override string Name => "Square";
    }

    public class VectorSquare : Square
    {
      public VectorSquare() : base(new VectorRenderer())
      {}
      
      public VectorSquare(IRenderer renderer) : base(renderer)
      {}
    }

    public class RasterSquare : Square
    {
         public RasterSquare() : base(new RasterRenderer())
      {}
      
      public RasterSquare(IRenderer renderer) : base(renderer)
      {}
    }

    // imagine VectorTriangle and RasterTriangle are here too


}

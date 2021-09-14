using System;
using static System.Console;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;


namespace Structural.Adapter
{
 
    public class Square
    {
      public int Side;
    }

    public interface IRectangle
    {
      int Width { get; }
      int Height { get; }
    }
    
    public static class ExtensionMethods
    {
      public static int Area(this IRectangle rc)
      {
        return rc.Width * rc.Height;
      }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        private Square square;
        public SquareToRectangleAdapter(Square square)
        {
            this.square = square;
        }
        
        public int Width => square.Side;
        public int Length => square.Side;
        
    }
    
   
}

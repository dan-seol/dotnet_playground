using System;
using System.Xml.Serialization;
using System.IO;

namespace Prototype
{
   /*  public static class ExtensionMethodsOnes
    {

        public static T DeepCopy<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T) s.Deserialize(ms);
            }
        }
    } */

     public class Point
    {
      public int X, Y;
    }

    public class Line
    {
      public Point Start, End;

        //SOLUTION 1
      /* public Line DeepCopy()
      {
        // todo
        Line l = new Line();
        Point start = new Point();
        Point end = new Point();
        start.X = Start.X;
        start.Y = Start.Y;
        end.X = End.X;
        end.Y = End.Y;
        l.Start = start;
        l.End = end;
        return l;
        
      } */
    }
}

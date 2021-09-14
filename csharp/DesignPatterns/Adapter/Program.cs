using System;
using static System.Console;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Autofac.Features.Metadata;

namespace Structural.Adapter
{
    class Program
    {
        private static readonly List<VectorObject> vectorObjects
        = new List<VectorObject> { new VectorRectangle(1,1,10,10), new VectorRectangle(3,3,6,6)};
        public static void DrawPoint(Point p)
        {
            Write(".");
        }
        static void Main(string[] args)
        {
           // Draw();
            // Draw();
            var v1 = new Vector2d();
            v1[0] = 1;
            v1[1] = 2;
            var v2 = new Vector2d(3, 2);
            var w = v1 + v2;
            AnotherVector3i u = AnotherVector3i.Create(3, 2, 1);

            var b = new ContainerBuilder();
            b.RegisterType<SaveCommand>().As<ICommand>().WithMetadata("Name", "Save");
            b.RegisterType<OpenCommand>().As<ICommand>().WithMetadata("Name", "Open");
            //b.RegisterType<Button>(); // only get one button
            //b.RegisterAdapter<ICommand, Button>(cmd => new Button(cmd));
            b.RegisterAdapter<Meta<ICommand>, Button>(cmd => new Button(cmd.Value, (string)cmd.Metadata["Name"]));
            b.RegisterType<Editor>();

            using (var c = b.Build())
            {
                var editor = c.Resolve<Editor>();
                //editor.ClickAll();
                foreach (var btn in editor.Buttons)
                {
                    btn.PrintMe();
                }
            }

        }

        private static void Draw()
        {
            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    foreach (var p in adapter)
                    {
                        DrawPoint(p);
                    }
                }
                
            }
        }
    }
}

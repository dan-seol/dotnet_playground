using System;
using static System.Console;
using Autofac;

namespace StructuralBridge
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRenderer: IRenderer
    {
        public void RenderCircle(float radius)
        {
            WriteLine($"Drawing a circle of radius {radius}");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            WriteLine($"Drawing pixels for circle with radius {radius}");
        }
    }

    public abstract class Shape
    {
        //bridging happens
        //you don't let shape determine the render
        protected IRenderer renderer;

        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer ?? throw new ArgumentNullException(paramName:nameof(renderer));
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {
        private float radius;
        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            radius *= factor;
        }

    
    }

    class Program
    {
        static void Main(string[] args)
        {
            IRenderer renderer = new RasterRenderer();
            IRenderer renderer2 = new VectorRenderer();
            var circle = new Circle(renderer2, 5);
            circle.Draw();
            circle.Resize(2);
            circle.Draw();

            var cb = new ContainerBuilder();
            cb.RegisterType<VectorRenderer>().As<IRenderer>()
            .SingleInstance();
            cb.Register((c,p) => new Circle(c.Resolve<IRenderer>(), p.Positional<float>(0)));

            using (var c = cb.Build())
            {
                var circle2 = c.Resolve<Circle>(new PositionalParameter(0, 5.0f)); //no automatic conv
                circle2.Draw();
                circle2.Resize(2);
                circle2.Draw();
            }
        }
    }
}

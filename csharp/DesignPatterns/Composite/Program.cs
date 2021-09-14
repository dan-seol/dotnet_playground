using System;

namespace Structural.Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var drawing = new GraphicObject {Name = "My Drawing"};
            drawing.Children.Add(new Square{ Color = "Red"});
            drawing.Children.Add(new Circle{ Color = "Yellow"});

            var group = new GraphicObject();
            group.Children.Add(new Circle{ Color = "Blue"});
            group.Children.Add(new Square{ Color = "Blue"});

            drawing.Children.Add(group);

            Console.WriteLine(drawing);

            var neuron1 = new Neuron();
            var neuron2 = new Neuron();
            neuron1.ConnectTo(neuron2); //1

            var layer1 = new NeuronLayer();
            var layer2 = new NeuronLayer();
            // 4
            neuron1.ConnectTo(layer1);
            layer1.ConnectTo(layer2);
        }
    }
}

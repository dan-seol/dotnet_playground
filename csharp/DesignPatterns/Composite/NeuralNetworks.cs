using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text;

namespace Structural.Composite
{

  public static class ExtensionMethods
  {
    public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
    {
      if (ReferenceEquals(self, other)) return;
      foreach (var from in self)
      {
        foreach(var to in other)
        {
          from.Out.Add(to);
          to.In.Add(from);
        }
      }
    }
  }

  public class Neuron : IEnumerable<Neuron>
  {
      public float Value;
      public List<Neuron> In = new List<Neuron>();
      public List<Neuron> Out = new List<Neuron>();

      // public void ConnectTo(Neuron other)
      // {
      //     Out.Add(other);
      //     other.In.Add(this);
      // }

      public IEnumerator<Neuron> GetEnumerator()
      {
        yield return this;
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
        return GetEnumerator();
      }
  }

  public class NeuronLayer : Collection<Neuron>
  {

  }

  // public class NeuronRing : List<Neuron>
  // {
    
  // }
}

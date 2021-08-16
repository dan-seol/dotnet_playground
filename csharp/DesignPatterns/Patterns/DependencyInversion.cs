using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Patterns
{
   //high level parts of the system should not directly depend on low level parts
   //they would need to depend on some abstraction
   public enum Relationship
    {
        Parent,
        Child,
        Sibling,
        Friends
    }

    public class Person
    {
        public string Name;
        //public DateTime DateOfBirth
    }
    
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    //low-level
    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations
        = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((child, Relationship.Child, parent));
            relations.Add((parent, Relationship.Parent, child));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            // now how relationship stores the info is forced to be fixed
            foreach (var r in relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent))
            {
                yield return r.Item3;
            }
        }

        //exposes the private relations to public - violates the princpple
        //public List<(Person, Relationship, Person)> Relations => relations;
    }

    public class Research
    {
        /*public Research(Relationships relationships)
        {
            var relations = relationships.Relations;
            // now how relationship stores the info is forced to be fixed
            foreach (var r in relations.Where(x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent))
            {
                Console.WriteLine($"John has a child called {r.Item3.Name}");
            }
        }*/

        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a children {p.Name}");
            }
        }
    }
}

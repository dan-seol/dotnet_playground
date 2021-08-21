using System;

namespace Factory
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }

    public class PersonFactory
    {
        int count = 0;
        public Person CreatePerson(string name)
        {
            Person p = new Person { Id = count, Name = name };
            count++;
            return p;
        }

        public override string ToString()
        {
            return $"Person factory having created {count} people";
        }
    }
}

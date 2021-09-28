using System;
using Dynamitey;

namespace Proxy
{
    public class Person
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson
    {
        private readonly Person person;
        public ResponsiblePerson(Person person)
        {
            // todo
            this.person = person;
        }

        public int Age
        {
            get => person.Age;
            set => person.Age = value;
        }

        public string Drink()
        {
            return Age >= 18 ? person.Drink() : "too young";
        }

        public string Drive()
        {
            return Age >= 18 ? person.Drive() : "too young";
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }
    }
}


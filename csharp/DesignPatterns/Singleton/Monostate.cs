using System;

namespace Singleton
{
    //if we are using singleton,
    //why shouldn't we make everything static?
    //it wouldn't even have a constructor
    //testability concern remains
    //cannot use dependency injection
    //there exists a variation of Singleton called monostate
    //it uses static members in a bizarre way
    public class CEO
    {
        private static string name;
        private static int age;

        public string Name 
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }

        //typically singleton is used to prevent constructor
        //here it's the opposite
    } 

}

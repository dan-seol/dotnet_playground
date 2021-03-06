using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using JetBrains.dotMemoryUnit.Properties;
using NUnit.Framework;

//dotnet add package JetBrains.DotMemoryUnit --version 3.1.20200127.214830
namespace Flyweight
{
    public class User
    {
        private string fullName;
        public User(string fullName)
        {
            this.fullName = fullName;
        }
    }

    public class User2
    {
        private static List<string> strings = new List<string>();
        private int[] names;

        public User2(string fullName)
        {
            int getOrAdd(string s)
            {
                int idx = strings.IndexOf(s);
                if (idx != -1) return idx;
                else
                {
                    strings.Add(s);
                    return strings.Count - 1;
                }
            }

            names = fullName.Split(' ').Select(getOrAdd).ToArray();
        }

        public string FullName => string.Join(' ', names.Select(i => strings[i]).ToArray());
    }
}


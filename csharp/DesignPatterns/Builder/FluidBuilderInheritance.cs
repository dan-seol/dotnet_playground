using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Builder
{
  public class Employee
    {
        public string Name;
        public string Position;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
        public class Builder : EmployeeJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();
    }

    public abstract class EmployeeBuilder
    {
        protected Employee employee = new Employee();

        public Employee Build()
        {
            return employee;
        }

    }

    //the issue will be solved using recursive generics
    //self actually refers to the object inheriting from 
    //class Foo : Bar<Foo>
    public class EmployeeInfoBuilder<SELF> : EmployeeBuilder 
        where SELF : EmployeeInfoBuilder<SELF>
    {

        public SELF Called(string name)
        {
            employee.Name = name;
            return (SELF) this;
        }
 
    }

    public class EmployeeJobBuilder<SELF> : EmployeeInfoBuilder<SELF>
        where SELF : EmployeeJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            employee.Position = position;
            return (SELF) this;
        }
    }

 
}

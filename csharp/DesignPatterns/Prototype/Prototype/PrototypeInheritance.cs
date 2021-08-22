using System;

namespace Prototype
{

    // public interface IDeepCopyable<T>
    // {
    //     T DeepCopy();
    // }

    public interface IDeepCopyable<T>
    where T : new() // blank slate requirment; needed
    {
        void CopyTo(T target);

        public T DeepCopy() //in csharp, you can give interface a body!
        {
            T t = new T();
            CopyTo(t);
            return t;
        }
    }

    public class AddressThree : IDeepCopyable<AddressThree>
    {
        public string StreetName;
        public int HouseNumber;
        public AddressThree() 
        {

        }

        public AddressThree(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

       /*  public AddressThree DeepCopy()
        {
            return (AddressThree) MemberwiseClone();
        } */

        public void CopyTo(AddressThree target)
        {
            target.StreetName = StreetName;
            target.HouseNumber = HouseNumber; //cannot use memberwise clone
        }

    }

    public class PersonThree : IDeepCopyable<PersonThree>
    {
        public string[] Names;
        public AddressThree Address;

        public PersonThree()
        {

        }

        public PersonThree(string[] names, AddressThree address)
        {
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        public void CopyTo(PersonThree target)
        {
            target.Names = (string[]) Names.Clone();
            target.Address = Address.DeepCopy(); //broken!
            //target.Address = ((IDeepCopyable<AddressThree>)Address).DeepCopy(); //one legal approach
            //target.Address = ExtensionMethods.DeepCopy(Address); //now it works
        }
       /*  public PersonThree DeepCopy()
        {
            return new PersonThree((string[])Names.Clone(), Address.DeepCopy());
        } */
    }

    public class Employee : PersonThree, IDeepCopyable<Employee>
    {
        public int Salary;

        public Employee()
        {

        }

        public Employee(string[] names, AddressThree address, int salary) : base(names, address)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return base.ToString() + $", {nameof(Salary)}: {Salary}";
        }

        public void CopyTo(Employee target)
        {
            base.CopyTo(target);
            target.Salary = Salary;
        }

       /*  public new Employee DeepCopy()
        {
            return new Employee((string[]) Names.Clone(), Address.DeepCopy(), Salary);
        } */
    }

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this IDeepCopyable<T> item) 
        where T: new()
        {
            return item.DeepCopy();
        }

        public static T DeepCopy<T>(this T person)
        where T : PersonThree, new()
        {
            return ((IDeepCopyable<T>)person).DeepCopy();
        }
    }

    //for constructors with many arguments, the approach where we need to write constructors 
    //for both the base class and the derived class is not scalable.
}

using System;

namespace Prototype
{
    public class Person : ICloneable
    {
        public string[] Names;
        public Address Address;

        //ICloneable doesn't specify the implementation of clone - shallow or deep?
        //it returns a general object instead of the type itself
        //not scalable -- what if highly nested?
        public Person(string[] names, Address address) 
        {
            if (names == null)
            {
                throw new ArgumentNullException(paramName: nameof(names));
            }
            
            if (address == null)
            {
                throw new ArgumentNullException(paramName: nameof(names));
            }
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        public object Clone()
        {
            //            return new Person(this.Names, this.Address); //shallow
            // this.Names.Clone() ? would return a shallow copy
            return new Person(this.Names, (Address) this.Address.Clone()); //forced manual deep copy
        }
    }

    public class Address : ICloneable
    {
        private string StreetName;
        public int HouseNumber;
        public Address(string streetName, int houseNumber) 
        {
            this.StreetName = streetName;
            this.HouseNumber = houseNumber;
        }
        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }
    }
}

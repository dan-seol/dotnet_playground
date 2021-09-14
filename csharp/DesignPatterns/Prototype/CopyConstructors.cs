using System;

namespace Prototype
{
    public class PersonOne
    {
        public string[] Names;
        public AddressOne Address;

        //ICloneable doesn't specify the implementation of clone - shallow or deep?
        //it returns a general object instead of the type itself
        //not scalable -- what if highly nested?
        public PersonOne(string[] names, AddressOne address) 
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

        public PersonOne(PersonOne other)
        {
            //Names = other.Names;
            //Address = other.Address;             // not sufficient as this is a shallow copy
            Names = new string[other.Names.Length];
            Array.Copy(other.Names, Names, other.Names.Length);
            Address = new AddressOne(other.Address);

        }
        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

    }

    public class AddressOne
    {
        private string StreetName;
        public int HouseNumber;
        public AddressOne(string streetName, int houseNumber) 
        {
            this.StreetName = streetName;
            this.HouseNumber = houseNumber;
        }
        public AddressOne(AddressOne other)
        {
            this.StreetName = other.StreetName;
            this.HouseNumber = other.HouseNumber;
        }
        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

    }
}

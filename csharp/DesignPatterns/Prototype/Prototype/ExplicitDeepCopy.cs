using System;

namespace Prototype
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }
    public class PersonTwo : IPrototype<PersonTwo>
    {
        public string[] Names;
        public AddressTwo Address;


        public PersonTwo(string[] names, AddressTwo address) 
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

        public PersonTwo DeepCopy() 
        {
            string[] newNames = new string[Names.Length];
            Array.Copy(Names, newNames, Names.Length);
            return new PersonTwo(newNames, Address.DeepCopy());
        }
        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

    }

    public class AddressTwo : IPrototype<AddressTwo>
    {
        private string StreetName;
        public int HouseNumber;
        public AddressTwo(string streetName, int houseNumber) 
        {
            this.StreetName = streetName;
            this.HouseNumber = houseNumber;
        }
        public AddressTwo DeepCopy()
        {
            return new AddressTwo(StreetName, HouseNumber);
        }
        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

    }
}

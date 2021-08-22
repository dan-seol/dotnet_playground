using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Prototype
{

    public static class ExtensionMethodsOnes
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T) copy;
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T) s.Deserialize(ms);
            }
        }
    }

    [Serializable] //needed for binary serialization
    public class PersonFour
    {
        public string[] Names;
        public AddressFour Address;

        //needed for xml 
        public PersonFour()
        {

        }

        //ICloneable doesn't specify the implementation of clone - shallow or deep?
        //it returns a general object instead of the type itself
        //not scalable -- what if highly nested?
        public PersonFour(string[] names, AddressFour address) 
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

    }
    
    [Serializable] // binary serialization
    public class AddressFour
    {
        public string StreetName;
        public int HouseNumber;

        //xml serialization
        public AddressFour() {

        }

        public AddressFour(string streetName, int houseNumber) 
        {
            this.StreetName = streetName;
            this.HouseNumber = houseNumber;
        }
        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

    }
}

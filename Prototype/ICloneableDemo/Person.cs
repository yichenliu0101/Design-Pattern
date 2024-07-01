using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICloneableDemo
{
    public class Person : IPrototype<Person>//: ICloneable
    {
        public string[] Names { get; set; }
        public Address Address;

        public Person(string[] names, Address address)
        {
            if (names == null)
            {
                throw new ArgumentNullException(paramName: nameof(names));
            }

            if (address == null)
            {
                throw new ArgumentNullException(paramName: nameof(address));
            }

            Names = names;
            Address = address;
        }

        public Person(Person other)
        {
            Names = other.Names;
            Address = new Address(other.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        public Person DeepCopy()
        {
            return new Person(Names, Address.DeepCopy());
        }

        //public object Clone()
        //{
        //    return new Person(Names, (Address)Address.Clone());
        //}
    }

    public class Address : IPrototype<Address>//: ICloneable
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public Address DeepCopy()
        {
            return new Address(StreetName, HouseNumber);
        }

        /// <summary>
        /// Deep copy
        /// </summary>
        /// <returns></returns>
        //public object Clone()
        //{
        //    return new Address(StreetName, HouseNumber);
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeInheritance
{
    public interface IDeepCopyable<T>
        where T : new()
    {
        //T DeepCopy();
        void CopyTo(T target);

        public T DeepCopy()
        {
            T t = new T();
            CopyTo(t);
            return t;
        }
    }

    public class Address : IDeepCopyable<Address>
    {
        public string StreetAddress { get; set; }
        public int HouseNumber { get; set; }

        public Address()
        {

        }

        public Address(string streetAddress, int houseNumber)
        {
            StreetAddress = streetAddress;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        //public Address DeepCopy()
        //{
        //    return (Address)MemberwiseClone();
        //}

        public void CopyTo(Address target)
        {
            target.StreetAddress = StreetAddress;
            target.HouseNumber = HouseNumber;
        }
    }

    public class Person : IDeepCopyable<Person>
    {
        public string[] Names { get; set; }
        public Address Address { get; set; }

        public Person()
        {

        }

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        //public Person DeepCopy()
        //{
        //    return new Person((string[])Names.Clone(), Address.DeepCopy());
        //}

        public void CopyTo(Person target)
        {
            target.Names = (string[])Names.Clone();
            target.Address = Address.DeepCopy();
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(",", Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class Employee : Person, IDeepCopyable<Employee>
    {
        public int Salary { get; set; }

        public Employee()
        {

        }

        public Employee(string[] names, Address address, int salary) : base(names, address)
        {
            Salary = salary;
        }

        //public Employee DeepCopy()
        //{
        //    return new Employee((string[])Names.Clone(), Address.DeepCopy(), Salary);
        //}

        public void CopyTo(Employee target)
        {
            base.CopyTo(target);
            target.Salary = Salary;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Salary)}: {Salary}";
        }
    }

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this IDeepCopyable<T> item)
            where T : new()
        {
            return item.DeepCopy();
        }

        public static T DeepCopy<T>(this T person)
            where T : Person, new()
        {
            return ((IDeepCopyable<T>)person).DeepCopy();
        }
    }
}

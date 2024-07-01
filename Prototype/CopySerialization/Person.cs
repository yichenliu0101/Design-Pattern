using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CopySerialization
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            using (var stream = new MemoryStream())
            {
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true, // 启用字段支持
                    PropertyNameCaseInsensitive = true // 忽略属性名大小写
                };

                JsonSerializer.Serialize(stream, self, options);

                stream.Seek(0, SeekOrigin.Begin);

                T copy = JsonSerializer.Deserialize<T>(stream, options);

                return copy;
            }
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new XmlSerializer(typeof(T));
                formatter.Serialize(stream, self);
                stream.Position = 0;
                T copy = (T)formatter.Deserialize(stream);
                return copy;
            }
        }
    }

    [Serializable]
    public class Person
    {
        public string[] Names { get; set; }
        public Address Address;

        public Person()
        {

        }

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
    }

    [Serializable]
    public class Address
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public Address()
        {

        }

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
    }
}

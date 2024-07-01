using PrototypeInheritance;
using System.Runtime.InteropServices;

var john = new Employee();
john.Names = new[] { "John", "Doe" };
john.Address = new Address()
{
    HouseNumber = 123,
    StreetAddress = "London Road"
};
john.Salary = 100000;

//var copy = john.DeepCopy();
//copy.Names[1] = "Smith";
//copy.Address.HouseNumber++;
//copy.Salary = 50000;

var copy = john.DeepCopy();
copy.Names[1] = "Smith";
copy.Address.HouseNumber++;
copy.Salary = 50000;
var e = john.DeepCopy<Employee>();
var p = john.DeepCopy<Person>();

Console.WriteLine(john);
Console.WriteLine(copy);
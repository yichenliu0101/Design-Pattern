using CopySerialization;

var john = new Person(new[] { "John", "Doe" }, new Address("London Road", 123));

//var jane = john.DeepCopy();
var jane = john.DeepCopyXml();
jane.Names[0] = "Jane";
jane.Address.HouseNumber = 321;

Console.WriteLine(john);
Console.WriteLine(jane);
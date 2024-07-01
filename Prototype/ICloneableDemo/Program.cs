using ICloneableDemo;

var john = new Person(new[] { "John", "Doe" }, new Address("London Road", 123));

//var jane = john;
//jane.Nmaes[0] = "Jane";

//IClonable
//var jane = (Person)john.Clone();
//jane.Address.HouseNumber = 321;

//Copy Constructor
//var jane = new Person(john);
//jane.Address.HouseNumber = 321;

//Use self interface
var jane = john.DeepCopy();
jane.Address.HouseNumber = 321;

Console.WriteLine(john);
Console.WriteLine(jane);
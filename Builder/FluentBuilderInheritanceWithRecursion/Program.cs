using FluentBuilderInheritanceWithRecursion;

var person = Person.New
    .Called("Dsk")
    .WorksAsA("Engineer")
    .Build();

Console.WriteLine(person);
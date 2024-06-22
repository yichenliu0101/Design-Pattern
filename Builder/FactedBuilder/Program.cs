using FactedBuilder;

var pb = new PersonBuilder();
Person peron = pb
    .Lives.At("123 London Road")
        .In("London")
        .WithPostCode("SW12AC")
    .Works.At("Fabrikam")
        .AsA("Engineer")
        .Earning(123000);

Console.WriteLine(peron);
using AbstractFactory;

//var machine = new HotDrinkMachine();
//var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
//drink.Consume();

var machine = new HotDrinkMachine();
var drink = machine.MakeDrink();
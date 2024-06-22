using StepWiseBuilder;

var car = CarBuilder.Create() //ISpecifyCarType
    .OfType(CarType.Crossover) //ISpecifyWheelSize
    .WithWheels(18) //IBuildCar
    .Build();
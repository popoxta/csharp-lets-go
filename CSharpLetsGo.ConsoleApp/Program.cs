var dice = new Random();
var roll = dice.Next(1, 7);

Random secondDice = new();

Console.WriteLine($"The dice roll is: {roll}!!!");

Console.WriteLine($"The dice roll is: {secondDice.Next(1, 7)}!!!");
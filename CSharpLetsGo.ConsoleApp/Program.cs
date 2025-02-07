// 01. Class Math Exercise

Console.WriteLine("01. Class Math Exercise\n");

const int firstValue = 500;
const int secondValue = 600;

var largerValue = Math.Max(firstValue, secondValue);

Console.WriteLine($"The larger value is {largerValue}!!!\nAin't that obvious!");

SeparateLines();

// 0.2 Random Dice Roll Logic

var diceRolls = new int[3].Select(_ => GetRandomDiceRoll()).ToArray();
var total = diceRolls.Sum();

foreach (var roll in diceRolls.Select((value, i) => new { value, i })) 
    Console.WriteLine($"Dice roll {roll.i}: {roll.value}");

Console.WriteLine($"Total Score of the rolls is {total}!!!");
Console.WriteLine(total > 14 ? "You won the dice roll!" : "You lost the dice roll!");

return;

static int GetRandomDiceRoll() => new Random().Next(1, 7);

static void SeparateLines() => Console.WriteLine("\n----\n");
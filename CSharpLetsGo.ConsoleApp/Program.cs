// 01. Class Math Exercise

Console.WriteLine("01. Class Math Exercise\n");

const int firstValue = 500;
const int secondValue = 600;

var largerValue = Math.Max(firstValue, secondValue);

Console.WriteLine($"The larger value is {largerValue}!!!\nAin't that obvious!");

SeparateLines();

// 0.2 Random Dice Roll Logic

var diceRolls = new int[3].Select(_ => GetRandomDiceRoll()).ToArray();

var isDouble = diceRolls.Any(roll => diceRolls.Count(el => el == roll) >= 2);
var isTriple = diceRolls.All(roll => roll == diceRolls[0]);

var rollSum = diceRolls.Sum();
var total = isTriple ? rollSum + 3 : isDouble ? rollSum + 2 : rollSum;

foreach (var roll in diceRolls.Select((value, i) => new { value, i }))
    Console.WriteLine($"Dice roll {roll.i}: {roll.value}");

Console.WriteLine();

if (isTriple) Console.WriteLine("You got a triple! +3 score to total!");
else if (isDouble) Console.WriteLine("You got a double! +2 score to total!");

Console.WriteLine($"Total Score of the rolls is {total}!!!");
Console.WriteLine(total > 14 ? "You won the dice roll!" : "You lost the dice roll!");

return;

static int GetRandomDiceRoll() => new Random().Next(1, 7);

static void SeparateLines() => Console.WriteLine("\n----\n");
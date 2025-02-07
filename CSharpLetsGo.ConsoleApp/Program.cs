// 01. Class Math Exercise

Console.WriteLine("01. Class Math Exercise\n");

const int firstValue = 500;
const int secondValue = 600;

var largerValue = Math.Max(firstValue, secondValue);

Console.WriteLine($"The larger value is {largerValue}!!!\nAin't that obvious!");

SeparateLines();

return;

static void SeparateLines() => Console.WriteLine("\n----\n");
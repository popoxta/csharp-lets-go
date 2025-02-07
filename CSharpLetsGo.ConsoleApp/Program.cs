var dice = new Random();


Console.WriteLine($"First roll: {dice.Next()}");
Console.WriteLine($"Second roll: {dice.Next(101)}");
Console.WriteLine($"Third roll: {dice.Next(50, 101)}");
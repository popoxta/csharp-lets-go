// 01. Class Math Exercise

Console.WriteLine("01. Class Math Exercise\n");

const int firstValue = 500;
const int secondValue = 600;

var largerValue = Math.Max(firstValue, secondValue);

Console.WriteLine($"The larger value is {largerValue}!!!\nAin't that obvious!");

SeparateLines();

// 0.2 Random Dice Roll Logic

Console.WriteLine("02. Dice Roll Logic\n");

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

var playerPrizeMessage =
    total >= 16 ? "Jackpot - you get a new Ford Fiesta!" :
    total >= 10 ? "You get an IBM Model M Babey!" :
    total == 7 ? "You're getting a one way ride to the LinHood!" :
    "You lost the dice roll! But you get this kitten. Meow.";

Console.WriteLine(playerPrizeMessage);

SeparateLines();

// 0.3 Subscription Renewal Message

var daysUntilExpiration = new Random().Next(12);

var expirationMessage =
    daysUntilExpiration == 0 ? "Your subscription has expired!" :
    daysUntilExpiration == 1 ? "Your subscription expires within a day! Renew now and save 20%!" :
    daysUntilExpiration <= 5 ? $"Your subscription expires in {daysUntilExpiration} days! Renew now and save 10%!" :
    daysUntilExpiration <= 10 ? $"Your subscription will expire in {daysUntilExpiration} days! Renew now!" :
    "";

Console.WriteLine(expirationMessage);

SeparateLines();

// 0.4 Order ID Reporting

string[] orderIds =
[
    "B123",
    "C234",
    "A345",
    "C15",
    "B177",
    "G3003",
    "C235",
    "B179"
];

string[] ordersToBeInvestigated = [];

foreach (var orderId in orderIds)
{
    if (!orderId.StartsWith("b", StringComparison.CurrentCultureIgnoreCase)) continue;
    ordersToBeInvestigated = ordersToBeInvestigated.Concat([orderId]).ToArray();
    Console.WriteLine($"There are currently {ordersToBeInvestigated.Length} orders to be investigated!");
}

Console.WriteLine(
    $"The {ordersToBeInvestigated.Length} orders to be investigated are {string.Join(", ", ordersToBeInvestigated)}!");

SeparateLines();

// 0.5 Exam Result Reporting

const int currentAssignments = 5;

Student[] students =
[
    new("Sophia", [90, 86, 87, 98, 100, 94, 90]),
    new("Andrew", [92, 89, 81, 96, 90, 89]),
    new("Emma", [90, 85, 87, 98, 68, 89, 89, 89]),
    new("Logan", [90, 95, 87, 88, 96, 96]),
    new("Becky", [92, 91, 90, 91, 92, 92, 92]),
    new("Chris", [84, 86, 88, 90, 92, 94, 96, 98]),
    new("Eric", [80, 90, 100, 80, 90, 100, 80, 90]),
    new("Gregor", [91, 91, 91, 91, 91, 91, 91])
];

Console.WriteLine("Student\t\tScore\t\tGrade");

foreach (var student in students)
{
    var totalScore = CalculateStudentScore(student.Results);
    Console.WriteLine($"{student.Name}\t\t {totalScore}\t\t {GetStudentGrade(totalScore)}");
}

return;

static int GetRandomDiceRoll() => new Random().Next(1, 7);

static void SeparateLines() => Console.WriteLine("\n----\n");

static decimal CalculateStudentScore(int[] results)
{
    var examScore = (decimal)results.Take(currentAssignments).ToArray().Sum();
    var extraCreditResults = results.Skip(currentAssignments).ToArray();

    if (extraCreditResults.Length == 0) return examScore / currentAssignments;

    return ((decimal)extraCreditResults.Sum() / 10 + examScore) / currentAssignments;
}

static string GetStudentGrade(decimal score) =>
    score switch
    {
        >= 97 => "A+",
        >= 93 => "A",
        >= 90 => "A-",
        >= 87 => "B+",
        >= 83 => "B",
        >= 80 => "B-",
        >= 77 => "C+",
        >= 73 => "C",
        >= 70 => "C-",
        >= 67 => "D+",
        >= 63 => "D",
        >= 60 => "D-",
        _ => "F"
    };

internal record Student(string Name, int[] Results);
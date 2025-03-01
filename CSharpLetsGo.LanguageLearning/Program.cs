// 01. Class Math Exercise

using System.Text.RegularExpressions;

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

var playerPrizeMessage = total switch
{
    >= 16 => "Jackpot - you get a new Ford Fiesta!",
    >= 10 => "You get an IBM Model M Babey!",
    7 => "You're getting a one way ride to the LinHood!",
    _ => "You lost the dice roll! But you get this kitten. Meow."
};

Console.WriteLine(playerPrizeMessage);

SeparateLines();

// 0.3 Subscription Renewal Message

var daysUntilExpiration = new Random().Next(12);

var expirationMessage = daysUntilExpiration switch
{
    0 => "Your subscription has expired!",
    1 => "Your subscription expires within a day! Renew now and save 20%!",
    <= 5 => $"Your subscription expires in {daysUntilExpiration} days! Renew now and save 10%!",
    <= 10 => $"Your subscription will expire in {daysUntilExpiration} days! Renew now!",
    _ => ""
};

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

Console.WriteLine("Student\t\tScore\t\tExtra Score\t\tOverall Score\tGrade");

foreach (var student in students)
{
    var studentScore = GetStudentScores(student.Results);
    Console.WriteLine(
        $"{student.Name}\t\t" +
        $"{studentScore.Score}\t\t" +
        $"{studentScore.ExtraScore}({studentScore.ExtraScorePoints} pts)\t\t" +
        $"{studentScore.OverallScore}\t\t" +
        $"{GetStudentGrade(studentScore.OverallScore)}");
}

SeparateLines();

// 0.6 Permissions

const string permission = "Admin|Manager";
const int level = 55;

var isAdmin = permission.Contains("admin", StringComparison.CurrentCultureIgnoreCase);
var isManager = permission.Contains("manager", StringComparison.CurrentCultureIgnoreCase);

if (!isAdmin && !isManager) Console.WriteLine("You do not have sufficient privileges.");

if (isAdmin) Console.WriteLine($"Welcome, {(level > 55 ? "Super Admin" : "Admin")} user.");
else if (isManager && level > 20) Console.WriteLine("Contact an Admin for access.");
else Console.WriteLine("You do not have sufficient privileges.");

SeparateLines();

// 0.7 FizzBuzz

for (var i = 1; i <= 100; i++)
{
    var isDivisibleByThree = i % 3 == 0;
    var isDivisibleByFive = i % 5 == 0;

    Console.Write($"\n{i} ");
    if (isDivisibleByFive && isDivisibleByThree) Console.Write("FizzBuzz!");
    else if (isDivisibleByFive) Console.Write("Buzz!");
    else if (isDivisibleByThree) Console.Write("Fizz!");
}

SeparateLines();

// 0.8 NPC RPG

var monsterHealth = 10;
var playerHealth = 10;

do
{
    var playerAttackDamage = GetRandomAttackDamage();
    monsterHealth -= playerAttackDamage;
    Console.WriteLine($"The monster was attacked for {playerAttackDamage} damage! HP: {monsterHealth}");
    if (monsterHealth <= 0) continue;

    var monsterAttackDamage = GetRandomAttackDamage();
    playerHealth -= monsterAttackDamage;
    Console.WriteLine($"The player was attacked for {monsterAttackDamage} damage! HP: {playerHealth}");
} while (monsterHealth > 0 && playerHealth > 0);

Console.WriteLine($"The battle is over! The winner is {(playerHealth <= 0 ? "Monster" : "Player")}!");

SeparateLines();

// 0.9 Math operation output

const int intValue = 11;
const decimal decimalValue = 6.2m;
const float floatValue = 4.3f;

Console.WriteLine($"The first result is {Convert.ToInt32(intValue / decimalValue)}");
Console.WriteLine($"The second result is {decimalValue / (decimal)floatValue}");
Console.WriteLine($"The third result is {floatValue / intValue}");

SeparateLines();

// 0.10 Reverse words in a string

const string pangram = "The quick brown fox jumps over the lazy dog";

var reversed = string.Join(' ', pangram.ToLower()
    .Split(' ')
    .Select(word => new string(word.Reverse().ToArray())));

Console.WriteLine(pangram);
Console.WriteLine(reversed);

SeparateLines();

// 0.11 Parse orders

const int orderNumberSize = 4;
const string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";

foreach (var order in orderStream.Split(',').OrderBy(order => order))
{
    Console.Write($"\n{order}");
    if (order.Length != orderNumberSize) Console.Write("\t- Error in order number!");
}

SeparateLines();

// 0.12 String indexing

const string parenthesesMessage = "Find what is (inside the parentheses)";

var openingPosition = parenthesesMessage.IndexOf('(');
var closingPosition = parenthesesMessage.IndexOf(')');

var lengthOfCharactersBetweenParentheses = closingPosition - openingPosition - 1;

var contentBetweenParentheses = parenthesesMessage.Substring(openingPosition + 1, lengthOfCharactersBetweenParentheses);

Console.WriteLine($"Content between the parentheses: {contentBetweenParentheses}");

SeparateLines();

// 0.13 Modifying string data

const string rawHtmlInput = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

var quantity = LocalRegex.SpanRegex().Match(rawHtmlInput).Groups[1].Value;

Console.WriteLine($"<h2>Widgets &reg;</h2><span>{quantity}</span>");

return;

static int GetRandomAttackDamage() => new Random().Next(1, 11);

static int GetRandomDiceRoll() => new Random().Next(1, 7);

static void SeparateLines() => Console.WriteLine("\n----\n");

StudentScore GetStudentScores(int[] results)
{
    var totalExamScore = (decimal)results.Take(currentAssignments).Sum();
    var extraCreditResults = results.Skip(currentAssignments).ToArray();

    var examScore = totalExamScore / currentAssignments;
    var extraCreditTotalScore = (decimal)extraCreditResults.Sum();
    var extraCreditScore = extraCreditTotalScore / extraCreditResults.Length;
    var extraCreditPoints = extraCreditTotalScore / 10 / currentAssignments;

    var overallScore = extraCreditPoints + examScore;

    return new StudentScore(
        Score: examScore,
        ExtraScore: extraCreditScore,
        ExtraScorePoints: extraCreditPoints,
        OverallScore: overallScore
    );
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

internal record Student(
    string Name,
    int[] Results
);

internal record StudentScore(
    decimal Score,
    decimal ExtraScore,
    decimal ExtraScorePoints,
    decimal OverallScore
);

internal static partial class LocalRegex
{
    [GeneratedRegex(@"<span>(\d+)</span>")]
    public static partial Regex SpanRegex();
}
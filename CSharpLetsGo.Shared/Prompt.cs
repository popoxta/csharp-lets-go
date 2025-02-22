namespace CSharpLetsGo.Shared;

public static class Prompt
{
    private static void WritePromptIfNotNull(string? prompt)
    {
        if (prompt is not null) Console.WriteLine(prompt);
    }

    /// <summary>
    /// Prompts the user for an integer input until a valid integer input is given.
    /// </summary>
    /// <param name="prompt">Optional prompt that is displayed to the user.</param>
    /// <param name="max">Maximum possible value for the input.</param>
    /// <param name="min">Minimum possible value for the input.</param>
    /// <returns>An integer representing the numeric input given by the user.</returns>
    public static int GetInt(string? prompt, int max = int.MaxValue, int min = int.MinValue)
    {
        int result;
        WritePromptIfNotNull(prompt);
        while (!int.TryParse(Console.ReadLine(), out result) && result >= min && result <= max) ;
        return result;
    }

    /// <summary>
    /// Prompts the user for a string input until a valid input is given.
    /// </summary>
    /// <param name="prompt">Optional prompt that is displayed to the user.</param>
    /// <returns></returns>
    public static string GetString(string? prompt)
    {
        var input = "";
        WritePromptIfNotNull(prompt);
        while (string.IsNullOrEmpty(input)) input = Console.ReadLine()?.Trim() ?? "";
        return input;
    }

    /// <summary>
    /// Returns a bool indicating if the user entered Yes (y) or No (n)
    /// </summary>
    /// <param name="prompt">Optional prompt that is displayed to the user.</param>
    /// <returns></returns>
    public static bool YesOrNo(string? prompt)
    {
        WritePromptIfNotNull(prompt);
        Console.WriteLine("y: Yes\nn: No");
        var input = "";
        while (input is not ("y" or "n")) input = Console.ReadLine()?.Trim() ?? "";
        return input == "y";
    }

    /// <summary>
    /// Prompts the user to press enter to continue.
    /// </summary>
    public static void PressEnterToContinue()
    {
        Console.WriteLine("Press enter to continue...");
        while (Console.ReadKey().Key != ConsoleKey.Enter) ;
    }
}
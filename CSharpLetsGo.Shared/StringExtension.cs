namespace CSharpLetsGo.Shared;

public static class StringExtension
{
    /// <summary>
    /// Truncates a string to x given characters, adding a trailing "..."
    /// </summary>
    /// <param name="str">String to truncate</param>
    /// <param name="maxLength">Maximum length of string</param>
    /// <returns></returns>
    public static string Truncate(this string str, int maxLength = 10)
    {
        return str.Length <= maxLength ? str : str[..maxLength] + "...";
    }
}
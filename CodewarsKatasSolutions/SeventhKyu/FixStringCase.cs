namespace SeventhKyu;

// https://www.codewars.com/kata/5b180e9fedaa564a7000009a

public class FixStringCase
{
    public static string Solve(string s)
    {
        var uppers = s.Where(char.IsUpper).ToList().Count;
        var lowers = s.Where(char.IsLower).ToList().Count;
        if (lowers == uppers) return s.ToLower();
        return lowers < uppers
            ? s.ToUpper()
            : s.ToLower();
    }
}
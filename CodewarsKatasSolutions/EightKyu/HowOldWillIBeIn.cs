namespace EightKyu;

// https://www.codewars.com/kata/5761a717780f8950ce001473

public class HowOldWillIBeIn
{
    public static string CalculateAge(int birth, int yearTo)
    {
        var diff = birth - yearTo;
        var s = diff > 0 ? diff != 1 ? "s" : string.Empty : -diff != 1 ? "s" : string.Empty;
        return diff switch
        {
            0 => "You were born this very year!",
            < 0 => $"You are {-diff} year{s} old.",
            > 0 => $"You will be born in {diff} year{s}."
        };
    }
}
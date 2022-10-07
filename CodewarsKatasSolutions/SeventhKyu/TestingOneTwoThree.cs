namespace SeventhKyu;

// https://www.codewars.com/kata/54bf85e3d5b56c7a05000cf9

public class TestingOneTwoThree
{
    public static List<string> Number(List<string> lines) => lines.Select((t, i) => i + 1 + ": " + t).ToList();
}
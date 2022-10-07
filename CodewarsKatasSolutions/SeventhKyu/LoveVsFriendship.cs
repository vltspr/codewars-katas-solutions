namespace SeventhKyu;

// https://www.codewars.com/kata/59706036f6e5d1e22d000016

public class LoveVsFriendship
{
    public static int WordsToMarks(string str) => str.Select(c => (int)c % 32).Sum();
}
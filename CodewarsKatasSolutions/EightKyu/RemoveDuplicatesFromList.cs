namespace EightKyu;

// https://www.codewars.com/kata/57a5b0dfcf1fa526bb000118

public class RemoveDuplicatesFromList
{
    public static int[] distinct(int[] a) => a.Distinct().ToArray();
}
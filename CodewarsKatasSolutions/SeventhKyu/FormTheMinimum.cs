namespace SeventhKyu;

// https://www.codewars.com/kata/5ac6932b2f317b96980000ca

public class FormTheMinimum
{
    public static long MinValue(int[] a) =>
        Convert.ToInt64(string.Concat(a.Distinct().OrderBy(x => x).Select(x => x.ToString())));
}
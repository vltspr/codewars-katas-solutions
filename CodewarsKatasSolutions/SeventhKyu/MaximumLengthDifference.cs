namespace SeventhKyu;

public class MaximumLengthDifference
{
    public static int Mxdiflg(string[] a1, string[] a2)
    {
        return !a1.Any() || !a2.Any()
            ? -1
            : a1.Aggregate(0, (current, s) => a2.Select(y => Math.Abs(s.Length - y.Length)).Prepend(current).Max());
    }
}
namespace SixthKyu;

// https://www.codewars.com/kata/56a5d994ac971f1ac500003e

public static class ConsecutiveStrings
{
    public static string LongestConsec(string[] strarr, int k)
    {
        if (k <= 0) return string.Empty;

        var ret = string.Empty;

        for (var i = 0; i < strarr.Length + 1 - k; i++)
        {
            var curr = string.Concat(strarr[i..(i + k)]);
            if (curr.Length > ret.Length) ret = curr;
        }

        return ret;
    }
}
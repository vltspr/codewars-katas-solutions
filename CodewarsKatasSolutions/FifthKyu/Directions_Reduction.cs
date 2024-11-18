namespace FifthKyu;

using System.Linq;

// https://www.codewars.com/kata/550f22f4d758534c1100025a

public class DirReduction
{
    public static string[] dirReduc(string[] arr)
    {
        var ret = arr.ToList();

        for (var i = 0; i < ret.Count - 1; i++)
        {
            var pair = new[] { ret[i], ret[i + 1] };
            if ((!pair.Contains("NORTH") || !pair.Contains("SOUTH")) &&
                (!pair.Contains("WEST") || !pair.Contains("EAST"))) continue;
            ret.RemoveAt(i + 1);
            ret.RemoveAt(i);
            i = -1;
            if (ret.Count is 1 or 0) break;
        }

        return ret.ToArray();
    }
}
namespace FourthKyu;

// https://www.codewars.com/kata/51ba717bb08c1cd60f00002f

public static class RangeExtraction
{
    public static string Extract(int[] args)
    {
        var ret = string.Empty;
        for (var i = 0; i < args.Length + 1; i++)
        {
            var currentConsecutives = new List<int> { args[0] };

            for (var j = 1; j < args.Length; j++)
                if (args[j] == args[j - 1] + 1)
                {
                    currentConsecutives.Add(args[j]);
                    if (currentConsecutives.Count == args.Length) args = args[(j + 1)..];
                }
                else
                {
                    args = args[j..];
                    i = 0;
                    break;
                }

            if (currentConsecutives.Count > 2)
                ret += $"{currentConsecutives[0]}-{currentConsecutives[^1]},";
            else
                ret += $"{string.Join(',', currentConsecutives)},";
        }

        return ret.TrimEnd(',');
    }
}
namespace EightKyu;

// https://www.codewars.com/kata/5a34b80155519e1a00000009

public class MultipleOfIndex
{
    public static List<int> MltpOfIndex(List<int> xs)
    {
        var ret = new List<int>();
        for (var i = 1; i < xs.Count; i++)
        {
            if (xs[i] % i == 0) ret.Add(xs[i]);
        }

        return ret;
    }
}
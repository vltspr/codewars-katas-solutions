namespace SixthKyu;

// https://www.codewars.com/kata/556deca17c58da83c00002db

public class TribonacciSequence
{
    public double[] Tribonacci(double[] signature, int n)
    {
        if (n <= signature.Length) return signature[..n];

        var ret = new List<double>(signature);

        for (var i = 2; i < n - 1; i++) ret.Add(ret.GetRange(i - 2, 3).Sum());

        return ret.ToArray();
    }
}
namespace SixthKyu;

// https://www.codewars.com/kata/556e0fccc392c527f20000c5 

public class FibonacciTribonacciAndFriends
{
    public double[] xbonacci(double[] signature, int n)
    {
        if (n <= signature.Length) return signature[..n];

        var ret = new List<double>(signature);

        for (var i = signature.Length + 1; i < n + 1; i++)
            ret.Add(ret.GetRange(i - signature.Length - 1, signature.Length).Sum());

        return ret.ToArray();
    }
}
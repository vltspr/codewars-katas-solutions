namespace FifthKyu;

// https://www.codewars.com/kata/5541f58a944b85ce6d00006a

public class ProdFib 
{
    public static ulong[] productFib(ulong prod) 
    {
        if (prod == 1) return [1, 1, 1];
        var fib = new List<ulong> { 0, 1 };
        var ret = new ulong[] { 0, 0, 0 };

        for (var i = 2; (ulong)i < prod; i++)
        {
            fib.Add(Convert.ToUInt64(fib[i - 1] + fib[i - 2]));
            if (fib[i - 1] * fib[i] == prod)
            {
                ret[0] = fib[i - 1];
                ret[1] = fib[i];
                ret[2] = 1;
                return ret;
            }

            if (fib[i - 1] * fib[i] <= prod) continue;
            ret[0] = fib[i - 1];
            ret[1] = fib[i];
            ret[2] = 0;
            return ret;
        }

        return ret;
    }
}
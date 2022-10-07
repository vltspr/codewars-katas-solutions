namespace EightKyu;

// https://www.codewars.com/kata/5a2fd38b55519ed98f0000ce
// Should use Enumerable.Range instead 

public class MultiplicationTableForNumber
{
    public static string MultiTable(int number)
    {
        var ret = string.Empty;
        for (var i = 1; i < 11; i++) ret += $"{i} * {number} = {i * number}{(i != 10 ? "\n" : string.Empty)}";
        return ret;
    }
}
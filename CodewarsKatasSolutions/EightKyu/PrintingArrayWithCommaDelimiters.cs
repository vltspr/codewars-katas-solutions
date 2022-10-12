namespace EightKyu;

// https://www.codewars.com/kata/56e2f59fb2ed128081001328

public class PrintingArrayWithCommaDelimiters
{
    public static string PrintArray(object[] array)
    {
        var ret = string.Empty;

        foreach (var o in array)
            if (o.ToString() != "System.Object[]")
                ret += o.ToString() + ',';
            else
                ret += string.Join(',', Array.ConvertAll((object[])o, x => x.ToString()))  + ',';

        return ret.Remove(ret.Length - 1, 1);
    }
}
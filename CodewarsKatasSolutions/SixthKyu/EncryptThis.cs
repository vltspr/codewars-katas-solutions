using System.Text;

namespace SixthKyu;

// https://www.codewars.com/kata/5848565e273af816fb000449

public class EncryptThis
{
    public static string EncrptThis(string input)
    {
        if (input == string.Empty) return string.Empty;
        var ret = new List<string>();

        var split = input.Split(' ');

        foreach (var t in split)
        {
            var temp = string.Empty;

            if (t != string.Empty) temp += Encoding.ASCII.GetBytes(t)[0];

            if (t.Length > 2)
            {
                var strChar = t[1..].ToCharArray();
                (strChar[0], strChar[^1]) = (strChar[^1], strChar[0]);
                temp += new string(strChar);
            }
            else
            {
                temp += t[1..];
            }

            ret.Add(temp);
        }

        return string.Join(' ', ret);
    }
}
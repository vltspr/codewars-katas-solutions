namespace FifthKyu;

// https://www.codewars.com/kata/530e15517bc88ac656000716

public class Kata
{
    public static string Rot13(string message)
    {
        return string.Concat(message.Select(x => cipher(x)));
    }
  
    public static char cipher(char ch) 
    {  
        if (!char.IsLetter(ch)) 
        { 
            return ch;  
        }  
        var d = char.IsUpper(ch) ? 'A' : 'a';  
        return (char)((ch + 13 - d) % 26 + d);  
    }  
}
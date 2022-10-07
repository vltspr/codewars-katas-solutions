namespace EightKyu;

// https://www.codewars.com/kata/5748838ce2fab90b86001b1a
// How is this 8 kyu ?

public class AreaOfASquare
{
    public static double SquareArea(double A)
    {
        return Math.Round(Math.Pow(A * 4 / Math.PI, 2) / 4, 2);
    }
}
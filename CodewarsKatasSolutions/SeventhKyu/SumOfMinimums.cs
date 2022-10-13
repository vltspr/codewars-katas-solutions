namespace SeventhKyu;

public class SumOfMinimums
{
    public static int Sum(int[,] numbers)
    {
        var ret = 0;

        for (var x = 0; x < numbers.GetLength(0); x++)
        {
            var min = 0;
            for (var y = 0; y < numbers.GetLength(1); y++)
            {
                if (min == 0) min = numbers[x, y];
                if (numbers[x, y] < min) min = numbers[x, y];
            }

            ret += min;
        }

        return ret;
    }
}
namespace SeventhKyu;

//https://www.codewars.com/kata/556196a6091a7e7f58000018

public class LargestPairSumInArray
{
    public static int LargestPairSum(int[] numbers) => numbers.OrderByDescending(x => x).Take(2).Sum();
}
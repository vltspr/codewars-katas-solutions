using NUnit.Framework;

namespace FourthKyu;

// https://www.codewars.com/kata/5659c6d896bc135c4c00021e

public class Next_Smaller_Number_With_Same_Digits
{
    public static long NextSmaller(long n)
    {
        var numberAsString = n.ToString().ToArray();
        
        // If number is lower than 10 or if the number is made of the same digit, can't reduce, ret -1
        if (numberAsString.Distinct().Count() == 1 || n < 10)
        {
            return -1;
        }
        for (var i = numberAsString.Length - 2; i >= 0; i--)
        {
            if (numberAsString[i] == '0') continue;
            
            var biggestOfSmaller = '0';
            var biggestOfSmallerIndex = -1;
            
            for (var j = i + 1; j < numberAsString.Length; j++)
            {
                if (numberAsString[j] >= numberAsString[i]) continue;
                if (numberAsString[j] > biggestOfSmaller)
                {
                    (biggestOfSmaller, biggestOfSmallerIndex) = (numberAsString[j], j);
                }
            }

            if (biggestOfSmallerIndex == -1) continue;
            if (i == 0 && biggestOfSmaller == 0)
            {
                return -1;
            }

            var charToMove = numberAsString[biggestOfSmallerIndex];

            // Shift all elements between i and biggestOfSmallerIndex-1 one position to the right
            for (var j = biggestOfSmallerIndex; j > i; j--)
            {
                numberAsString[j] = numberAsString[j - 1];
            }

            // Place the character at its new position
            numberAsString[i] = charToMove;
            
            var currentNumbersLong = long.Parse(string.Concat(numberAsString));
            
            if (currentNumbersLong < n) return currentNumbersLong;
        }

        return -1;
    }
}

[TestFixture]
public class Tests
{
    [TestCase(21, ExpectedResult = 12)]
    [TestCase(9, ExpectedResult = -1)]
    [TestCase(1111111, ExpectedResult = -1)]
    [TestCase(907, ExpectedResult = 790)]
    [TestCase(531, ExpectedResult = 513)]
    [TestCase(1027, ExpectedResult = -1)]
    [TestCase(441, ExpectedResult = 414)]
    [TestCase(101, ExpectedResult = -1)]
    [TestCase(123456798, ExpectedResult = 123456789)]
    [TestCase(29009, ExpectedResult = 20990)]
    [TestCase(315, ExpectedResult = 153)]
    [TestCase(1207, ExpectedResult = 1072)]
    public long FixedTests(long n)
    {
        return Next_Smaller_Number_With_Same_Digits.NextSmaller(n);
    }
}
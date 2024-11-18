namespace FifthKyu;

// https://www.codewars.com/kata/54521e9ec8e60bc4de000d6c
// This following algorithm is very bad. Need to switch to sliding window technique.
 
public static class MaxSum
{
    public static int MaxSequence(int[] arr) 
    { 
        var ret = 0;
        for(var i = 0; i < arr.Length; i++)
        {
            var indexLast = i;
            while(indexLast <= arr.Length)
            {
                var subsequenceSum = arr[i..indexLast].Sum();
                if(subsequenceSum > ret){
                    ret = subsequenceSum;
                }
                indexLast++;
            }
        }
        return ret;
    }
}
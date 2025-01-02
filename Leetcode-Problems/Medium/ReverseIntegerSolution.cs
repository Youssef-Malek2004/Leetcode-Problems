namespace Leetcode_Problems.Medium;

public class ReverseIntegerSolution
{
    public int Reverse(int x)
    {
        bool wasNegative = false;
        if (x < 0)
        {
            wasNegative = true;
            x *= -1;
        }
        var charArray = x.ToString().ToArray();
        var numArray = charArray.Select((a) => a - 48).ToArray();
        int length = numArray.Length;

        long reversedNum = 0;
        
        for (var i = 0; i < length; i++)
        {
            reversedNum += numArray[i] * (long)Math.Pow(10,i);
        }

        var upperBound = (long)Math.Pow(2, 31)-1;
        var lowerBound = -(long)Math.Pow(2, 31);

        if (reversedNum > upperBound || reversedNum < lowerBound)
        {
            Console.Out.WriteLine(reversedNum);
            return 0;
        }

        if (wasNegative) reversedNum *= -1;
        return (int)reversedNum;
    }
}
using System.Numerics;

namespace Leetcode_Problems.Medium;

public class StringToIntAtoiSolution
{
    public int MyAtoi(string s)
    {
        if (s.Length == 0) return 0;
        bool leadingWhitespaces = true;
        var whitespaceCounter = 0;
        bool wasSign = true;

        bool positive = true;
        bool Checked = false;

        int digitCounter = 0;

        for (int i =  0; i < s.Length; i++)
        {
            
            if (s[i] == ' ' && leadingWhitespaces)
            {
                whitespaceCounter++;
                continue;
            }

            leadingWhitespaces = false;
            
            if (!Checked)
            {
                positive = !s[i].Equals('-');
                
                if (positive && !s[i].Equals('+'))
                {
                    wasSign = false;
                    i--;
                }
                Checked = true;
                continue;
            }
            
            if (!IsNumber(s[i])) break;
            
            digitCounter++;
        }

        BigInteger number = 0;
        int startingIndex = (positive ? 0 : 1) + whitespaceCounter +(wasSign && positive? 1 : 0);


        var tempDigitCounter = digitCounter;
        
        while (digitCounter > 0)
        {
            number += BigInteger.Parse(s[startingIndex].ToString()) * (BigInteger)(Math.Pow(10,digitCounter-1));
            startingIndex++;
            digitCounter--;
        }

        number = positive ? (BigInteger)number : -(BigInteger)number;
        
        if (number > (BigInteger)Math.Pow(2, 31) - 1) return (int)Math.Pow(2, 31) - 1;
        if (number <  - (BigInteger) Math.Pow(2, 31) ) return (int)- Math.Pow(2, 31) ;

        return (int)number;

    }

    public bool IsNumber(char digit)
    {
        if (digit.Equals('0') || digit.Equals('1') || digit.Equals('2') || digit.Equals('3') || digit.Equals('4')
            || digit.Equals('5') || digit.Equals('6') || digit.Equals('7') || digit.Equals('8') || digit.Equals('9'))
        {
            return true;
        }

        return false;
    }
}
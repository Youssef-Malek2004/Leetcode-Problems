namespace Leetcode_Problems.Easy;

public class ValidPalindrome
{
    public bool IsPalindrome(string s)
    {
        s = s.ToLower();
        var newS = "";
        
        foreach (var c in s)
        {
            if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
            {
                newS += c;
            }
        }

        for (var i = 0; i < newS.Length / 2; i++)
        {
            if (newS[i] != newS[newS.Length - 1 - i])
                return false;
        }

        return true;
    }
}
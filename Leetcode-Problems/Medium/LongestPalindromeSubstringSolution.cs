namespace Leetcode_Problems.Medium;

public class LongestPalindromeSubstringSolution
{
    public string LongestPalindrome(string s)
    {
        int n = s.Length;
        if (n <= 1) return s;

        bool[,] dp = new bool[n, n];
        int start = 0, maxLength = 1;

        // All single-character substrings are palindromes
        for (int i = 0; i < n; i++)
        {
            dp[i, i] = true;
        }

        // Check for two-character palindromes
        for (int i = 0; i < n - 1; i++)
        {
            if (s[i] == s[i + 1])
            {
                dp[i, i + 1] = true;
                start = i;
                maxLength = 2;
            }
        }

        // Check for palindromes longer than 2 characters
        for (int length = 3; length <= n; length++)
        {
            for (int i = 0; i < n - length + 1; i++)
            {
                int j = i + length - 1; // Ending index of the substring

                // Check if the substring s[i..j] is a palindrome
                if (s[i] == s[j] && dp[i + 1, j - 1])
                {
                    dp[i, j] = true;

                    if (length > maxLength)
                    {
                        start = i;
                        maxLength = length;
                    }
                }
            }
        }

        // Return the longest palindromic substring
        return s.Substring(start, maxLength);
    }
    
    public string LongestPalindrome2(string s)
    {
        int[][] dp = new int[s.Length][];

        for (int i = 0; i < s.Length; i++)
        {
            dp[i] = new int[s.Length];
            Array.Fill(dp[i],-1);
        }
        
        return LongestPalindromeHelper(s,0,s.Length-1,dp);
    }

    public string GetSubstring(string s, int startingIndex, int endingIndex)
    {
        
        if (startingIndex > endingIndex) return "";
        else if (startingIndex == endingIndex) return s[startingIndex].ToString();
        else
        {
            var outputString = "";
            for (int i = startingIndex; i <= endingIndex; i++)
            {
                outputString += s[i];
            }
            
            return outputString;
        }
        
    }
    public string LongestPalindromeHelper(string s, int startingIndex, int endingIndex, int[][] dp)
    {
        if (startingIndex == s.Length) return "";
        if (startingIndex > endingIndex) return "";
        if (endingIndex < 0) return "";
        if (endingIndex == startingIndex) return s[startingIndex].ToString();

        if (s[startingIndex] == s[endingIndex])
        {
            if (dp[startingIndex][endingIndex] != -1)
            {
                return dp[startingIndex][endingIndex] == 0 ? "" : GetSubstring(s,startingIndex,endingIndex);;
            }

            if (IsPalindrome(s, startingIndex+1, endingIndex-1, dp))
            {
                dp[startingIndex][endingIndex] = 1;
                return GetSubstring(s,startingIndex,endingIndex);
            }
            
            dp[startingIndex][endingIndex] = 0;
        }

        return ReturnLongerString(ReturnLongerString(
                LongestPalindromeHelper(s, startingIndex + 1, endingIndex,dp),
                LongestPalindromeHelper(s, startingIndex, endingIndex - 1, dp)),
            LongestPalindromeHelper(s, startingIndex + 1, endingIndex - 1, dp));

    }

    public bool IsPalindrome(string s, int startingIndex, int endingIndex, int [][]dp)
    {
        if (dp[startingIndex][endingIndex] != -1)
        {
            return dp[startingIndex][endingIndex] != 0;
        }

        bool result = false;
        result =  IsPalindromeHelper(s,startingIndex,endingIndex);

        dp[startingIndex][endingIndex] = result ? 1 : 0;
        return result;
    }

    public bool IsPalindromeHelper(string s, int i, int j)
    {
        if (i >= j) return true;
        if (s[i] != s[j]) return false;
        return IsPalindromeHelper(s, i + 1, j - 1);
    }

    public string ReturnLongerString(string s1, string s2)
    {
        if (s1.Length > s2.Length) return s1;
        else return s2;
    }
}
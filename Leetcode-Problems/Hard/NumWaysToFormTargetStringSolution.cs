namespace Leetcode_Problems.Hard;

public class NumWaysToFormTargetStringSolution
{
     public int NumWays(string[] words, string target)
    {
        int[][] dp = new int[words[0].Length][];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[target.Length];
            Array.Fill(dp[i],-1);
        }
        
        int[,] charFrequency = new int[words[0].Length, 26];

        foreach (var word in words)
        {
            for (int j = 0; j < word.Length; j++)
            {
                var pos = word[j] - 'a';
                charFrequency[j,pos]++;
            }
        }
        
        // int numWays = NumWaysHelper(words, target, 0,0, "");
        var numWays = Helper(words, dp, charFrequency, 0, 0, target);
        
        return (int )numWays;
    }

    public long Helper(string[] words, int[][] dp, int[,] charFrequency, int wordIndex, int targetIndex, string target)
    {
        long numWords = 0;
        
        if (targetIndex == target.Length) return 1;
        if (wordIndex >= words[0].Length) return 0;
        if (targetIndex >= target.Length) return 0;

        if (dp[wordIndex][targetIndex] != -1)
        {
            return dp[wordIndex][targetIndex];
        }

        numWords += Helper(words, dp, charFrequency, wordIndex + 1, targetIndex, target);
        numWords += charFrequency[wordIndex, target[targetIndex] - 'a'] *
                    Helper(words, dp, charFrequency, wordIndex + 1, targetIndex + 1, target);

        dp[wordIndex][targetIndex] = (int)(numWords % 1000000007);
        
        return dp[wordIndex][targetIndex];
    }

}
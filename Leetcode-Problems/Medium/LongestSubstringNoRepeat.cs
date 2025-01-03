namespace Leetcode_Problems.Medium;

public class LongestSubstringNoRepeat
{
    public int LengthOfLongestSubstring(string s)
    {
        var substringLetters = new HashSet<char>();

        if (s.Length == 0) return 0;
        
        int max = 1;

        for (int i = 0; i < s.Length; i++)
        {
            foreach (var letter in substringLetters) substringLetters.Remove(letter);

            int localMax = 1;
            substringLetters.Add(s[i]);

            for (int j = i + 1; j < s.Length; j++)
            {
                if (substringLetters.Contains(s[j])) break;
                localMax++;
                substringLetters.Add(s[j]);
            }

            if (localMax > max) max = localMax;

        }
        return max;
    }
    
    public int LengthOfLongestSubstringSlidingWindow(string s)
    {
        var substringLetters = new HashSet<char>();

        if (s.Length == 0) return 0;
        
        int max = 1;
        int rightPointer = 0;
        int leftPointer = 0;

        while(rightPointer < s.Length)
        {
            if (substringLetters.Contains(s[rightPointer]))
            {
                substringLetters.Remove(s[leftPointer]);
                leftPointer++;
                continue;
            }

            substringLetters.Add(s[rightPointer]);

            int localMax = rightPointer - leftPointer + 1;
            if (localMax > max) max = localMax;
            rightPointer++;
        }
        return max;
    }
    
    public int LengthOfLongestSubstringChatGpt(string s) {
        if (string.IsNullOrEmpty(s)) return 0;

        var charIndexMap = new Dictionary<char, int>();
        int max = 0, leftPointer = 0;

        for (int rightPointer = 0; rightPointer < s.Length; rightPointer++) {
            if (charIndexMap.ContainsKey(s[rightPointer])) {
                leftPointer = Math.Max(leftPointer, charIndexMap[s[rightPointer]] + 1);
            }

            charIndexMap[s[rightPointer]] = rightPointer;
            max = Math.Max(max, rightPointer - leftPointer + 1);
        }

        return max;
    }

}
namespace Leetcode_Problems.Medium;

public class LongestSubstringNoRepeatSolution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0 || s.Length == 1)
            return s.Length;
        
        var i = 0;
        var j = 1;
        var locations = new Dictionary<char, int>();
        locations.Add(s[i],i);
        
        var maxLength = 1;
        var currentLength = 1;

        while (j < s.Length)
        {
            if (locations.TryGetValue(s[j], out var value) && value >= i)
            {
                if (currentLength > maxLength)
                    maxLength = currentLength;
                
                i = value + 1;
                locations[s[j]] = j;
                currentLength = j - i + 1;
                j++;
            }
            else
            {
                currentLength++;
                locations[s[j]] = j;
                j++;
            }
        }

        if (currentLength > maxLength)
            maxLength = currentLength;
        
        return maxLength;
    }
}
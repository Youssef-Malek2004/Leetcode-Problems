namespace Leetcode_Problems.Medium;

public class LongestConsecutiveSequenceSolution
{
    public int LongestConsecutive(int[] nums)
    {
        var numberSet = new HashSet<int>();

        foreach (var num in nums)
        {
            numberSet.Add(num);
        }

        int max = 0;
        foreach (var num in nums)
        {
            if (!numberSet.Contains(num - 1))
            {
                int sequenceCount = 1;
                int i = num + 1;
                while (numberSet.Contains(i))
                {
                    sequenceCount++;
                    i++;
                }

                if (sequenceCount > max)
                    max = sequenceCount;
            }
        }
        
        return max;
    }
}
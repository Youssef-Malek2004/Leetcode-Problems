namespace Leetcode_Problems.Medium;

public class MaximumAbsoluteSumSolution
{
    public int MaxAbsoluteSum(int[] nums)
    {
        int maxSum = 0;
        int minSum = 0;
        int currMax = 0;
        int currMin = 0;

        foreach (int num in nums) {
            currMax = Math.Max(num, currMax + num);
            maxSum = Math.Max(maxSum, currMax);

            currMin = Math.Min(num, currMin + num);
            minSum = Math.Min(minSum, currMin);
        }

        return Math.Max(maxSum, Math.Abs(minSum));
    }
}
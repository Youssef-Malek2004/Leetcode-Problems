namespace Leetcode_Problems.Medium;

public class ContainerWithMostWaterSolution
{
    public int MaxArea(int[] height)
    {
        var leftPtr = 0;
        var rightPtr = height.Length-1;

        var maxArea = -1;

        while (leftPtr < rightPtr)
        {
            var localArea = Math.Min(height[leftPtr], height[rightPtr]) * (rightPtr - leftPtr);
            if (localArea > maxArea) maxArea = localArea;
            if (height[leftPtr] > height[rightPtr]) rightPtr--;
            else leftPtr++;
        }
    
        return maxArea;
    }
}
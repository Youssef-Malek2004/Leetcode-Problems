namespace Leetcode_Problems.Hard;

public class FindMinimumRotatedSortedArraySolution
{
    public int FindMin(int[] nums)
    {
        bool lookingAtRight = false;
        bool lookingAtLeft = false;

        int min = 0;
        int max = nums.Length - 1;

        int mininmum = FindMinHelper(nums, min, max, false);

        while (max > min)
        {
                
        }
        
        return 0;
    }

    public int FindMinHelper(int[] nums, int min, int max, bool found)
    {
        if (found)
            return int.MaxValue;
        
        var decreasingFound = false;
        
        if (max == min)
            return nums[min];

        int minimum = int.MaxValue;
            
        int mid = (max - min) / 2;

        if (mid > 0 && nums[mid - 1] > nums[mid])
        {
            minimum = nums[mid];
            decreasingFound = true;
        }
        else if (mid < nums.Length - 1 && nums[mid] > nums[mid + 1])
        {
            minimum = nums[mid + 1];
            decreasingFound = true;
        }
        
        return minimum;
    }
}
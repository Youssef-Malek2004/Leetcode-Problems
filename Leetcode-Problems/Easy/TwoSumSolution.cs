namespace Leetcode_Problems.Easy;

public class TwoSumSolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var hashMap = new Dictionary<int, int>();
        var indexMap = new Dictionary<int, LinkedList<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (hashMap.ContainsKey(nums[i]))
            {
                hashMap[nums[i]]++;
                indexMap[nums[i]].AddLast(i);
            }
            else
            {
                hashMap.Add(nums[i],1);
                indexMap.Add(nums[i],new LinkedList<int>([i]));
            }
            
        }

        foreach (var key in hashMap)
        {
            int rem = target - key.Key;
            if (rem == key.Key && key.Value > 1)
            {
                int firstIndex = indexMap[key.Key].First.Value;
                indexMap[key.Key].RemoveFirst();
                return [firstIndex, indexMap[key.Key].First.Value];
            }
            if (rem != key.Key){
                if (hashMap.ContainsKey(rem)) return [indexMap[key.Key].First.Value, indexMap[rem].First.Value];
            }
        }
        return [-1, -1];
    }
}
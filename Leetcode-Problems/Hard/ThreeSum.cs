using System.Collections;

namespace Leetcode_Problems.Hard;

public class ThreeSum
{
    public List<List<int>> ThreeSumSol(int[] nums)
    {
        var additions = new Dictionary<int, IList<IList<int>>>(); // Additions -> All the Indices giving that difference
        var solutions = new List<List<int>>();
        var seen = new HashSet<string>(); 
        
        //Get all additions
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length ; j++)
            {
                var sum = nums[i] + nums[j];
                if (additions.ContainsKey(sum))
                {
                    additions[sum].Add([i,j]);
                }
                else
                {
                    additions.Add(sum, [[i,j]]);
                }
            }
        }
        
        //Check for Possibilities
        for (var i = 0; i < nums.Length; i++)
        {
            var needle = 0 - nums[i];
            if (!additions.TryGetValue(needle, out var addition)) continue;
            foreach (var ints in addition)
            {
                var twoSumSolution = new List<int>((List<int>)ints);
                if(twoSumSolution.Contains(i)) continue;
                twoSumSolution.Add(i);

                var final = twoSumSolution.Select(index => nums[index]).ToList();
                final.Sort();
                
                var key = string.Join(",", final);
                if (seen.Add(key))
                {
                    solutions.Add(final);
                }
            }
        }

        return solutions;
    }
}
namespace Leetcode_Problems.Easy;

public class SortArrayByFrequencySolution
{
    public struct MyNodes
    {
        public int Value { get; set; }
        public int Frequency { get; set; }
    }

    public int[] FrequencySort(int[] nums) {
        int[] outArray = new int[nums.Length];
        var numberFrequencies = new Dictionary<int, int>(); 
    
        for (int i = 0; i < nums.Length; i++)
        {
            if (numberFrequencies.ContainsKey(nums[i])) numberFrequencies[nums[i]]++;
            else numberFrequencies.Add(nums[i],1);
        }
    
        PriorityQueue<MyNodes,(int Frequency, int NegativeValue)> queue = new PriorityQueue<MyNodes,(int Frequency, int NegativeValue)>();
    
        foreach(var key in numberFrequencies) 
            queue.Enqueue(new MyNodes{Frequency = key.Value, Value = key.Key},(key.Value, -key.Key));
    
        int globalIndex = 0;
        while (queue.Count > 0)
        {
            int globalIndexTemp = globalIndex;
            var element = queue.Dequeue();
            for (int i = globalIndexTemp; i < globalIndexTemp + element.Frequency; i++)
            {
                Console.Out.WriteLine("Here");
                outArray[i] = element.Value;
                globalIndex++;
            }
        }
        return outArray;
    }
}
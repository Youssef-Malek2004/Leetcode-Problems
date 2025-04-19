namespace Leetcode_Problems.Medium;

public class DailyTemperaturesSolution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        var stack = new Stack<int>();
        var answer = new int[temperatures.Length];
        
        for (var i = temperatures.Length - 1; i >= 0; i--)
        {
            if (stack.Count == 0)
            {
                stack.Push(temperatures[i]);
                answer[i] = 0;
            }
            else
            {
                var tempStack = new Stack<int>();
                var removed = 1;
                while (stack.Count > 0 && stack.Peek() < temperatures[i])
                {
                    removed++;
                    tempStack.Push(stack.Pop());
                }

                answer[i] = 0;
                
                if (stack.Count > 0)
                    answer[i] = removed;
                while(tempStack.Count > 0)
                    stack.Push(tempStack.Pop());
                    
                stack.Push(temperatures[i]);
            }
        }
        
        return answer;
    }
    
    public int[] DailyTemperatures2(int[] temperatures)
    {
        var n = temperatures.Length;
        var answer = new int[n];
        var stack = new Stack<int>(); // stores indices, not temps

        for (int i = n - 1; i >= 0; i--)
        {
            // Pop until we find a warmer day
            while (stack.Count > 0 && temperatures[stack.Peek()] <= temperatures[i])
            {
                stack.Pop();
            }

            // If stack is not empty, the next warmer day is at the top
            if (stack.Count > 0)
                answer[i] = stack.Peek() - i;

            // Push the current day index
            stack.Push(i);
        }

        return answer;
    }
}
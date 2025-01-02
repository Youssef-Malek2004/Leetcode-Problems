namespace Leetcode_Problems.Medium;

public class MaximalNetworkRankSolution
{
    public int MaximalNetworkRank(int n, int[][] roads) {
        var cityDegreesMap = new Dictionary<int, int>();
        bool[,] cityConnected = new bool[n, n];

        for (int i = 0; i < n; i++)
        {
            cityDegreesMap.Add(i,0);
        }
    
        for (int i = 0; i < roads.Length; i++)
        {
            cityDegreesMap[roads[i][0]]++;
            cityDegreesMap[roads[i][1]]++;
        
            cityConnected[roads[i][0], roads[i][1]] = true;
            cityConnected[roads[i][1], roads[i][0]] = true;
        }

        int max = -1;
        for (int j = 0; j < n; j++)
        {
            int localMax = -1;
            for (int k = 0; k < n; k++)
            {
                if(k == j) continue;
                int val = cityDegreesMap[j] + cityDegreesMap[k] - (cityConnected[j, k] ? 1 : 0);
                if (val > localMax) localMax = val;
            }

            if (localMax > max) max = localMax;
        }
        return max;
    }
}
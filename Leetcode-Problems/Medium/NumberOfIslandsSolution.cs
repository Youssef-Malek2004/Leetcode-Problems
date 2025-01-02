namespace Leetcode_Problems.Medium;

public class NumberOfIslandsSolution
{
    public int NumIslands(char[][] grid)
    {
        var nodes = new Dictionary<int, List<int>>(); //Node and its Adjacency List
        int key = 1;
        
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                var adjancenyList = new List<int>();
                
                if (grid[i][j] == '1')
                {
                    if(i-1 >=0 && grid[i-1][j] == '1') adjancenyList.Add(key - grid[0].Length); //Above us
                    if(i+1 < grid.Length && grid[i+1][j] == '1') adjancenyList.Add(key + grid[0].Length); //Under us
                    
                    if(j-1 >=0 && grid[i][j-1] == '1') adjancenyList.Add(key - 1); //Above us
                    if(j+1 < grid[0].Length && grid[i][j+1] == '1') adjancenyList.Add(key +1); //Above us
                    
                    nodes.Add(key,adjancenyList);
                }
                key++;
            }
        }

        var visitedNodes = new HashSet<int>();
        
        return DfsTraversalIslands(nodes, visitedNodes);;
    }

    public int DfsTraversalIslands(Dictionary<int, List<int>> nodes, HashSet<int> visited)
    {
        int islands = 0;

        foreach (var node in nodes)
        {
            if (!visited.Contains(node.Key))
            {
                DfsTraversalNode(nodes, visited, node);
                islands++;
            }
        }
        
        return islands;
    }

    public void DfsTraversalNode(Dictionary<int, List<int>> nodes, HashSet<int> visited, KeyValuePair<int, List<int>> node)
    {
        visited.Add(node.Key);
        foreach (var adjacentNode in node.Value)
        {
            if (!visited.Contains(adjacentNode))
            {
                nodes.TryGetValue(adjacentNode, out List<int>? adjacentNodes);
                DfsTraversalNode(nodes, visited, new KeyValuePair<int, List<int>>(adjacentNode,adjacentNodes!));
            }
        }
    }
}
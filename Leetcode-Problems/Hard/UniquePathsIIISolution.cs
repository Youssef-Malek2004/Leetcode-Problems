namespace Leetcode_Problems.Hard;

public class UniquePathsIIISolution
{
        public int UniquePathsIII(int[][] grid)
    {
        var nodes = new Dictionary<int, NodeLists>(); //Node and its Adjacency List
        int key = 1;
        int startingPoint = -1;
        var startingLists = new NodeLists();
        var endpoint = -1;
        
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                var adjancenyList = new List<int>();
                
                if (grid[i][j] != -1)
                {
                    if(i-1 >=0 && grid[i-1][j] != -1) adjancenyList.Add(key - grid[0].Length); 
                    if(i+1 < grid.Length && grid[i+1][j] != -1) adjancenyList.Add(key + grid[0].Length); 
                    
                    if(j-1 >=0 && grid[i][j-1] != -1) adjancenyList.Add(key - 1); 
                    if(j+1 < grid[0].Length && grid[i][j+1] != -1) adjancenyList.Add(key +1); 
                    
                    if (grid[i][j] == 1)
                    {
                        startingPoint = key;
                        var startingAdjacency = adjancenyList;
                        startingLists.AdjacentNodes = startingAdjacency;
                    }

                    if (grid[i][j] == 2)
                        endpoint = key;

                    var lists = new NodeLists();
                    
                    lists.AdjacentNodes = adjancenyList;
                    lists.VisitedNodes = [];
                    
                    nodes.Add(key,lists);
                }
                key++;
            }
        }
        var visitedNodes = new HashSet<int>();
        
        
        var numPaths = DfsTraversalAllNodes(nodes,visitedNodes, new KeyValuePair<int, NodeLists>(startingPoint,startingLists), endpoint);
        
        return numPaths;
    }

    public class NodeLists
    {
        public List<int> AdjacentNodes { get; set; } = [];
        public List<int> VisitedNodes { get; set; } = [];
    }
    
    public int DfsTraversalAllNodes(Dictionary<int, NodeLists> nodes, HashSet<int> visited, KeyValuePair<int, NodeLists> node, int endpoint)
    {
        visited.Add(node.Key);

        // Base case: all nodes are visited but endpoint is not reachable
        if (visited.Count == nodes.Count - 1 && !node.Value.AdjacentNodes.Contains(endpoint))
        {
            visited.Remove(node.Key);
            return 0;
        }

        int numPaths = 0;

        foreach (var adjacentNode in node.Value.AdjacentNodes)
        {
            if (adjacentNode == endpoint)
            {
                // If we've visited all nodes and reached the endpoint
                if (visited.Count == nodes.Count - 1)
                {
                    numPaths += 1;
                }
            }
            else if (!visited.Contains(adjacentNode))
            {
                if (nodes.TryGetValue(adjacentNode, out NodeLists? adjacentNodes))
                {
                    numPaths += DfsTraversalAllNodes(nodes, visited, new KeyValuePair<int, NodeLists>(adjacentNode, adjacentNodes!), endpoint);
                }
            }
        }

        visited.Remove(node.Key);
        return numPaths;
    }
}
namespace Leetcode_Problems.Hard;

class TrieNode
{
    private IList<string> _wordYields = [];
    Dictionary<char, TrieNode> _paths = new Dictionary<char, TrieNode>();
}

public record Coordiantes
{
    public int x;
    public int y;
}

public class WordSearchII
{
    public IList<string> FindWords(char[][] board, string[] words)
    {
        var startingCoords = new Dictionary<string, IList<Coordiantes>>();
        IList<string> results = [];
        
        for (int i = 0; i < board[0].Length; i++)
        {
            for (int j = 0; j < board.Length; j++)
            {
                foreach (var word in words)
                {
                    if (word[0] == board[j][i])
                    {
                        if(!startingCoords.ContainsKey(word))
                            startingCoords.Add(word,[]);
                        startingCoords[word].Add(new Coordiantes
                        {
                            x = i,
                            y = j
                        });
                    }
                }
            }
        }

        foreach (var startingCoord in startingCoords)
        {
            var coordinates = startingCoord.Value;
            bool found = false;

            foreach (var coordinate in coordinates)
            {
                if (found)
                    break;
                if (FindWordBfs(board, startingCoord.Key.Substring(1, startingCoord.Key.Length - 1), coordinate, [coordinate]))
                {
                    results.Add(startingCoord.Key);
                    found = true;
                }
            }
            
        }

        return results;
    }

    public bool FindWordBfs(char[][] board, string word, Coordiantes coordiantes, List<Coordiantes> visited)
    {
        if (word == "")
            return true;

        bool found1 = false;
        bool found2 = false;
        bool found3 = false;
        bool found4 = false;
        
        int startX = coordiantes.x;
        int startY = coordiantes.y;

        int boardWidth = board[0].Length;
        int boardHeight = board.Length;

        if (!found1 && startX > 0 && board[startY][startX -1] == word[0])
        {
            var coords = new Coordiantes
            {
                x = startX - 1,
                y = startY
            };
            
            if (!visited.Contains(coords))
            {
                visited.Add(coords);
            
                found1 = FindWordBfs(board, word.Substring(1, word.Length - 1), coords, visited);
                
                visited.Remove(coords);
            }
        }
        
        if (!found2 && startY < boardHeight - 1  && board[startY + 1][startX] == word[0])
        {
            var coords = new Coordiantes
            {
                x = startX,
                y = startY + 1
            };

            if (!visited.Contains(coords))
            {
                visited.Add(coords);
            
                found2 = FindWordBfs(board, word.Substring(1, word.Length - 1), coords, visited);
                
                visited.Remove(coords);
            }
        }
        
        if (!found3 && startY > 0 && board[startY -1][startX] == word[0])
        {
            var coords = new Coordiantes
            {
                x = startX,
                y = startY -1
            };
            
            if (!visited.Contains(coords))
            {
                visited.Add(coords);
            
                found3 = FindWordBfs(board, word.Substring(1, word.Length - 1), coords, visited);
                
                visited.Remove(coords);
            }
        }
        
        if (!found4 && startX < boardWidth -1 && board[startY][startX + 1] == word[0])
        {
            var coords = new Coordiantes
            {
                x = startX + 1,
                y = startY
            };
            
            if (!visited.Contains(coords))
            {
                visited.Add(coords);
            
                found4 = FindWordBfs(board, word.Substring(1, word.Length - 1), coords, visited);
                
                visited.Remove(coords);
            }
        }
        
        return found1 || found2 || found3 || found4;
    }
}
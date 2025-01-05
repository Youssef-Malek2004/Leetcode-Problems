namespace Leetcode_Problems.Medium;

public class ZigzagConversionSolution
{
    public string Convert(string s, int numRows)
    {
        if (s.Length == 0) return ""; 
        if (numRows == 1) return s;
        
        var characters = new Dictionary<int, string>(); //Each Level
        
        var index = 0;

        while (index < s.Length)
        {
            for (int i = 1; i <= numRows && index < s.Length; i++)
            {
                if(!characters.ContainsKey(i)) characters.Add(i,s[index].ToString());
                else
                {
                    characters[i] += s[index];
                }

                index++;
            }

            for (int j = numRows - 1; j > 1 && index < s.Length; j--)
            {
                characters[j] += s[index];
                index++;
            }
        }

        var output = "";

        foreach (var pair in characters)
        {
            output += pair.Value;
        }

        return output;
    } 
}
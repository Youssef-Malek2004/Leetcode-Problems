namespace Leetcode_Problems.Hard;

public class MinimumWindowSubstringSolution
{
    public string MinWindow(string s, string t)
    {
        if (t == "")
            return "";
        if (t.Length > s.Length)
            return "";
        else if (t.Length == s.Length)
        {
            var charDic = new Dictionary<char, int>();
            foreach (var character in s)
            {
                if(!charDic.TryAdd(character, 1))
                {
                    charDic[character]++;
                }
            }

            foreach (var character in t)
            {
                if (!charDic.ContainsKey(character))
                    return "";
                if (charDic[character] == 0)
                    return "";
                charDic[character]--;
            }

            return s;
        }

        int i = 0;
        int j = t.Length;

        var found = false;
        string subString = "";
        while (!found && j <= s.Length)
        {
            if (i + j > s.Length)
            {
                j++;
                i = 0;
                continue;
            }
            
            subString = s.Substring(i, j);
            if (FoundInWindow(subString, t))
                found = true;
            else
                i++;
        }

        if (found)
            return subString;

        return "";
    }

    public bool FoundInWindow(string s, string t)
    {
        var charDic = new Dictionary<char, int>();
        foreach (var character in s)
        {
            if(!charDic.TryAdd(character, 1))
            {
                charDic[character]++;
            }
        }

        foreach (var character in t)
        {
            if (!charDic.TryGetValue(character, out var value))
                return false;
            if (value == 0)
                return false;
            charDic[character]--;
        }

        return true;
    }
    
}
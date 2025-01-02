namespace Leetcode_Problems.Hard;

public class RegularExpressionMatchingSolution
{
        public bool IsMatch(string s, string p)
    {
        return IsMatchHelper(s, p, 0, " ", false, 0);
    }
    
    public bool IsMatchHelper(string s, string p, int index, string lastCharacter, bool lastWasAStar, int matched)
    {
        if (matched == s.Length)
        {
            if (index < p.Length)
            {
                for (var j = index; j < p.Length; j++)
                {
                    if (j + 1 < p.Length && p[j + 1] == '*' && (p[j] == '.'))
                    {
                        continue;
                    }
                    else if (j + 1 < p.Length && p[j + 1] != '*' &&(p[j] != '*'))
                        return false;
                    else if(j + 1 < p.Length && p[j + 1] == '*' &&(p[j] != '*' && p[j] != '.'))
                        continue;
                    else if (p[j] != '*')
                        return false;
                }
            }
            
            return true;
        }
        
        if (index >= p.Length) return false;
        
        if ((s[matched] == p[index] && index+1 < p.Length && p[index+1] != '*') )
        {
            lastWasAStar = false;
            matched++;
        }
        else if ((s[matched] == p[index] && index+1 >= p.Length))
        {
            lastWasAStar = false;
            matched++;
        }
        else if ((p[index] == '.' && index+1 < p.Length && p[index+1] != '*'))
        {
            lastWasAStar = false;
            matched++;
        }
        else if ((p[index] == '.' && index+1 >= p.Length))
        {
            lastWasAStar = false;
            matched++;
        }
        else if ((s[matched] == p[index] && index+1 < p.Length && p[index+1] == '*'))
        {
            lastWasAStar = false;
            int repeated = CountNumRepeatChar(s, matched);
            
            if (!lastWasAStar && p[index] != '*')
            {
                lastCharacter = p[index].ToString();
            }

            index += 2;
            bool paths = false;
            for (int i = 0; i <= repeated; i++)
                paths = paths || IsMatchHelper(s,p,index,lastCharacter,lastWasAStar,matched+ i);
            
            return paths;
        }
        else if ((p[index] =='.' && index+1 < p.Length && p[index+1] == '*'))
        {
            lastWasAStar = false;
            
            if (!lastWasAStar && p[index] != '*')
            {
                lastCharacter = p[index].ToString();
            }

            index += 2;
            bool paths = false;
            for (int i = 0; i <= s.Length-matched; i++)
                paths = paths || IsMatchHelper(s,p,index,lastCharacter,lastWasAStar,matched+ i);
            
            return paths;
        }
        else if (s[matched] != p[index] && index + 1 < p.Length && p[index + 1] != '*' &&(p[index] != '*' && p[index] != '.'))
            return false;

        if (!lastWasAStar && p[index] != '*')
        {
            lastCharacter = p[index].ToString();
        }
        
        index++;
        return IsMatchHelper(s, p, index, lastCharacter, lastWasAStar, matched);
    }

    public int CountNumRepeatChar(string s, int index)
    {
        int count = 0;
        char initial = s[index];

        for (int i = index; i < s.Length; i++)
        {
            if (s[i] == initial)
                count++;
            else
            {
                return count;
            }
        }
        return count;
    }
}
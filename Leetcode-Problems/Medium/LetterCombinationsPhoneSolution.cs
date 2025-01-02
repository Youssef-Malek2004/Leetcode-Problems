namespace Leetcode_Problems.Medium;

public class LetterCombinationsPhoneSolution
{
    public IList<string> LetterCombinations(string digits)
    {
        if (digits == "") return [];
    
        var letters = new Dictionary<int, string>();
    
        letters.Add(1,"");
        letters.Add(2,"abc");
        letters.Add(3,"def");
        letters.Add(4,"ghi");
        letters.Add(5,"jkl");
        letters.Add(6,"mno");
        letters.Add(7,"pqrs");
        letters.Add(8,"tuv");
        letters.Add(9,"wxyz");
    
        return LetterCombinationsHelper(digits,[""],letters,0);
    }
    public IList<string> LetterCombinationsHelper(string digits, IList<string> solutions, Dictionary<int, string> letters, int index )
    {
        if (index == digits.Length) return solutions;
        if (digits[index] == '1') return LetterCombinationsHelper(digits, solutions, letters, index + 1);
    
        letters.TryGetValue(int.Parse(digits[index].ToString()), out string lettersForNum);
    
        var tempSolutions = new List<string>();

        foreach (var solution in solutions)
        {
            foreach (var letter in lettersForNum!)
            {
                var tempSolution = solution + letter;
                tempSolutions.Add(tempSolution);
            }
        }

        solutions = tempSolutions;
        return LetterCombinationsHelper(digits, solutions, letters, index + 1);
    }
}
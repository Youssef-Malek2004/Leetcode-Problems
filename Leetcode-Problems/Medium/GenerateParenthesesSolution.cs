namespace Leetcode_Problems.Medium;

public class GenerateParenthesesSolution
{
    public IList<string> GenerateParenthesis(int n)
    {
        var returned = new List<string>();
        var starting = "";

        GenerateParenthesisHelper(starting, n, n, returned);
        
        return returned;
    }

    public void GenerateParenthesisHelper(string current,int leftRemaining,
        int rightRemaining,IList<string> currentList)
    {
        if (leftRemaining == 0 && rightRemaining == 0)
            currentList.Add(current);
        else
        {
            if (leftRemaining < rightRemaining)
            {
                if(leftRemaining > 0)GenerateParenthesisHelper((current + "("), leftRemaining - 1, rightRemaining, currentList);
                if(rightRemaining > 0)GenerateParenthesisHelper((current + ")"), leftRemaining, rightRemaining-1,currentList);
            }
            else
            {
                if(leftRemaining > 0)GenerateParenthesisHelper((current + "("), leftRemaining - 1, rightRemaining, currentList);
            }
        }
    }
}
namespace Leetcode_Problems.Utils;

public static class PrintStructures
{
    public static void PrintList<T>(T[] list)
    {
        foreach (T item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    
    static void PrintListStrings(IList<string> list)
    {
        if (list == null || list.Count == 0)
        {
            Console.WriteLine("The list is empty or null.");
            return;
        }

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}
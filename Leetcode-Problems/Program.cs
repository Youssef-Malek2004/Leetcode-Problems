
using Leetcode_Problems.Easy;
using Leetcode_Problems.Medium;
using Leetcode_Problems.Utils;

Console.WriteLine("Hello, World!");

// var sumSolution = new TwoSumSolution();
// PrintStructures.PrintList(sumSolution.TwoSum([1,2,3,4],5));

var ReverseIntegerSol = new ReverseIntegerSolution();
Console.Out.WriteLine(ReverseIntegerSol.Reverse(123));

ListNode l1 = new ListNode(5);
l1.next = new ListNode(4);

ListNode l2 = new ListNode(5);
l2.next = new ListNode(5);

var AddTwoNumSol = new AddTwoNumbersSolution();
ListNode.PrintListNode(AddTwoNumSol.AddTwoNumbers(l1,l2));

Console.Out.WriteLine(new LongestSubstringNoRepeat().LengthOfLongestSubstringChatGpt("abacadef"));
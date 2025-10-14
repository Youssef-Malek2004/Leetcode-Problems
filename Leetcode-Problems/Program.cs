
using System.Collections;
using Leetcode_Problems;
using Leetcode_Problems.Easy;
using Leetcode_Problems.Hard;
using Leetcode_Problems.Medium;
using Leetcode_Problems.Utils;

Console.WriteLine("Hello, World!");

// var sumSolution = new TwoSumSolution();
// PrintStructures.PrintList(sumSolution.TwoSum([1,2,3,4],5));

// var ReverseIntegerSol = new ReverseIntegerSolution();
// Console.Out.WriteLine(ReverseIntegerSol.Reverse(123));
//
// ListNode l1 = new ListNode(5);
// l1.next = new ListNode(4);
//
// ListNode l2 = new ListNode(5);
// l2.next = new ListNode(5);
//
// var AddTwoNumSol = new AddTwoNumbersSolution();
// ListNode.PrintListNode(AddTwoNumSol.AddTwoNumbers(l1,l2));
//
// Console.Out.WriteLine(new MedianOfTwoSortedArraysSolution().FindMedianSortedArrays([1,2,3],[4,5,6]));
//
// LCA_BTreesSolution.BinaryTreeNode<int> treeNode = new LCA_BTreesSolution.BinaryTreeNode<int>(5);
//
// treeNode.left = new LCA_BTreesSolution.BinaryTreeNode<int>(2);
// treeNode.left.left = new LCA_BTreesSolution.BinaryTreeNode<int>(1);
// treeNode.left.right = new LCA_BTreesSolution.BinaryTreeNode<int>(3);
//
// treeNode.right = new LCA_BTreesSolution.BinaryTreeNode<int>(7);
// treeNode.right.left = new LCA_BTreesSolution.BinaryTreeNode<int>(6);
// treeNode.right.right = new LCA_BTreesSolution.BinaryTreeNode<int>(8);
//
// Console.Out.WriteLine(new LCA_BTreesSolution().lcaOfThreeNodes(treeNode,1,3,2).data);
//
// Console.Out.WriteLine(new StringToIntAtoiSolution().MyAtoi("  +  413"));
//
// Console.Out.WriteLine(new ZigzagConversionSolution().Convert("ab",2));

// Console.WriteLine(new LongestConsecutiveSequenceSolution().LongestConsecutive([0,3,7,2,5,8,4,6,0,1]));
// Console.WriteLine(new MinimumWindowSubstringSolution().MinWindow("ADOBECODEBANC","ABC"));
// Console.WriteLine(new DailyTemperaturesSolution().DailyTemperatures([73,74,75,71,69,72,76,73]));
// Console.WriteLine(new WordSearchII().FindWords([['o','a','a','n'],['e','t','a','e'],['i','h','k','r'],['i','f','l','v']], ["oath","pea","eat","rain"]));
// Console.WriteLine(new WordSearchII().FindWordBfs([['o','a','a','n'],['e','t','a','e'],['i','h','k','r'],['i','f','l','v']], "at", new Coordiantes
// {
//     x = 1,
//     y = 3
// }));

// Console.WriteLine(new WordSearchII().FindWords([['a','b','c'],['a','e','d'],['a','f','g']], ["abcdefg","gfedcbaaa","eaabcdgfa","befa","dgc","ade"]));
// Console.WriteLine(new WordSearchII().FindWords([['a','a']], ["aaa"]));

// Console.WriteLine(new LongestSubstringNoRepeatSolution().LengthOfLongestSubstring("abcabde"));

// Console.WriteLine(new MaximumAbsoluteSumSolution().MaxAbsoluteSum([2,-5,1,-4,3,2]));

// Console.Write(new ValidPalindrome().IsPalindrome("A man, a plan, a canal: Panama"));

Console.WriteLine(new Stripe().calculate_merchant_fraud_score(["merchant1,1200,customer1,10", "merchant1,500,customer1,10", "merchant2,2400,customer1,15", "merchant1,800,customer1,16", "merchant1,1000,customer2,17", "merchant1,1400,customer1,10"], ["1000,2,8,15", "1400,5,3,19", "2300,3,17,3", "1800,2,9,6", "1000,4,8,2", "1200,3,11,7"], ["merchant1,10", "merchant2,20"]));
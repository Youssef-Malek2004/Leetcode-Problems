
using Leetcode_Problems.Easy;
using Leetcode_Problems.Hard;
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

Console.Out.WriteLine(new MedianOfTwoSortedArraysSolution().FindMedianSortedArrays([1,2,3],[4,5,6]));

LCA_BTreesSolution.BinaryTreeNode<int> treeNode = new LCA_BTreesSolution.BinaryTreeNode<int>(5);

treeNode.left = new LCA_BTreesSolution.BinaryTreeNode<int>(2);
treeNode.left.left = new LCA_BTreesSolution.BinaryTreeNode<int>(1);
treeNode.left.right = new LCA_BTreesSolution.BinaryTreeNode<int>(3);

treeNode.right = new LCA_BTreesSolution.BinaryTreeNode<int>(7);
treeNode.right.left = new LCA_BTreesSolution.BinaryTreeNode<int>(6);
treeNode.right.right = new LCA_BTreesSolution.BinaryTreeNode<int>(8);

Console.Out.WriteLine(new LCA_BTreesSolution().lcaOfThreeNodes(treeNode,1,3,2).data);

Console.Out.WriteLine(new StringToIntAtoiSolution().MyAtoi("  +  413"));

Console.Out.WriteLine(new LongestPalindromeSubstringSolution().LongestPalindrome("badtfidontknowMAAAAMdadwdawdasd"));

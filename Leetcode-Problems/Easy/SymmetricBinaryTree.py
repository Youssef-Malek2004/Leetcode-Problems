
# Definition for a binary tree node.
from typing import Optional

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def isSymmetric(self, root: Optional[TreeNode]) -> int:
        left_order_list = []

        def leftOrderTraversal(curr):
            nonlocal left_order_list
            
            if curr is None:
                return

            left_order_list.append(curr.val)
            leftOrderTraversal(curr.left)
            leftOrderTraversal(curr.right)

        leftOrderTraversal(root.left)

        right_order_list = []

        def rightOrderTraversal(curr):
            nonlocal right_order_list

            
            if curr is None:
                return

            right_order_list.append(curr.val)
            leftOrderTraversal(curr.right)
            leftOrderTraversal(curr.left)

        rightOrderTraversal(root.right)

        if len(left_order_list) != len(right_order_list):
            return False

        for i in range(len(left_order_list)):
            if left_order_list[i] != right_order_list[i]:
                return False

        return True
# Definition for a binary tree node.
from typing import Optional

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
    
class Solution:
    def rob(self, root: Optional[TreeNode]) -> int:
        dp = {}
        return self.robHelper(root, dp, True)

    def robHelper(self, curr: Optional[TreeNode], dp: dict, can_rob) -> int:
        if curr is None:
            return 0
        
        if (curr, can_rob) in dp.keys():
            return dp[(curr, can_rob)]

        if can_rob:
            rob = curr.val + self.robHelper(curr.left, dp, False) + self.robHelper(curr.right, dp, False)
            no_rob = self.robHelper(curr.left, dp, True) + self.robHelper(curr.right, dp, True)

            dp[(curr, can_rob)] = max(rob, no_rob)

        else:
            dp[(curr, can_rob)] = self.robHelper(curr.left, dp, True) + self.robHelper(curr.right, dp, True)

        return dp[(curr, can_rob)]

    def robHelper2(self, curr: Optional[TreeNode], dp: dict) -> int:
        if curr is None:
            return 0
        
        if curr in dp.keys():
            return dp[curr]

        skip_left = self.robHelper(curr.left.left, dp) + self.robHelper(curr.left.right, dp) if curr.left else 0
        skip_right = self.robHelper(curr.right.left, dp) + self.robHelper(curr.right.right, dp) if curr.right else 0

        rob = curr.val + skip_left + skip_right

        no_rob = self.robHelper(curr.left, dp) + self.robHelper(curr.right, dp)

        dp[curr] = max(rob, no_rob)

        return dp[curr]

        
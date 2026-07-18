# Definition for a binary tree node.
from typing import Optional


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def levelOrder(self, root: Optional[TreeNode]) -> list[list[int]]:
        if root is None:
            return []
            
        levels = []

        def _levelOrder(curr, depth):
            if curr is None:
                return

            if depth == len(levels):
                levels.append([curr.val])
            
            else:
                levels[depth].append(curr.val)

            _levelOrder(curr.left, depth + 1)
            _levelOrder(curr.right, depth + 1)

        _levelOrder(root, 0)

        return levels


        
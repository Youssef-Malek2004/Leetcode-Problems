
# Definition for a binary tree node.
from typing import Optional

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def maxDepth(self, root: Optional[TreeNode]) -> int:
        
        def _maxDepth(curr):
            if curr is None:
                return 0

            return 1 + max(_maxDepth(curr.left), _maxDepth(curr.right))

        return _maxDepth(root)
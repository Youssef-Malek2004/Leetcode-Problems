
# Definition for a binary tree node.
from typing import Optional

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def diameterOfBinaryTree(self, root: Optional[TreeNode]) -> int:
        
        def _diam(curr):
            if curr is None:
                return 0

            diam_left = _diam(curr.left)
            diam_right = _diam(curr.right)

            max_left = (_maxDepth(curr.left)) if curr.left else 0
            max_right = (_maxDepth(curr.right)) if curr.right else 0

            return max(max_left + max_right, diam_left, diam_right)

        def _maxDepth(curr):
            if curr is None:
                return 0

            return 1 + max(_maxDepth(curr.left), _maxDepth(curr.right))

        return _diam(root)
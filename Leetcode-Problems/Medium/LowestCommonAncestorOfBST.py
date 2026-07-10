# Definition for a binary tree node.
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

def findNode(tree: TreeNode, node: TreeNode):
    result = [tree.val]
    
    if tree.val == node.val:
        return result

    found_left = findNodeHelper(tree.left, node, result)
    found_right = findNodeHelper(tree.right,node, result)

    return found_left if found_left else found_right

def findNodeHelper(current: TreeNode, node: TreeNode, listSoFar: list):
    if current is None:
        return None

    listSoFar.append(current.val)

    if current.val == node.val:
        return list(listSoFar)

    found_left = findNodeHelper(current.left, node, listSoFar)
    found_right = findNodeHelper(current.right,node, listSoFar)

    listSoFar.pop()

    return found_left if found_left else found_right

def findNodeBetter(current, p, q):
    if current is None:
        return None

    if current.val == p.val or current.val == q.val:
        return current

    left = findNodeBetter(current.left, p, q)
    right = findNodeBetter(current.right, p, q)

    if left is not None and right is not None:
        return current

    return left if left else right

class Solution:
    def lowestCommonAncestor(self, root: TreeNode, p: TreeNode, q: TreeNode) -> TreeNode:
        # p_path = findNode(root, p)
        # q_path = findNode(root, q)

        # i = 0
        # current = p_path[0]

        # while i < min(len(p_path), len(q_path)) and p_path[i] == q_path[i]:
        #     current = p_path[i]
        #     i +=1

        return findNodeBetter(root, p, q).val
x = Solution()

root = TreeNode(3)
root.left = TreeNode(5)
root.right = TreeNode(2)

sol = x.lowestCommonAncestor(root, TreeNode(2), TreeNode(5))

print(sol) 
from math import inf


class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        last = {}
        left = 0
        res = 0

        for right, c in enumerate[str](s):
            if c in last and last[c] >= left:
                left = last[c] + 1
            
            last[c] = right
            res = max(res, right - left + 1)

        return res
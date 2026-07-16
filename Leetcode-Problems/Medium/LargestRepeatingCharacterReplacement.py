class Solution:
    def characterReplacement(self, s: str, k: int) -> int:
        left, right = 0
        max_freq, sum = 0
        from collections import defaultdict
        count = defaultdict(int)

        for right in range(s):
            count[s[right]] += 1
            max_freq = max(max_freq, count[s[right]])
            if (right - left + 1) - max_freq > k:
                count[s[left]] -= 1
                left += 1

            best = max(best, (right - left + 1))

        return best
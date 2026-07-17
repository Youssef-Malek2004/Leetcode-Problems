import collections


class Solution:
    def characterReplacement(self, s: str, k: int) -> int:
        char_counter = collections.defaultdict(int)
        max_count = 0
        left = 0
        longest = 0

        for right in range(len(s)):
            char_counter[s[right]] += 1
            max_count = max(max_count, char_counter[s[right]])

            if (right - left + 1) - max_count > k:
                char_counter[s[left]] -= 1
                left += 1

            if (right - left + 1) - max_count <= k:
                longest = max(longest, (right - left + 1))

        return longest
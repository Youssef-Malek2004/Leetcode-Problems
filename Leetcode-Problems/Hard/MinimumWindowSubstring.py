import collections
from math import inf


class Solution:
    def minWindow(self, s: str, t: str) -> str:
        char_count = collections.defaultdict(int)
        min_window = None

        for c in t:
            char_count[c] += 1

        def valid():
            print('here')
            for _, v in char_count.items():
                if v > 0:
                    return False

            return True

        required = len(char_count)
        formed = 0

        left = 0
        for right in range(len(s)):
            if s[right] in char_count:
                char_count[s[right]] -= 1

                if char_count[s[right]] == 0:
                    formed += 1

            while left < right:
                if (s[left] in char_count and char_count[s[left]] < 0):
                    char_count[s[left]] += 1
                    left += 1

                elif s[left] not in char_count:
                    left += 1

                else:
                    break

            if formed == required:
                if min_window:
                    if (min_window[1] - min_window[0] + 1) > (right - left + 1):
                        min_window = (left, right)

                else:
                    min_window = [left, right]

        return s[min_window[0] : min_window[1] + 1] if min_window else ""
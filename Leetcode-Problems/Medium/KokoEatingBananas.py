from math import ceil

class Solution:
    def minEatingSpeed(self, piles: list[int], h: int) -> int:
        lo, hi = 1, max(piles)

        while lo < hi:
            mid = (lo + hi) // 2
            hours = sum(ceil(pile / mid) for pile in piles)

            if hours <= h:
                hi = mid
            else:
                lo = mid + 1

        return lo

x = Solution()

sol = x.minEatingSpeed([30,11,23,4,20], 2)

print(sol) 
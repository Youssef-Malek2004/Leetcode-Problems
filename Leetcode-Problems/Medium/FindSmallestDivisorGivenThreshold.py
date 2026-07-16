from math import ceil


class Solution:
    def smallestDivisor(self, nums: list[int], threshold: int) -> int:
        lo, hi = 1, max(nums)
        
        while lo <= hi:
            mid = (hi + lo + 1) // 2

            sum_div = sum([ceil(num / mid) for num in nums])

            valid_div = sum_div <= threshold

            if valid_div:
                hi = mid - 1

            else:
                lo = mid + 1

        return lo
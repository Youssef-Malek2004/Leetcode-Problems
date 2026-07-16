
from math import inf


class Solution:
    def splitArray(self, nums: list[int], k: int) -> int:
        max_sum = sum(nums)
        min_element = max(nums)
        minimal_maximized_sum = inf

        if k == 1:
            return max_sum

        lo, hi = min_element, max_sum

        while lo <= hi:
            mid = (lo + hi + 1) // 2

            curr_sum = 0
            valid = False
            test_k = 1
            max_sums = -inf

            for right in range(len(nums)):
                # If adding the next number exceeds our guessed capacity 'mid'
                if curr_sum + nums[right] > mid:
                    test_k += 1          # Start a new subarray
                    curr_sum = nums[right]
                else:
                    curr_sum += nums[right]

            valid = test_k <= k
            
            if valid:
                minimal_maximized_sum = min(minimal_maximized_sum, mid)
                hi = mid - 1
                continue

            else:
                lo = mid + 1
        
        return minimal_maximized_sum


            

            
        
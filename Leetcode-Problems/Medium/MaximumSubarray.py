from math import inf


class Solution:
    def maxSubArray(self, nums: list[int]) -> int:
        max_sum = -inf
        left = 0

        while left < len(nums) and nums[left] < 0:
            max_sum = max(max_sum, nums[left])
            left += 1

        if left == len(nums):
            return max_sum

        curr_sum = 0
        for right in range(left, len(nums)):
            curr_sum += nums[right]

            while curr_sum < 0 and left <= right:
                curr_sum -= nums[left] 
                left += 1

            max_sum = max(max_sum, curr_sum)

        return max_sum
class Solution:
    def numSubarrayProductLessThanK(self, nums: list[int], k: int) -> int:
        left = 0
        counter = 0

        curr_product = 1
        for right in range(len(nums)):
            if curr_product * nums[right] < k:
                counter += 1
                curr_product = curr_product * nums[right]
                continue
            
            curr_product = curr_product * nums[right]
            while curr_product >= k:
                curr_product = curr_product / nums[left]
                left += 1
        
        return counter
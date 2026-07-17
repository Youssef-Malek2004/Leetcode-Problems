class Solution:
    def longestOnes(self, nums: list[int], k: int) -> int:
        left = 0
        flipped = 0

        longest = 0

        for right in range(len(nums)):
            if nums[right] == 0:
                flipped += 1

            while flipped > k:
                if nums[left] == 0:
                    flipped -= 1

                left += 1

            longest = max(longest, (right - left + 1))

        return longest

        
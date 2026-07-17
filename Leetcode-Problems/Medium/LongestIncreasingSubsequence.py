class Solution:
    def lengthOfLIS(self, nums: list[int]) -> int:
        dp = [-1] * (len(nums) + 1)
        dp[0] = 0

        for i in range(1, len(nums) + 1):
            max_seq = 0

            for j in range(i - 1, -1, -1):
                if nums[j - 1] < nums[i - 1]:
                    max_seq = max(max_seq, dp[j])

            dp[i] = (1 + max_seq)

        max_seq = 0
        for i in range(len(dp)):
            max_seq = max(max_seq, dp[i])

        return max_seq

    def lengthOfLISBinary(self, nums: list[int]) -> int:
        sub = [nums[0]]

        for i in range(1, len(nums)):
            lo, hi = 0, len(sub) - 1

            while lo <= hi:
                mid = (lo + hi + 1) // 2

                if sub[mid] < nums[i]:
                    lo = mid + 1

                elif sub[mid] > nums[i]:
                    hi = mid - 1 

            # We didn't find a place
            if lo == len(sub):
                sub.append(nums[i])

            else:
                sub[lo] = nums[i]

        print(sub)
                


        
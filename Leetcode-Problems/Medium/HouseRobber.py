class Solution:
    def robHelper(self, curr, nums, dp):
        if curr >= len(nums):
            return 0

        if dp[curr] != -1:
            return dp[curr]

        no_rob = self.robHelper(curr + 1, nums, dp)
        rob = nums[curr] + self.robHelper( curr + 2, nums, dp)

        dp[curr] = max(no_rob, rob)

        return dp[curr]

    def rob(self, nums: list[int]) -> int:
        dp = [-1] * (len(nums) + 1)

        return self.robHelper(0, nums, dp)

    def rob(self, nums: list[int]) -> int:
        dp = [-1] * (len(nums) + 1)
        dp[len(nums + 1)] = 

        for i in range(len(nums), -1, -1):

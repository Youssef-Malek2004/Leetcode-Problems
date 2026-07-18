from math import inf


class Solution:
    def maxProduct(self, nums: list[int]) -> int:
        if len(nums) == 1:
            return nums[0]
            
        dp = [[1, 1]] * (len(nums) + 1)
        max_prod = -inf

        for i in range(1, len(nums) + 1):
            if nums[i - 1] < 0:
                if dp[i - 1][1] < 0:
                    max_prod = max(max_prod, dp[i - 1][0])
                    first = dp[i - 1][1] * nums[i - 1]
                    second = dp[i - 1][0] * nums[i - 1]
                    max_prod = max(max_prod, first)

                else:
                    first = 1
                    second = dp[i - 1][0] * nums[i - 1]

            elif nums[i - 1] > 0:
                    first = dp[i - 1][0] * nums[i - 1]
                    second = dp[i - 1][1] * nums[i - 1]
                    max_prod = max(max_prod, first)

            else:
                max_prod = max(max_prod, 0)
                first = 1
                second = 1

            dp[i] = [first, second]

        return max_prod


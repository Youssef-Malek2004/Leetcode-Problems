

from math import inf


class Solution:
    def climbStairs(self, n: int, costs: list[int]) -> int:
        dp = [-1] * ( n + 1 )
        dp[n] = 0

        for i in range(n - 1, -1, -1):
            one_remaining = dp[i + 1]
            two_remaining = dp[i + 2] if (i + 2) <= n else inf
            three_remaining = dp[i + 3] if (i + 3) <= n else inf

            cost_one = costs[i] + 1
            cost_two = costs[i + 1] + 4 if (i + 2) <= n else inf
            cost_three = costs[i + 2] + 9 if (i + 3) <= n else inf

            dp[i] = min(one_remaining + cost_one, two_remaining + cost_two, three_remaining + cost_three)

        return dp[0]

    def climbStairsMemoization(self, n: int, costs: list[int]) -> int:
        dp = [-1] * ( n + 1 )
        return self.climbStairsHelper(0, n, costs, dp)

    def getCost(self, curr, n, costs):
        if curr > n:
            return inf

        return costs[curr - 1]

    def climbStairsHelper(self, curr, n: int, costs: list[int], dp) -> int:
        if curr > n:
            return inf

        if curr == n:
            return 0

        if dp[curr] != -1:
            return dp[curr]

        remaining_one = self.climbStairsHelper(curr + 1, n, costs, dp)
        remaining_two = self.climbStairsHelper(curr + 2, n, costs, dp)
        remaining_three = self.climbStairsHelper(curr + 3, n, costs, dp)

        cost_one = self.getCost(curr + 1, n) + 1
        cost_two = self.getCost(curr + 2, n) + 4
        cost_three = self.getCost(curr + 3, n) + 9

        dp[curr] = min(remaining_one + cost_one, remaining_two + cost_two, remaining_three + cost_three)

        return dp[curr]


        
class Solution:
    def climbStairHelper(self, curr, target, dp):
        if curr == target:
            return 1

        if curr > target:
            return 0

        if dp[curr] > -1:
            return dp[curr] 

        sum = self.climbStairHelper(curr+1, target, dp) + self.climbStairHelper(curr+2, target, dp)
        dp[curr] = sum

        return sum

    def climbStairsMemoization(self, n: int) -> int:
        if n == 0:
            return 0

        dp = [-1] * ( n + 1)

        return self.climbStairHelper(0, n, dp)

    def climbStairs(self, n: int) -> int:
        if n == 0:
            return 0

        next_dot_next = 1
        next = 1

        start = n - 2
        sum = 1

        while start > -1:
            sum = next + next_dot_next
            next_dot_next = next
            next = sum
            start -= 1

        return sum



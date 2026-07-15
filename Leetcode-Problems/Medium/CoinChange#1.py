from math import inf


class Solution:
    def _coinChange(self, coins, remaining, dp):
        if remaining == 0:
            return 0

        if remaining < 0:
            return inf

        if remaining in dp:
            return dp[remaining]

        min_count = inf

        for coin_loop in coins:
            count = 1 + self._coinChange(coins, remaining - coin_loop, dp)

            if count < min_count:
                min_count = count

        dp[remaining] = min_count
        
        return dp[remaining]
        
    def coinChange(self, coins: list[int], amount: int) -> int:
        res = self._coinChange(coins, amount, {})
        return -1 if res == inf else res
        



print(min([1,2]))
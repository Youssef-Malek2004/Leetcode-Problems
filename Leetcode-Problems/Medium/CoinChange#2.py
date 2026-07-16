class Solution:
    def change(self, amount: int, coins: list[int]) -> int:
        if amount == 0:
            return 1

        dp = [[0 for _ in range(len(coins) + 1)] for _ in range((amount + 1))]
        dp[0][0] = 0

        for i in range(1, amount + 1):
            for j in range(1, len(coins) + 1):
                if i - coins[j - 1] < 0:
                    dp[i][j] = dp[i][j - 1]
                    continue

                if i - coins[j - 1] == 0:
                    dp[i][j] = 1 + dp[i][j - 1]
                else:
                    dp[i][j] = dp[i - coins[j - 1]][j] + dp[i][j - 1]

        return dp[amount][len(coins)]

x = Solution()

sol = x.change(5, [1, 2, 5])

print(sol) 
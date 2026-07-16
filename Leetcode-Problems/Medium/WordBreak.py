class Solution:
    def wordBreak(self, s: str, wordDict: list[str]) -> bool:
        dp = {}

        def _wordBreak(start):
            if start == len(s):
                return True

            if start in dp:
                return dp[start]

            for word in wordDict:
                if s.startswith(word, start) and _wordBreak(start + len(word)):
                    dp[start] = True
                    return True

            dp[start] = False
            return False

        return _wordBreak(0)
        
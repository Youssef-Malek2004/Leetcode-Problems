def combinationSumHelper(candidates, target, index, scratchpad, sum, result):
    new_sum = sum + candidates[index]
    scratchpad.append(candidates[index])

    if new_sum == target:
        result.append(list(scratchpad))

    elif new_sum < target:
        while index > -1:
            combinationSumHelper(candidates, target, index, scratchpad, new_sum, result)
            index -=1
            
    scratchpad.pop()
    return

class Solution:
    def combinationSum(self, candidates: list[int], target: int) -> list[list[int]]:
        result = []
        for i, _ in enumerate(candidates):
            combinationSumHelper(candidates, target, i, [], 0, result)
        return result


def norm(res):
    return sorted(sorted(c) for c in res)

if __name__ == "__main__":
    tests = [
        ([3, 2, 6, 7], 7,  [[2, 2, 3], [7]]),
        ([2, 3, 5],    8,  [[2, 2, 2, 2], [2, 3, 3], [3, 5]]),
        ([2],          1,  []),
        ([7, 3, 2],    18, [[2,2,2,2,2,2,2,2,2],[2,2,2,2,2,2,3,3],[2,2,2,2,3,7],
                            [2,2,2,3,3,3,3],[2,2,7,7],[2,3,3,3,7],[3,3,3,3,3,3]]),
    ]

    for candidates, target, expected in tests:
        got = Solution().combinationSum(candidates, target)
        ok = norm(got) == norm(expected)
        print(f"candidates={candidates} target={target}")
        print(f"  got      = {got}")
        print(f"  expected = {expected}")
        print(f"  {'PASS' if ok else 'FAIL'}\n")
class Solution:
    def search(self, nums: list[int], target: int) -> int:
        if len(nums) == 0:
            return -1

        if len(nums) == 1:
            return 0 if nums[0] == target else -1

        before = nums[0]
        left_rotated = False
        for i in range(1, len(nums)):
            if nums[i] < before:
                left_rotated = True
                pivot = i
                break

            before = nums[i]

        if left_rotated:
            if target > nums[-1]:
                lo, hi = 0, pivot - 1
            else:
                lo, hi = pivot, len(nums) - 1
        else:
            lo, hi = 0, len(nums) - 1

        while lo < hi:
            mid = (lo + hi) // 2

            if nums[mid] == target:
                return mid

            if nums[mid] > target:
                hi = mid - 1

            else:
                lo = mid + 1

        return -1


x = Solution()

sol = x.search([3, 1], 0)

print(sol) 
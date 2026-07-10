class Solution:
    def productExceptSelf(self, nums: list[int]) -> list[int]:
        length = len(nums)
        answer = [1] * length

        acc = 1
        for i in range(0, length, 1):
            num = nums[i]
            answer[i] = acc
            acc *= num

        acc = 1
        for i in range(length - 1, -1 , -1):
            num = nums[i]
            answer[i] = answer[i] * acc
            acc *= num

        return answer


x = Solution()

sol = x.productExceptSelf([1,2,3,4])

print(sol) 
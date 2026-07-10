class Solution:
    def twoSum(self, nums: list[int], target: int) -> list[int]:
        dic = {}

        for i, num in enumerate[int] (nums):
            remainder = target - num

            if remainder in dic:
                return [dic[remainder], i]

            dic[num] = i
        
        return None
            

x = Solution()

sol = x.twoSum([1,2,3,4,5], 5)

print(sol)
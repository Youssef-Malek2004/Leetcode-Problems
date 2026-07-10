class Solution:
    def search(self, nums: list[int], target: int) -> int:
        # First find the pivot point
        lo = 0
        hi = len(nums) - 1
        mid = (hi + lo) // 2

        pivot = False

        if nums[0] > nums[-1]: # If there could be a pivot
            pivot = True
            while hi - lo > 1:
                mid = (hi + lo) // 2

                if nums[lo] > nums[mid]: # lo to mid has pivot
                    hi = mid
                
                else:
                    lo = mid

        looping = True
        while looping:
            if (lo < hi and pivot): # If we have a pivot
                remaining = len(nums) - lo
                mid = hi + ((remaining) // 2)

                print(nums)
                print(lo)
                print(mid)
                print(hi)


                if mid >= len(nums):
                    mid -= len(nums)

                if nums[mid] == target:
                    return mid

                if nums[mid] > target:
                    lo = mid

                else :
                    hi = mid + 1
                    if(hi >= len(nums)):
                        hi -= len(nums)

            else: # no pivot
                if pivot:
                    low = hi
                    high = lo
                else:
                    low = lo
                    high = hi

                while high >= low:
                    if high == low:
                        return high if nums[high] == target else -1

                    mid = (high + low) // 2

                    print(nums)
                    print(low)
                    print(f"mid is {mid}")
                    print(high)

                    if nums[mid] == target:
                        return mid

                    if nums[mid] > target:
                        high = mid 
                    else:
                        low = mid + 1

                looping = False

        return -1


x = Solution()

sol = x.search([3, 1], 0)

print(sol) 
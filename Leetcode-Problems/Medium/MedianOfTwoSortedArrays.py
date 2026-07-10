from math import floor, inf

class Solution:
    def findMedianSortedArraysLinear(self, nums1: list[int], nums2: list[int]) -> float:
        lo1, hi1 = 0, len(nums1) - 1
        lo2, hi2 = 0, len(nums2) - 1

        left = (lo1, 1) if nums1[lo1] <= nums2[lo2] else (lo2, 2)
        right = (hi1, 1) if nums1[hi1] > nums2[hi2] else (hi2, 2)

        return None

    def findMedianSortedArrays(self, nums1: list[int], nums2: list[int]) -> float:
        if len(nums1) > len(nums2):
            nums1, nums2 = nums2, nums1

        lo, hi = 0 , len(nums1)
        partition_size = (len(nums1) + len(nums2) + 1) // 2

        while True:
            how_many_one = floor((lo + hi) / 2) # if this is 2 for example on an array of size 5 (we are taking 2 elements from A) then for a partition of 4 we need only 1 element from the other guy
            how_many_two = partition_size - how_many_one # 4 - 2 then 2 so we are taking also 2 elements from B so till index 2
            print(how_many_one)
            print(how_many_two)

            max_one_left = -inf if how_many_one == 0 else nums1[how_many_one - 1]
            min_one_right = inf if how_many_one == len(nums1) else nums1[how_many_one]

            max_two_left = -inf if how_many_two == 0 else nums2[how_many_two - 1]
            min_two_right = inf if how_many_two == len(nums2) else nums2[how_many_two]

            print(f"Max One Left {max_one_left}, Min Two Right {min_two_right}, Max Two Left {max_two_left}, Min One Right {min_one_right}, ")

            if (max_one_left <= min_two_right) and (max_two_left <= min_one_right):
                if (len(nums1) + len(nums2)) % 2 == 0:
                    if len(nums1) == 0:
                        return (max_two_left + min_two_right) / 2
                    
                    if len(nums2) == 0:
                        return (max_one_left + min_one_right) / 2

                    return (max(max_one_left, max_two_left) + min(min_one_right, min_two_right)) / 2

                return max(max_one_left, max_two_left)

            if max_one_left > min_two_right:
                hi = how_many_one - 1
                continue

            if max_two_left > min_one_right:
                lo = how_many_one + 1
                continue
        

x = Solution()

sol = x.findMedianSortedArrays([3], [-2,-1])

print(sol) 
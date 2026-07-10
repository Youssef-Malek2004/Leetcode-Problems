from collections import Counter
import heapq

class Solution:
    def topKFrequent(self, nums: list[int], k: int) -> list[int]:
        num_dict = Counter[int](nums)
        buckets = [[] for _ in range(len(nums) + 1)]

        for num, freq in num_dict.items():
            buckets[freq].append(num)

        print(buckets)

        result = []
        for i in range(len(buckets) - 1, -1, -1):
            for num in buckets[i]:
                result.append(num)
                if len(result) == k:
                    return result

        return result

    def topKFrequentHeap(self, nums: list[int], k: int) -> list[int]:
        num_dict = Counter[int](nums)
        heap = []

        for num, freq in num_dict.items():
            heapq.heappush(heap, (freq, num))
            if len(heap) > k:
                heapq.heappop(heap)

        return [num for _ , num in heap]

x = Solution()

sol = x.topKFrequentHeap([1,1,3,4,4 ], 2)

print(sol) 
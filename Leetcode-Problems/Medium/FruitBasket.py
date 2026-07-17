import collections
from typing import Any


class Solution:
    def totalFruit(self, fruits: list[int]) -> int:
        left = 0
        fruit_types = set[Any]({})
        fruit_count = collections.defaultdict(int)

        for right in range(len(fruits)):
            fruit_count[fruits[right]] += 1
            fruit_types.add(fruits[right])

            if len(fruit_types) > 2:
                fruit_count[fruits[left]] -= 1

                if(fruit_count[fruits[left]] == 0):
                    fruit_types.remove(fruits[left])
                
                left += 1

        return right - left + 1
        
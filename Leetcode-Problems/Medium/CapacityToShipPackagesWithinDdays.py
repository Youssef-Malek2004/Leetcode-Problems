from math import inf

class Solution:
    def shipWithinDays(self, weights: list[int], days: int) -> int:
        lo = max(weights)
        hi = sum(weights)
        minmal_capacity = inf

        while lo <= hi:
            # That is our current capacity
            mid = (hi + lo + 1) // 2

            def get_days():
                curr_capacity = weights[0]
                days_count = 1

                for i in range(1, len(weights)):
                    curr_capacity = curr_capacity + weights[i]

                    if curr_capacity > mid:
                        days_count += 1
                        curr_capacity = weights[i]

                return days_count

            capacity_days = get_days()

            if capacity_days == days:
                minmal_capacity = min(minmal_capacity, mid)
                hi = mid - 1
                continue

            if capacity_days > days:
                lo = mid + 1

            else:
                hi = mid - 1

        return minmal_capacity
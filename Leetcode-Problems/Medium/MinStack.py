from math import inf

class MinStack:

    def __init__(self):
        self.stack_array = []
        self.current_min = inf

    def push(self, value: int) -> None:
        min_before = self.current_min

        if value < self.current_min:
            self.current_min = value

        self.stack_array.append((value, self.current_min, min_before))
        

    def pop(self) -> None:
        value, _ , min_before = self.stack_array.pop(-1)
        self.current_min = min_before
        return value
        

    def top(self) -> int:
        value, _ , _ = self.stack_array[-1]
        return value

    def getMin(self) -> int:
        _ , min , _ = self.stack_array[-1]
        return min


# Your MinStack object will be instantiated and called as such:
# obj = MinStack()
# obj.push(value)
# obj.pop()
# param_3 = obj.top()
# param_4 = obj.getMin()

x = [1,2,3]
x.pop(-1)
print(x)
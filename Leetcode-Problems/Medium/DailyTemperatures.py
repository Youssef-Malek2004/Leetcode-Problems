class Solution:
    def dailyTemperatures(self, temperatures: list[int]) -> list[int]:
        answer = [0] * len(temperatures)
        temperature_stack = [(temperatures[-1], len(temperatures) - 1)]

        for i in range(len(temperatures) - 2, -1, -1):

            while len(temperature_stack) > 0:
                temperature, index = temperature_stack[-1]

                if temperature <= temperatures[i]:
                    temperature_stack.pop(-1)

                if (temperature > temperatures[i]):
                    break

            if len(temperature_stack) == 0:
                answer[i] = 0

            else:
                answer[i] = index - i

            temperature_stack.append((temperatures[i], i))

        return answer
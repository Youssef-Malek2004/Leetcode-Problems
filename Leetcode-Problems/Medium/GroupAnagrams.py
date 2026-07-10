def extractCanonicalForm(str: str):
    count = [0] * 26

    for c in str:
        count[ord(c) - ord('a')] += 1

    return tuple[int, ...](count)

class Solution:
    def groupAnagrams(self, strs: list[str]) -> list[list[str]]:
        anagram_dict: dict[tuple[int, ...], list[str]] = {}

        for str in strs:
            canonical_form = extractCanonicalForm(str)

            if canonical_form in anagram_dict:
                anagram_dict[canonical_form].append(str)
                continue

            anagram_dict[canonical_form] = [str]

        return [value for _ , value in anagram_dict.items()]

x = Solution()

sol = x.groupAnagrams(["eat", "tae", "ccc"])

print(sol) 
const fns = require('./questions');

test.each([
  ["", "", true],
  ["a", "", false],
  ["a", "a", true],
  ["a", "b", false],
  ["ab", "c", false],
  ["aa", "a", false],
  ["abc", "cba", true],
  ["abc", "abd", false]
])('areAnagrams(%p, %p)', (s1, s2, expected) => {
  expect(fns.areAnagrams(s1, s2)).toBe(expected);
});

const testCases_countUniqueValues = [
  [[1, 1, 1, 1, 2], 2],
  [[1, 2, 3, 4, 4, 4, 5, 5, 12, 13], 7],
  [[], 0],
  [[-2, -1, -1, 0, 1], 4]
];

test.each(testCases_countUniqueValues)('countUniqueValues_noExtraStructure(%p)', (arr, expected) => {
  expect(fns.countUniqueValues_noExtraStructure(arr)).toBe(expected);
});

test.each(testCases_countUniqueValues)('countUniqueValues_withMap(%p)', (arr, expected) => {
  expect(fns.countUniqueValues_withMap(arr)).toBe(expected);
});
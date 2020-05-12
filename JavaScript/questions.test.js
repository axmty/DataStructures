const fns = require('./questions');

test.each([
  ["", "", true],
  ["a", "", false],
  ["a", "a", true],
  ["a", "b", false],
  ["ab", "c", false],
  ["aa", "a", false],
  ["abc", "cba", true],
  ["abc", "acb", true],
  ["aac", "aab", false],
  ["abc", "abd", false]
])('validAnagram("%s", "%s")', (s1, s2, expected) => {
  expect(fns.validAnagram(s1, s2)).toBe(expected);
});
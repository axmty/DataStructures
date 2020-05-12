import * as fns from './algorithms';

// ------------------------------------------------------------------------------------------------

test.each([
  ['', '', true],
  ['a', '', false],
  ['a', 'a', true],
  ['a', 'b', false],
  ['ab', 'c', false],
  ['aa', 'a', false],
  ['abc', 'cba', true],
  ['abc', 'abd', false]
])('areAnagrams(%p, %p)', (s1, s2, expected) => {
  expect(fns.areAnagrams(s1, s2)).toBe(expected);
});

// ------------------------------------------------------------------------------------------------

const testCases_countUniqueValues = [
  [[1, 1, 1, 1, 2], 2],
  [[1, 2, 3, 4, 4, 4, 5, 5, 12, 13], 7],
  [[], 0],
  [[3], 1],
  [[-2, -1, -1, 0, 1], 4]
];

test.each(testCases_countUniqueValues)('countUniqueValues_noExtraStructure(%p)', (arr, expected) => {
  expect(fns.countUniqueValues_noExtraStructure(arr)).toBe(expected);
});

test.each(testCases_countUniqueValues)('countUniqueValues_withSet(%p)', (arr, expected) => {
  expect(fns.countUniqueValues_withSet(arr)).toBe(expected);
});

// ------------------------------------------------------------------------------------------------

test.each([
  [1, 1, true],
  [1, 2, false],
  [123, 321, true],
  [12, 32, false],
  [11, 1, false]
])('haveSameDigitFrequencies(%p, %p)', (x, y, expected) => {
  expect(fns.haveSameDigitFrequencies(x, y)).toBe(expected);
});

// ------------------------------------------------------------------------------------------------

const testCases_areThereDuplicates = [
  [[], false],
  [[1], false],
  [[1, 1, 2], true],
  [[1, 2, 3], false],
  [['a', 'b', 'c'], false],
  [['a', 'b', 'c', 'a'], true]
];

test.each(testCases_areThereDuplicates)('areThereDuplicates_withLookup(...%p)', (arr, expected) => {
  expect(fns.areThereDuplicates_withLookup(...arr)).toBe(expected);
});

test.each(testCases_areThereDuplicates)('areThereDuplicates_withSorting(...%p)', (arr, expected) => {
  expect(fns.areThereDuplicates_withSorting(...arr)).toBe(expected);
});

test.each(testCases_areThereDuplicates)('areThereDuplicates_withSet(...%p)', (arr, expected) => {
  expect(fns.areThereDuplicates_withSet(...arr)).toBe(expected);
});

// ------------------------------------------------------------------------------------------------

test.each([
  [[1, 2, 7, 3], 1, 7],
  [[100, 200, 300, 400], 2, 700],
  [[1, 4, 2, 10, 23, 3, 1, 0, 20], 4, 39],
  [[-3, 4, 0, -2, 6, -1], 2, 5],
  [[2, 3], 3, null]
])('maxSubarraySum(%p, %p)', (arr, sliceLength, expected) => {
  expect(fns.maxSubarraySum(arr, sliceLength)).toBe(expected);
});

// ------------------------------------------------------------------------------------------------

test.each([
  [[], 2, false],
  [[2], 2, false],
  [[1, 2, 3], 2.5, true],
  [[1, 3, 3, 5, 6, 7, 10, 12, 19], 8, true],
  [[-1, 0, 3, 4, 5, 6], 4.1, false]
])('averagePair(%p, %p)', (arr, targetAverage, expected) => {
  expect(fns.averagePair(arr, targetAverage)).toBe(expected);
});
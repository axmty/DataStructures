// ------------------------------------------------------------------------------------------------

// Returns true if and only if the two strings are anagrams.
// O(1) space - O(n) time
export function areAnagrams(first, second) {
  if (first.length !== second.length) {
    return false;
  }

  const lookup = {};
  for (let i = 0; i < first.length; i++) {
    const letter = first[i];
    lookup[letter] = (lookup[letter] || 0) + 1;
  }

  for (let i = 0; i < second.length; i++) {
    const letter = second[i];
    if (!lookup[letter]) {
      return false;
    } else {
      lookup[letter] -= 1;
    }
  }

  return true;
}

// ------------------------------------------------------------------------------------------------

// Returns the number of unique values in the array.
// With no extra data structure, array needs to be sorted.
// O(1) space - O(n) time
export function countUniqueValues_noExtraStructure(arr) {
  if (arr.length === 0) {
    return 0;
  }

  let count = 1;
  let val = arr[0];
  for (let i = 1; i < arr.length; i++) {
    if (arr[i - 1] !== arr[i]) {
      count++;
    }
  }

  return count;
}

// With Set, array does not need to be sorted.
// O(n) space - O(n) time
export function countUniqueValues_withSet(arr) {
  return new Set(arr).size;
}

// ------------------------------------------------------------------------------------------------

// Returns true if and and only if the two positive integers have the same frequency of digits.
// O(1) space - O(n) time
export function haveSameDigitFrequencies(x, y) {
  return areAnagrams(String(x), String(y));
}

// ------------------------------------------------------------------------------------------------

// Returns true if and only if there are duplicated arguments.
// With extra lookup Object.
// O(n) space - O(n) time
export function areThereDuplicates_withLookup(...args) {
  const lookup = {};
  for (const arg of args) {
    if (lookup[arg]) {
      return true;
    } else {
      lookup[arg] = true;
    }
  }

  return false;
}

// With sorting.
// O(1) space - O(nlog(n)) time (sort complexity)
export function areThereDuplicates_withSorting(...args) {
  args.sort();

  for (let i = 1; i < args.length; i++) {
    if (args[i - 1] === args[i]) {
      return true;
    }
  }

  return false;
}

// One liner solution with Set.
// O(n) space - O(n) time (in V8 engine, Set.add is O(1) time)
export function areThereDuplicates_withSet(...args) {
  return new Set(args).size !== args.length;
}

// ------------------------------------------------------------------------------------------------

// Given a sorted array of integers, returns true if and only if there is
// a pair of values in the array whose average equals the given average.
// O(1) space - O(n) time
export function averagePair(arr, targetAverage) {
  if (arr.length < 2) {
    return false;
  }

  let start = 0;
  let end = arr.length - 1;
  while (start !== end) {
    const average = (arr[start] + arr[end]) / 2;
    if (average === targetAverage) {
      return true;
    } else if (average < targetAverage) {
      start++;
    } else {
      end--;
    }
  }

  return false;
}

// ------------------------------------------------------------------------------------------------

// Returns true if and only if the first string is a subsequence of the second one, ie.
// the characters in the first string appear in the second string, without their order changing.
// O(1) space - O(n + m) time
export function isSubsequence(s1, s2) {
  let i1 = 0;
  let i2 = 0;
  while (i1 < s1.length && i2 < s2.length) {
    if (s1[i1] === s2[i2]) {
      i1++;
    }

    i2++;
  }

  return i1 === s1.length;
}

// ------------------------------------------------------------------------------------------------

// Returns the maximum sum of a subarray of the given length.
// O(1) space - O(n) time
export function maxSubarraySum(arr, sliceLength) {
  if (sliceLength > arr.length || sliceLength === 0) {
    return null;
  }

  let max = 0;
  for (let i = sliceLength - 1; i < arr.length; i++) {
    let sum = 0;
    for (let j = i - sliceLength + 1; j <= i; j++) {
      sum += arr[j];
    }

    if (sum > max) {
      max = sum;
    }
  }

  return max;
}

// ------------------------------------------------------------------------------------------------

// Returns the minimal length of a subarray of which the sum is
// greater than or equal to the second integer argument.
// Returns 0 if such a subarray is not found.
export function minSubarrayLength(arr, target) {
  let start = 0;
  let end = 0;
  let minLen = Infinity;
  let sum = arr[0];

  while (end < arr.length) {
    if (sum >= target) {
      minLen = Math.min(minLen, end - start + 1);
    }

    if (sum < target || start >= end) {
      end++;
      if (end < arr.length) {
        sum += arr[end];
      }
    } else {
      sum -= arr[start];
      start++;
    }
  }

  return minLen === Infinity ? 0 : minLen;
}
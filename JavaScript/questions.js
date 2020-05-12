// Returns true if and only if the two strings are anagrams.
function areAnagrams(first, second) {
  if (first.length !== second.length) {
    return false;
  }

  const lookup = {};
  for (let i = 0; i < first.length; i++) {
    const letter = first[i];
    lookup[letter] ? lookup[letter] += 1 : lookup[letter] = 1;
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

// Returns the number of unique values in the array (elements are sorted).
// With no extra data structure - O(1) space - O(n) time
function countUniqueValues_noExtraStructure(arr) {
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

// With Map - O(n) space - O(n) time
function countUniqueValues_withMap(arr) {
  return new Set(arr).size;
}

module.exports = {
  areAnagrams,
  countUniqueValues_noExtraStructure,
  countUniqueValues_withMap
};
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
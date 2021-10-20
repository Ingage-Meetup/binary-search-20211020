# Binary Search

The Challenge of Binary Search

Even with the best of designs, every now and then a programmer has to write subtle code. This column is about one problem that requires particularly careful code: binary search.


The problem is to determine whether the sorted array
X[1.. N] contains the element T. Precisely, we know that N > 0 and that X[1] < X[2] < ..- < X[N]. The types of T and
the elements of X are the same; the pseudocode should work equally well for integers, reals or strings. The answer is stored
in the integer P (for position); when P is zero T is not in X[1 .. N], otherwise 1 < P _< N and T = X[P].

Binary search solves the problem by keeping track of a range within the array in which T must be if it is anywhere
in the array. Initially, the range is the entire array. The range is diminished by comparing its middle element to T and
discarding half the range. This process continues until T is discovered in the array or until the range in which it must lie
is known to be empty. The process makes roughly logs N comparisons.

Most programmers think that with the above description in hand, writing the code is easy; they're wrong. The only way
you'll believe this is by putting down this column right now, and writing the code yourself. Try it. 



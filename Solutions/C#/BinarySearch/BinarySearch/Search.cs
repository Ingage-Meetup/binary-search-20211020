using System;

namespace BinarySearch
{
    public class Search
    {
        public Boolean ArrayContainsItem(int[] array, int item)
        {
            return ArrayFind(array, item, 0) >= 0;
        }

        public int ArrayFind(int [] array, int item)
        {
            return ArrayFind(array, item, 0);
        }

        private int ArrayFind(int [] array, int item, int offset)
        {
            // Empty or null array will never contain the item
            if (array == null || array.Length == 0)
            {
                return -1;
            }

            // A single-element array is an easy case to test for
            if (array.Length == 1 && array[0] == item)
            {
                return 0 + offset;
            }

            // If the first element or the last element in the array matches our item, we can short-circuit the rest of the logic below (the item is in the array)
            if (array[0] == item) 
            {
                return 0 + offset;
            } else if (array[^1] == item)
            {
                return array.Length - 1 + offset;
            }

            // If the item is outside the range of the array, we can short-circuit the rest of the logic below (the item is not in the array)
            if (array[0] > item || array[^1] < item)
            {
                return -1;
            }

            // The item falls within the range of the array, but may or may not be an element in the array.
            // Find the "middle" element in the array, then recursively call this method with either the "top" 
            // or "bottom" half of the array (depending which range the item may fall in).
            var middleElementIndex = (int)(Math.Ceiling(array.Length / 2.0)) - 1;
            var middleElementValue = array[middleElementIndex];


            // The '..' syntax below is the new array indexing/range operator introduced with C# 8.0:
            // https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#indices-and-ranges

            // Since we are recursing, and passing slices of the original array, we'll keep track of the offset from the start of
            // the original array. This allows us to keep the code simple, while still being able to return the position of the 
            // found element in the original array.
            int[] slice;
            if(item >= middleElementValue)
            {
                slice = array[middleElementIndex..];
                offset += middleElementIndex;
            } else
            {
                slice = array[0..middleElementIndex];
            }

            return ArrayFind(slice, item, offset);
        }
    }
}

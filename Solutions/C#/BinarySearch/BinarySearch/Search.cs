using System;

namespace BinarySearch
{
    public class Search
    {
        public Boolean ArrayContainsItem(int[] array, int item)
        {
            // Empty or null array will never contain the item
            if(array == null || array.Length == 0)
            {
                return false;
            }

            // A single-element array is an easy case to test for
            if(array.Length == 1 && array[0] == item)
            {
                return true;
            }

            // If the first element or the last element in the array matches our item, we can short-circuit the rest of the logic below (the item is in the array)
            if(array[0] == item || array[^1] == item)
            {
                return true;
            }

            // If the item is outside the range of the array, we can short-circuit the rest of the logic below (the item is not in the array)
            if(array[0] > item || array[^1] < item)
            {
                return false;
            }

            // The item falls within the range of the array, but may or may not be an element in the array.
            // Find the "middle" element in the array, then recursively call this method with either the "top" 
            // or "bottom" half of the array (depending which range the item may fall in).
            var middleElementIndex = (int)(Math.Ceiling(array.Length / 2.0)) - 1;
            var middleElementValue = array[middleElementIndex];

            // This uses the new array indexing/ranges operators introduced with C# 8.0:
            // https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#indices-and-ranges
            var slice = item >= middleElementValue ? array[middleElementIndex ..] : array[0 .. middleElementIndex];

            return ArrayContainsItem(slice, item);
        }
    }
}

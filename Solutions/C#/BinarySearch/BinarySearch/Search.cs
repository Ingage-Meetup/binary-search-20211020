using System;

namespace BinarySearch
{
    public class Search
    {
        public Boolean ArrayContainsItem(int[] array, int item)
        {
            if(array == null || array.Length == 0)
            {
                return false;
            }

            if(array.Length == 1 && array[0] == item)
            {
                return true;
            }

            if(array[0] == item || array[^1] == item)
            {
                return true;
            }

            if(array[0] > item || array[^1] < item)
            {
                return false;
            }

            var middleElementIndex = (int)(Math.Ceiling(array.Length / 2.0)) - 1;
            var middleElementValue = array[middleElementIndex];
            var segment = new ArraySegment<int>(array);
            var slice = item >= middleElementValue ? segment.Slice(middleElementIndex) : segment.Slice(0, middleElementIndex);

            return ArrayContainsItem(slice.ToArray(), item);
        }
    }
}

using System.Collections;

namespace Yield
{
    class Collection : IEnumerable
    {
        private int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }
    }
}
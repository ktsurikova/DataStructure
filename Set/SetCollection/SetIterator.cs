using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCollection
{
    public partial class Set<T> where T : class
    {
        public class IteratorSet
        {
            private T[] iteratorArr;
            private int index = -1;

            public IteratorSet(T[] arr)
            {
                iteratorArr = new T[arr.Length];
                Array.Copy(arr, iteratorArr, arr.Length);
            }

            public bool MoveNext()
            {
                index++;
                return (index < iteratorArr.Length && iteratorArr[index] != null);
            }

            public T Current => iteratorArr[index];

            public void Reset() => index = -1;

        }
    }
}

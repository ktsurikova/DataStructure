using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCollection
{
    public partial class Set<T> : ICloneable, IEnumerable<T>, ISet<T> where T : class, IEquatable<T>
    {
        private class IteratorSet : IEnumerator<T>
        {
            private Set<T> set;
            private int index = -1;

            public IteratorSet(Set<T> other)
            {
                set = other;
            }

            public bool MoveNext() => ++index < set.count;

            public T Current => set.array[index];

            object IEnumerator.Current => set.array[index];

            public void Reset() => index = -1;

            public void Dispose()
            {

            }
        }
    }
}

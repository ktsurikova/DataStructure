using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SetCollection
{
    public partial class Set<T> : ICloneable, IEnumerable<T>, ISet<T> where T : class, IEquatable<T>
        //: ICloneable where T : class
    {

        #region Fields

        private T[] array;
        private int capacity = 8;
        private int count;

        #endregion

        #region Ctors

        public Set()
        {
            array = new T[capacity];
        }

        public Set(int i)
        {
            if (i < 0) throw new SetException("Number of elements is less than 0");
            capacity = i;
            array = new T[i];
        }

        public Set(IEnumerable<T> collection) : this(CountEnumeration(collection))
        {
            if (ReferenceEquals(collection, null)) throw new SetException("Argument is null");
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        #endregion

        public bool IsEmpty => count == 0;

        public int Count => count;

        public bool IsReadOnly => false;

        private bool IsFull() => count == capacity; //expression body 6 C#

        public bool Add(T item)
        {
            if (!Contains(item))
            {
                if (IsFull())
                {
                    capacity *= 2;
                    Array.Resize(ref array, capacity);
                }

                array[count] = item;
                count++;
                return true;
            }
            return false;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(item))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var item in array)
            {
                if (item == null) continue;
                str.Append(item + " ");
            }
            return str.ToString();
        }



        public IEnumerator<T> GetEnumerator() => new IteratorSet(this);
        IEnumerator IEnumerable.GetEnumerator() => new IteratorSet(this);

        //public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)array).GetEnumerator();
        //IEnumerator IEnumerable.GetEnumerator() => array.GetEnumerator();

        //{
        //    return new IteratorSet(array);
        //}

        private static bool ContainsInEnumeration(IEnumerable<T> a, T value)
        {
            foreach (var item in a)
            {
                if (item.Equals(value)) return true;
            }
            return false;
        }

        private static int CountEnumeration(IEnumerable<T> a)
        {
            int i = 0;
            foreach (var item in a)
            {
                i++;
            }
            return i;
        }

        public void UnionWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new SetException("Argument is null");
            foreach (var item in other)
            {
                Add(item);
            }
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new SetException("Argument is null");
            List<T> toRemoveList = new List<T>();
            for (int i = 0; i < count; i++)
            {
                if (!ContainsInEnumeration(other, array[i]))
                    toRemoveList.Add(array[i]);
            }
            foreach (var item in toRemoveList)
            {
                Remove(item);
            }
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new SetException("Argument is null");
            foreach (var item in other)
            {
                Remove(item);
            }
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new SetException("Argument is null");
            List<T> toAddList = new List<T>();
            foreach (var item in other)
            {
                if (!Contains(item))
                    toAddList.Add(item);
            }
            ExceptWith(other);
            foreach (var item in toAddList)
            {
                Add(item);
            }
        }


        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new SetException("Argument is null");
            if (count > CountEnumeration(other)) return false;
            for (int i = 0; i < count; i++)
            {
                if (!ContainsInEnumeration(other, array[i])) return false;
            }
            return true;
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new SetException("Argument is null");
            if (count < CountEnumeration(other)) return false;
            foreach (var item in other)
            {
                if (!Contains(item)) return false;
            }
            return true;
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new SetException("Argument is null");
            if (count <= CountEnumeration(other)) return false;
            return IsSupersetOf(other);
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new SetException("Argument is null");
            if (count >= CountEnumeration(other)) return false;
            return IsSubsetOf(other);
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new SetException("Argument is null");
            foreach (var item in other)
            {
                if (Contains(item)) return true;
            }
            return false;
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new SetException("Argument is null");
            if (ReferenceEquals(other, this)) return true;

            if (CountEnumeration(other) != count) return false;
            return IsEqualsSet(this, other) && IsEqualsSet(other, this);
        }

        private static bool IsEqualsSet(IEnumerable<T> a, IEnumerable<T> b)
        {
            foreach (var item in a)
            {
                if (!ContainsInEnumeration(b, item)) return false;
            }
            return true;
        }

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        public void Clear()
        {
            Array.Clear(array, 0, count);
            count = 0;
        }

        public void CopyTo(T[] otherArray, int arrayIndex)
        {
            if (ReferenceEquals(otherArray, null)) throw new SetException("Array is null");
            if (arrayIndex<0) throw new SetException("arrayIndex is less than 0");
            for (int i = 0; i < count; i++)
            {
                if (arrayIndex + i >= otherArray.Length) break;
                otherArray[arrayIndex + i] = array[i];
            }
        }

        public bool Remove(T item)
        {
            if (!Contains(item)) return false;
            var i = Array.IndexOf(array, item);
            array[i] = array[count - 1];
            array[count - 1] = default(T);
            count--;
            return true;
        }

        public object Clone()
        {
            Set<T> resSet = (Set<T>)MemberwiseClone();
            resSet.array = (T[])array.Clone();
            return resSet;
        }












        ////public bool IsEqualToSet(Set<T> b)
        ////{
        ////    return IsEqualsSet(this, b);
        ////}



        //public static Set<T> Union(Set<T> a, Set<T> b)
        //{
        //    Set<T> resSet = new Set<T>(a.capacity);
        //    Array.Copy(a.array, resSet.array, a.capacity);
        //    resSet.count = a.count;
        //    for (int i = 0; i < b.count; i++)
        //    {
        //        resSet.Add(b.array[i]);
        //    }
        //    return resSet;
        //}


        //public static Set<T> Intersect(Set<T> a, Set<T> b)
        //{
        //    Set<T> resSet = new Set<T>();
        //    for (int i = 0; i < b.count; i++)
        //    {
        //        if (a.Contains(b.array[i]))
        //            resSet.Add(b.array[i]);
        //    }
        //    return resSet;
        //}

        //public static Set<T> Difference(Set<T> lhs, Set<T> rhs)
        //{
        //    Set<T> resSet = new Set<T>();
        //    for (int i = 0; i < lhs.count; i++)
        //    {
        //        if (!rhs.Contains(lhs.array[i]))
        //            resSet.Add(lhs.array[i]);
        //    }
        //    return resSet;
        //}

        //public void IntersectWith(Set<T> other)
        //{
        //    Copy(this, Intersect(this, other));
        //}

        //private static void Copy(Set<T> a, Set<T> b)
        //{
        //    Array.Clear(a.array, 0, a.count);
        //    a.count = 0;

        //    for (int i = 0; i < b.count; i++)
        //    {
        //        a.Add(b.array[i]);
        //    }
        //}

        //public void DifferenceWith(Set<T> b)
        //{
        //    Copy(this, Difference(this, b));
        //}

        //public void UnionWith(Set<T> b)
        //{
        //    for (int i = 0; i < b.count; i++)
        //    {
        //        Add(b.array[i]);
        //    }
        //}

        //public bool IsSubsetOf(Set<T> b)
        //{
        //    return Difference(this, b).IsEmpty;
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCollection
{
    public partial class Set<T> where T : class
    {
        private T[] array;
        private int capacity = 8;
        private int count;

        private Set(int x)
        {
            capacity = x;
            array = new T[capacity];
        }

        public Set(params T[] t) : this()
        {
            for (int i = 0; i < t.Length; i++)
            {
                Add(t[i]);
            }
        }

        public Set()
        {
            array = new T[capacity];
        }

        public void Add(T item)
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

            }
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) return false;
                if (array[i].Equals(item))
                    return true;
            }
            return false;
        }

        public bool IsEmpty => count == 0;
        private bool IsFull() => count == capacity; //expression body 6 C#

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

        public IteratorSet GetIterator()
        {
            return new IteratorSet(array);
        }

        //public override bool Equals(object obj)
        //{
        //    Set<T> b = obj as Set<T>;
        //    if (b == null) return false;
        //    return SetEquals(b);
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

        public bool SetEquals(Set<T> b)
        {
            if (b.count != count) return false;
            for (int i = 0; i < count; i++)
            {
                if (!b.Contains(array[i])) return false;
            }
            return true;
        }

        public Set<T> Union(Set<T> b)
        {
            Set<T> resSet = new Set<T>(capacity);
            Array.Copy(array, resSet.array, capacity);
            resSet.count = count;
            for (int i = 0; i < b.count; i++)
            {
                resSet.Add(b.array[i]);
            }
            return resSet;
        }

        public void UnionWith(Set<T> b)
        {
            for (int i = 0; i < b.count; i++)
            {
                Add(b.array[i]);
            }
        }

        public Set<T> Intersect(Set<T> b)
        {
            Set<T> resSet = new Set<T>();
            for (int i = 0; i < b.count; i++)
            {
                if (Contains(b.array[i]))
                    resSet.Add(b.array[i]);
            }
            return resSet;
        }

        public void IntersectWith(Set<T> b)
        {
            Set<T> resSet = Intersect(b);
            array = resSet.array;
            count = resSet.count;
        }

        public Set<T> Difference(Set<T> b)
        {
            Set<T> resSet = new Set<T>();
            for (int i = 0; i < count; i++)
            {
                if (!b.Contains(array[i]))
                    resSet.Add(array[i]);
            }
            return resSet;
        }

        public void DifferenceWith(Set<T> b)
        {
            Set<T> resSet = Difference(b);
            array = resSet.array;
            count = resSet.count;
        }

        public bool IfSubsetOf(Set<T> b)
        {
            return Difference(b).IsEmpty;
        }
    }
}

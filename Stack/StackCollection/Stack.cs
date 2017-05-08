using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StackCollection
{
    public class Stack<T> : IEnumerable<T> where T : IEquatable<T>
    {
        #region Fields

        private T[] array;
        private int capacity = 8;
        private int count;

        #endregion

        #region Constructors

        public Stack()
        {
            array = new T[capacity];
        }

        public Stack(int capacity)
        {
            if (capacity < 0) throw new StackException("Capacity is less then 0");
            this.capacity = capacity;
            array = new T[capacity];
        }

        public Stack(IEnumerable<T> collection)
        {
            array = new T[collection.Count()];
            if (ReferenceEquals(collection, null)) throw new StackException("collection is null");
            foreach (var item in collection)
            {
                Push(item);
            }
        }

        #endregion

        #region Property

        public int Count => count;

        public bool IsReadOnly => false;

        private bool IsFull() => count == capacity;

        #endregion

        #region Methods

        public void Clear()
        {
            Array.Clear(array, 0, count);
            count = 0;
        }

        public bool Contains(T item)
        {
            if (ReferenceEquals(item, null)) return false;
            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(item)) return true;
            }
            return false;
        }

        public void TrimExcess()
        {
            if (count < capacity * 0.9)
            {
                Array.Resize(ref array, count);
                capacity = count;
            }
        }

        public void Push(T item)
        {
            if (ReferenceEquals(item, null)) return;
            if (IsFull())
            {
                capacity *= 2;
                Array.Resize(ref array, capacity);
            }
            array[count] = item;
            count++;
        }

        public T Pop()
        {
            if (count == 0) throw new StackException("Stack is empty");
            T last = array[count - 1];
            array[count - 1] = default(T);
            count--;
            return last;
        }

        public T Peek()
        {
            if (count == 0) throw new StackException("Stack is empty");
            return array[count - 1];
        }

        public T[] ToArray()
        {
            T[] arr = new T[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = array[count - i - 1];
            }
            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return array[count - i - 1];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        //public IEnumerator<T> GetEnumerator() => new IteratorStack(this);
        //IEnumerator IEnumerable.GetEnumerator() => new IteratorStack(this);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.AppendFormat("{0} ", array[count - i - 1]);
            }
            return sb.ToString();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (ReferenceEquals(array, null)) throw new StackException("array is null");
            if (arrayIndex < 0) throw new StackException("arrayIndex is less than 0");
            for (int i = 0; i < count; i++)
            {
                if (arrayIndex + i >= array.Length) break;
                array[arrayIndex + i] = this.array[count - i - 1];
            }
        }

        #endregion

        #region StackIterator
        private class IteratorStack : IEnumerator<T>
        {
            private Stack<T> stack;
            private int index;

            public IteratorStack(Stack<T> other)
            {
                stack = other;
                index = stack.count;
            }

            public bool MoveNext() => --index >= 0;

            public T Current => stack.array[index];

            object IEnumerator.Current => stack.array[index];

            public void Reset() => index = stack.count;

            public void Dispose()
            {

            }
        } 
        #endregion

    }
}

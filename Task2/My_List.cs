using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class MyList<T> : IList<T>
    {
        private T[] _data;
        private uint _size;
        private uint _capacity;

        public MyList()
        {
            _size = 0;
            _capacity = 0;
            _data = new T[] { };
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_data, item, 0, (int)_size);
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                for (int i = 0; i < _size; ++i)
                {
                    if (_data[i] == null)
                        return true;
                }
                return false;
            }
            else
            {
                EqualityComparer<T> comparer = EqualityComparer<T>.Default;
                for (int i = 0; i < _size; ++i)
                {
                    if (comparer.Equals(_data[i], item)) return true;
                }
                return false;
            }
        }

        public void Clear()
        {
            if (_size > 0)
            {
                Array.Clear(_data, 0, (int)_size);
                _size = 0;
            }
        }

        public int Count { get { return (int)_size; } }

        public T this[int index]
        {
            get
            {
                if (index >= _size)
                {
                    throw new ArgumentOutOfRangeException("index out of range");
                }
                return _data[index];
            }
            set
            {
                if (index >= _size)
                {
                    throw new ArgumentOutOfRangeException("index out of range");
                }
                _data[index] = value;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < _size; ++i)
            {
                yield return _data[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < _size; ++i)
            {
                yield return _data[i];
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T item)
        {
            if (_size == _capacity)
            {
                EnsureCapacity((uint)_capacity * 2 + 2);
                Console.WriteLine("Ensured: {0}", _data.Length);
            }
            _data[_size++] = item;
        }

        public void Insert(int index, T item)
        {
            if (index > _size)
            {
                throw new ArgumentOutOfRangeException("index out of range");
            }
            if (_size == _capacity)
            {
                EnsureCapacity((uint)_size * 2 + 1);
            }
            if (index < _size)
            {
                Array.Copy(_data, index, _data, index + 1, _size - index);
            }
            _data[index] = item;
            _size++;
        }

        private void EnsureCapacity(uint new_capacity)
        {
            T[] new_data = new T[new_capacity];
            Array.Copy(_data, 0, new_data, 0, _capacity);
            _data = new_data;
            _capacity = new_capacity;
        }

        public void RemoveAt(int index)
        {
            if (index >= _size)
            {
                throw new ArgumentOutOfRangeException("index out of range");
            }
            _size--;
            if (index < _size)
            {
                Array.Copy(_data, index + 1, _data, index, _size - index);
            }
            _data[_size] = default(T);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _data.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }
    }
}
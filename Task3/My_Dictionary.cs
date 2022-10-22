using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Globalization;
using System.Collections;
namespace Task3
{
    public class MyDictionary<TKey, TValue>
    {
        private DictionaryEntry[] _items;
        private uint size = 0;
        private uint capacity = 0;

        public MyDictionary(uint count)
        {
            _items = new DictionaryEntry[count];
            size = 0;
            capacity = count;
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (size == capacity)
            {
                Reserve(capacity * 2 + 1);
            }

            _items[size++] = new DictionaryEntry(key, value);
        }

        private void Reserve(uint new_capacity)
        {
            DictionaryEntry[] new_items = new DictionaryEntry[new_capacity];
            Array.Copy(_items, new_items, capacity);
            _items = new_items;
            capacity = new_capacity;
        }

        public ICollection Keys
        {
            get
            {
                TKey[] keys = new TKey[size];
                for (int i = 0; i < size; ++i)
                {
                    keys[i] = (TKey)_items[i].Key;
                }
                return keys;
            }
        }

        public ICollection Values
        {
            get
            {
                TValue[] values = new TValue[size];
                for (int i = 0; i < size; ++i)
                {
                    if ((TValue)_items[i].Value == null)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        values[i] = (TValue)_items[i].Value;
                    }
                }
                return values;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                if (FindByKey(key, out int index))
                {
                    return (TValue)_items[index].Value;
                }
                else { return default(TValue); }
            }
            set
            {
                if (FindByKey(key, out int index))
                {
                    _items[index].Value = value;
                }
                else { Add(key, value); }
            }
        }

        private bool FindByKey(TKey key, out int index)
        {
            for (index = 0; index < size; ++index)
            {
                if (_items[index].Key.Equals(key)) return true;
            }
            return false;
        }

        public uint Count { get => size; }
    }
}

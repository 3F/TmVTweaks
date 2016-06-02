/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;
using System.Collections.Generic;

namespace net.r_eg.TmVTweaks.HotKeys
{
    /// <summary>
    /// Represents identifier of the global hot key.
    /// </summary>
    public class IdentHotKey
    {
        public const int MAX_VALUE = int.MaxValue;
        public const int MIN_VALUE = 1;

        protected volatile int id;
        private object _lock = new object();

        public IEnumerable<int> Iter
        {
            get
            {
                for(int i = MIN_VALUE; i < Current; ++i) {
                    yield return i;
                }
            }
        }

        public int Current
        {
            get { return id; }
        }

        public void Reset()
        {
            id = MIN_VALUE;
        }

        public IdentHotKey Next()
        {
            lock(_lock)
            {
                if(id + 1 > MAX_VALUE
                    || (id > MIN_VALUE && id + 1 <= MIN_VALUE)) // case of overflow for type
                {
                    throw new OverflowException($"no free values for new identifier: {id} / {MAX_VALUE}");
                }
                ++id;

                return this;
            }
        }

        public IdentHotKey()
        {
            Reset();
        }
    }
}

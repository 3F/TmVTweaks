/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;

namespace net.r_eg.TmVTweaks
{
    public struct THandleResult
    {
        /// <summary>
        /// Is actually found the handle.
        /// </summary>
        public bool Found
        {
            get;
            private set;
        }

        /// <summary>
        /// The found handle.
        /// </summary>
        public IntPtr HWnd
        {
            get;
            private set;
        }

        public THandleResult(IntPtr hWnd)
        {
            HWnd    = hWnd;
            Found   = true;
        }
    }
}

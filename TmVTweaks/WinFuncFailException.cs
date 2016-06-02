/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;
using System.Runtime.InteropServices;

namespace net.r_eg.TmVTweaks
{
    [Serializable]
    public class WinFuncFailException: Exception
    {
        public WinFuncFailException(string message)
            : base(detail(message))
        {

        }

        public WinFuncFailException()
            : base(detail(String.Empty))
        {

        }

        protected static string detail(string message)
        {
            return $"{message}[Error: {Marshal.GetLastWin32Error()}]";
        }
    }
}

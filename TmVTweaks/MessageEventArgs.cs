/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;

namespace net.r_eg.TmVTweaks
{
    [Serializable]
    public class MessageEventArgs: EventArgs
    {
        public string Message
        {
            get;
            protected set;
        }

        public string Level
        {
            get;
            protected set;
        }

        public MessageEventArgs(string msg, string level = null)
        {
            Message = msg;
            Level   = level;
        }
    }
}

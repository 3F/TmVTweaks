/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;
using System.Windows.Forms;

namespace net.r_eg.TmVTweaks.HotKeys
{
    [Serializable]
    public class HotKeyEventArgs: EventArgs
    {
        public Modifiers Modifier
        {
            get;
            protected set;
        }

        public Keys Key
        {
            get;
            protected set;
        }

        public Message Msg
        {
            get;
            protected set;
        }

        public HotKeyEventArgs(Modifiers modifier, Keys key, Message m)
        {
            Modifier = modifier;
            Key = key;
            Msg = m;
        }
    }
}

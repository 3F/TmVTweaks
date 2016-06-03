/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;
using System.Windows.Forms;
using net.r_eg.TmVTweaks.WinAPI;

namespace net.r_eg.TmVTweaks.HotKeys
{
    /// <summary>
    /// As variant, we may avoid the handle & WndProc() and use the message queue with GetMessage() 
    /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms644936%28v=vs.85%29.aspx
    /// Example on C++ here: https://msdn.microsoft.com/en-us/library/windows/desktop/ms646309%28v=vs.85%29.aspx
    /// </summary>
    public class GlobalKeys: NativeWindow, IGlobalHotKey, IDisposable
    {
        /// <summary>
        /// When the registered hot key has been pressed.
        /// </summary>
        public event EventHandler<HotKeyEventArgs> KeyPress = delegate(object sender, HotKeyEventArgs e) { };

        internal IUsualLog log = UsualLog._;

        private IdentHotKey uid = new IdentHotKey();
        private object _lock    = new object();

        /// <summary>
        /// To register hot key combination.
        /// </summary>
        /// <param name="mod"></param>
        /// <param name="key"></param>
        /// <returns>Identifier of registered combination.</returns>
        public int register(Modifiers mod, Keys key)
        {
            lock(_lock)
            {
                try {
                    bool success = NativeMethods.RegisterHotKey(Handle, uid.Current, (uint)mod, (uint)key);
                    if(success) {
                        log.info($"The Hotkey {(uint)mod}, {(uint)key} has been registered #{uid.Current}.");
                        return uid.Current;
                    }
                }
                finally {
                    uid.Next();
                }
            }

            throw new WinFuncFailException("the RegisterHotKey returns false.");
        }

        /// <summary>
        /// Frees a hot key by identifier from the register() method.
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
        public bool unregister(int ident)
        {
            log.info($"Free a Hotkey #{ident}");
            return NativeMethods.UnregisterHotKey(Handle, ident);
        }

        /// <summary>
        /// Checks the high-order bit for present key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>true if bit is 1</returns>
        public bool highOrderBitIsOne(Keys key)
        {
            return (NativeMethods.GetKeyState((int)key) & 0x8000) != 0;
        }

        public GlobalKeys()
        {
            CreateHandle(new CreateParams()); // to WndProc
        }

        public void Dispose()
        {
            foreach(var i in uid.Iter) {
                unregister(i);
            }

            DestroyHandle();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if(m.Msg != SysMessages.WM_HOTKEY) {
                return;
            }

            int lParam          = (int)m.LParam;
            Keys key            = (Keys)(lParam >> 16);
            Modifiers modifier  = (Modifiers)(lParam & 0xFFFF);

            KeyPress(this, new HotKeyEventArgs(modifier, key, m));
        }
    }
}

/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

namespace net.r_eg.TmVTweaks.WinAPI
{
    /// <summary>
    /// System-Defined Messages
    /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms644927%28v=vs.85%29.aspx#system_defined
    /// </summary>
    public struct SysMessages
    {
        /// <summary>
        /// When the user presses the left mouse button while the cursor is in the client area of a window. 
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms645607%28v=vs.85%29.aspx
        /// </summary>
        public const int WM_LBUTTONDOWN = 0x0201;

        /// <summary>
        /// When the user releases the left mouse button while the cursor is in the client area of a window.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms645608%28v=vs.85%29.aspx
        /// </summary>
        public const int WM_LBUTTONUP = 0x0202;

        /// <summary>
        /// Posted when the user presses a hot key registered by the RegisterHotKey function. 
        /// The message is placed at the top of the message queue associated with the thread that registered the hot key. 
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms646279%28v=vs.85%29.aspx
        /// </summary>
        public const int WM_HOTKEY = 0x0312;
    }
}

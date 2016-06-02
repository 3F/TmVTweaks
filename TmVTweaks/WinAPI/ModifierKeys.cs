/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

namespace net.r_eg.TmVTweaks.WinAPI
{
    /// <summary>
    /// The keys that must be pressed in combination to generate the WM_HOTKEY message.
    /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms646309%28v=vs.85%29.aspx
    /// 
    /// Virtual-Key Codes:
    /// https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731%28v=vs.85%29.aspx
    /// </summary>
    public struct ModifierKeys
    {
        /// <summary>
        /// Either ALT key must be held down.
        /// </summary>
        public const uint MOD_ALT = 0x0001;

        /// <summary>
        /// Either CTRL key must be held down.
        /// </summary>
        public const uint MOD_CONTROL = 0x0002;

        /// <summary>
        /// Changes the hotkey behavior so that the keyboard auto-repeat does not yield multiple hotkey notifications.
        /// Windows Vista: This flag is not supported.
        /// </summary>
        public const uint MOD_NOREPEAT = 0x4000;

        /// <summary>
        /// Either SHIFT key must be held down.
        /// </summary>
        public const uint MOD_SHIFT = 0x0004;

        /// <summary>
        /// Either WINDOWS key was held down. 
        /// These keys are labeled with the Windows logo. 
        /// Keyboard shortcuts that involve the WINDOWS key are reserved for use by the operating system.
        /// </summary>
        public const uint MOD_WIN = 0x0008;

    }
}

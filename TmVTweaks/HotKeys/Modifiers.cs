/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using net.r_eg.TmVTweaks.WinAPI;

namespace net.r_eg.TmVTweaks.HotKeys
{
    public enum Modifiers: uint
    {
        /// <summary>
        /// Either ALT key must be held down.
        /// </summary>
        AltKey = ModifierKeys.MOD_ALT,

        /// <summary>
        /// Either CTRL key must be held down.
        /// </summary>
        ControlKey = ModifierKeys.MOD_CONTROL,

        /// <summary>
        /// Either SHIFT key must be held down.
        /// </summary>
        ShiftKey = ModifierKeys.MOD_SHIFT,

        /// <summary>
        /// Either WINDOWS key was held down. 
        /// These keys are labeled with the Windows logo. 
        /// Keyboard shortcuts that involve the WINDOWS key are reserved for use by the operating system.
        /// </summary>
        WinKey = ModifierKeys.MOD_WIN,

        /// <summary>
        /// Changes the hotkey behavior so that the keyboard auto-repeat does not yield multiple hotkey notifications.
        /// Windows Vista: This flag is not supported.
        /// </summary>
        NoRepeat = ModifierKeys.MOD_NOREPEAT,
    }
}

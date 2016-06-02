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
    public interface IGlobalHotKey
    {
        /// <summary>
        /// When the registered hot key has been pressed.
        /// </summary>
        event EventHandler<HotKeyEventArgs> KeyPress;

        /// <summary>
        /// To register hot key combination.
        /// </summary>
        /// <param name="mod"></param>
        /// <param name="key"></param>
        /// <returns>Identifier of registered combination.</returns>
        int register(Modifiers mod, Keys key);

        /// <summary>
        /// Frees a hot key by identifier from the register() method.
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
        bool unregister(int ident);

        /// <summary>
        /// Checks the high-order bit for present key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>true if bit is 1</returns>
        bool highOrderBitIsOne(Keys key);
    }
}

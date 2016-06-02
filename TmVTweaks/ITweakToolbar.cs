/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

namespace net.r_eg.TmVTweaks
{
    public interface ITweakToolbar
    {
        /// <summary>
        /// To show/hide the top toolbar.
        /// </summary>
        /// <param name="status"></param>
        void showPanel(bool status);

        /// <summary>
        /// To minimize/maximize the top toolbar.
        /// </summary>
        void minimizePanel();

        /// <summary>
        /// Switching of the fullscreen mode.
        /// </summary>
        void fullscreen();
    }
}

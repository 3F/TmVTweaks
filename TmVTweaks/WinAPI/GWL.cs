/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

namespace net.r_eg.TmVTweaks.WinAPI
{
    /// <summary>
    /// The zero-based offset to the value to be retrieved for GetWindowLong.
    /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms633584%28v=vs.85%29.aspx
    /// </summary>
    public struct GWL
    {
        /// <summary>
        /// Retrieves the extended window styles.
        /// </summary>
        public static int GWL_EXSTYLE = -20;

        /// <summary>
        /// Retrieves a handle to the application instance.
        /// </summary>
        public static int GWL_HINSTANCE = -6;

        /// <summary>
        /// Retrieves a handle to the parent window, if any.
        /// </summary>
        public static int GWL_HWNDPARENT = -8;

        /// <summary>
        /// Retrieves the identifier of the window.
        /// </summary>
        public static int GWL_ID = -12;

        /// <summary>
        /// Retrieves the window styles.
        /// </summary>
        public static int GWL_STYLE = -16;

        /// <summary>
        /// Retrieves the user data associated with the window. 
        /// This data is intended for use by the application that created the window. 
        /// Its value is initially zero.
        /// </summary>
        public static int GWL_USERDATA = -21;

        /// <summary>
        /// Retrieves the address of the window procedure, 
        /// or a handle representing the address of the window procedure. 
        /// You must use the CallWindowProc function to call the window procedure.
        /// </summary>
        public static int GWL_WNDPROC = -4;
    }
}

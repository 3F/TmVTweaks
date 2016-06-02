/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

namespace net.r_eg.TmVTweaks
{
    /// <summary>
    /// Information about controls by default.
    /// Actual for v11.0.59518
    /// </summary>
    internal struct TVControls
    {
        /// <summary>
        /// The main top toolbar.
        /// </summary>
        internal struct ToolBar
        {
            /// <summary>
            /// Toolbar name.
            /// </summary>
            public const string NAME = "TV_CClientToolBar";

            /// <summary>
            /// Optional. Toolbar Control ID.
            /// </summary>
            public const int CID = 0x05D602E8;

            /// <summary>
            /// Control ID of 'Minimize toolbar' button.
            /// </summary>
            public const int MINIMIZE_CID = 0x00000004;

            /// <summary>
            /// Control ID of 'Full screen' button.
            /// </summary>
            public const int FULLSCR_CID = 0x00000002;
        }

        internal struct MainScreen
        {
            /// <summary>
            /// The name of main screen.
            /// </summary>
            public const string NAME = "TV 3.0";

            /// <summary>
            /// Optional. Main screen Control ID.
            /// </summary>
            public const int CID = 0x05D83740;
        }

    }
}

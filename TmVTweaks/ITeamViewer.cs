/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;

namespace net.r_eg.TmVTweaks
{
    public interface ITeamViewer
    {
        /// <summary>
        /// Main handle of TeamViewer process.
        /// </summary>
        IntPtr MainHandle { get; }

        /// <summary>
        /// All found child handles from main.
        /// </summary>
        IEnumerable<IntPtr> ChildHandles { get; }

        /// <summary>
        /// Represents a TeamViewer process.
        /// </summary>
        Process MainProcess { get; }

        /// <summary>
        /// Represents a TeamViewer process via Win32_Process WMI class.
        /// https://msdn.microsoft.com/en-us/library/aa394372%28v=vs.85%29.aspx
        /// </summary>
        ManagementObject MainProcessEx { get; }

        /// <summary>
        /// Path to the executable file of the TeamViewer process.
        /// </summary>
        string ExecutablePath { get; }

        /// <summary>
        /// Command line used to start a specific process, if applicable.
        /// </summary>
        string CommandLine { get; }

        /// <summary>
        /// Emulation of left mouse click.
        /// </summary>
        /// <param name="hWnd"></param>
        void sendClickFor(IntPtr hWnd);

        /// <summary>
        /// To force update of available handles.
        /// </summary>
        void refreshChildHandles();

        /// <summary>
        /// Find and return handle by control text or ID
        /// </summary>
        /// <param name="text">First find with text, if not found use cid.</param>
        /// <param name="cid">Find with cid if for text was not found.</param>
        THandleResult handleBy(string text, int cid);

        /// <summary>
        /// Find and return handle by control ID.
        /// </summary>
        /// <param name="id">Control ID</param>
        THandleResult handleByCID(int id);

        /// <summary>
        /// Find and return handle by text.
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="useMask">additional searching by mask.</param>
        THandleResult handleByText(string expected, bool useMask = true);

        /// <summary>
        /// To show/hide control.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="status">show if true</param>
        void showControl(IntPtr hWnd, bool status);
    }
}

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
using System.Text.RegularExpressions;
using net.r_eg.TmVTweaks.WinAPI;

namespace net.r_eg.TmVTweaks
{
    public class TeamViewer: WndEx, ITeamViewer
    {
        /// <summary>
        /// Main handle of TeamViewer process.
        /// </summary>
        public IntPtr MainHandle
        {
            get {
                return MainProcess.MainWindowHandle;
            }
        }

        /// <summary>
        /// Represents a TeamViewer process.
        /// </summary>
        public Process MainProcess
        {
            get;
            protected set;
        }

        /// <summary>
        /// All found child handles from main.
        /// </summary>
        public IEnumerable<IntPtr> ChildHandles
        {
            get
            {
                if(childHandles == null) {
                    childHandles = getChildWnd(MainHandle);
                }
                return childHandles;
            }
        }
        private IEnumerable<IntPtr> childHandles;

        /// <summary>
        /// Represents a TeamViewer process via Win32_Process WMI class.
        /// https://msdn.microsoft.com/en-us/library/aa394372%28v=vs.85%29.aspx
        /// </summary>
        public ManagementObject MainProcessEx
        {
            get
            {
                if(mainProcessEx != null) {
                    return mainProcessEx;
                }

                foreach(var p in (new ManagementObjectSearcher($"SELECT * FROM Win32_Process WHERE ProcessId = {MainProcess.Id}")).Get()) {
                    mainProcessEx = (ManagementObject)p;
                    break;
                }
                return mainProcessEx;
            }
        }
        private ManagementObject mainProcessEx;

        /// <summary>
        /// Path to the executable file of the TeamViewer process.
        /// </summary>
        public string ExecutablePath
        {
            get
            {
                if(executablePath != null) {
                    return executablePath;
                }

                executablePath = MainProcessEx["ExecutablePath"].ToString();
                return executablePath;
            }
        }
        private string executablePath;

        /// <summary>
        /// Command line used to start a specific process, if applicable.
        /// </summary>
        public string CommandLine
        {
            get {
                if(commandLine != null) {
                    return commandLine;
                }

                commandLine = MainProcessEx["CommandLine"].ToString();
                return commandLine;
            }
        }
        private string commandLine;

        /// <summary>
        /// Emulation of left mouse click.
        /// </summary>
        /// <param name="hWnd"></param>
        public void sendClickFor(IntPtr hWnd)
        {
            sendClick(hWnd, 25);
        }

        /// <summary>
        /// To force update of available handles.
        /// </summary>
        public void refreshChildHandles()
        {
            childHandles = getChildWnd(MainHandle);
        }

        /// <summary>
        /// Find and return handle by control text or ID
        /// </summary>
        /// <param name="text">First find with text, if not found use cid.</param>
        /// <param name="cid">Find with cid if for text was not found.</param>
        public THandleResult handleBy(string text, int cid)
        {
            var h = handleByText(text, true);
            if(h.Found) {
                return h;
            }
            return handleByCID(cid);
        }

        /// <summary>
        /// Find and return handle by control ID
        /// </summary>
        /// <param name="id">Control ID</param>
        public THandleResult handleByCID(int id)
        {
            foreach(var hWnd in ChildHandles) {
                if(getControlId(hWnd) == id) {
                    return new THandleResult(hWnd);
                }
            }
            return default(THandleResult);
        }

        /// <summary>
        /// Find and return handle by text
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="useMask">additional searching by mask.</param>
        public THandleResult handleByText(string expected, bool useMask = true)
        {
            if(String.IsNullOrWhiteSpace(expected)) {
                return default(THandleResult);
            }

            foreach(var hWnd in ChildHandles)
            {
                string actual = getWindowText(hWnd);
                if(!String.IsNullOrWhiteSpace(actual) && actual.Equals(expected, StringComparison.OrdinalIgnoreCase)) {
                    return new THandleResult(hWnd);
                }
            }

            if(!useMask) {
                return default(THandleResult);
            }

            // trying with mask

            string mask = $"^{ Regex.Replace(expected, @"[\W 0-9]", ".*") }$";
            foreach(var hWnd in ChildHandles)
            {
                string actual = getWindowText(hWnd);
                if(!String.IsNullOrWhiteSpace(actual) && Regex.IsMatch(actual, mask, RegexOptions.IgnoreCase)) {
                    return new THandleResult(hWnd);
                }
            }

            return default(THandleResult);
        }

        /// <summary>
        /// To show/hide control.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="status">show if true</param>
        public void showControl(IntPtr hWnd, bool status)
        {
            if(status) {
                setWindowStyle(hWnd, WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_CHILD | WindowStyles.WS_VISIBLE);
                return;
            }
            setWindowStyle(hWnd, WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_CHILD);
        }

        /// <param name="pid">Process ID</param>
        public TeamViewer(int pid)
            : this(Process.GetProcessById(pid))
        {

        }

        /// <param name="p">Found process</param>
        public TeamViewer(Process p)
        {
            MainProcess = p;
        }
    }
}

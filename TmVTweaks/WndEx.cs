/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using net.r_eg.TmVTweaks.WinAPI;

namespace net.r_eg.TmVTweaks
{
    /// <summary>
    /// Common operations for window.
    /// </summary>
    public abstract class WndEx 
    {
        internal IUsualLog log = new UsualLog();

        protected void setWindowStyle(IntPtr hWnd, long style)
        {
            NativeMethods.SetWindowLong(hWnd, GWL.GWL_STYLE, style);
        }

        protected bool isVisible(IntPtr hWnd)
        {
            long style = getWindowStyle(hWnd);
            return (style & WindowStyles.WS_VISIBLE) != 0;
        }

        protected long getWindowStyle(IntPtr hWnd)
        {
            return NativeMethods.GetWindowLong(hWnd, GWL.GWL_STYLE);
        }

        protected void sendClick(IntPtr hWnd, int delay)
        {
            NativeMethods.SendMessage(hWnd, SysMessages.WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
            Thread.Sleep(delay);
            NativeMethods.SendMessage(hWnd, SysMessages.WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
        }

        protected void refresh(IntPtr hWnd)
        {
            NativeMethods.InvalidateRect(hWnd, IntPtr.Zero, true);
            NativeMethods.UpdateWindow(hWnd);
        }

        protected int getControlId(IntPtr hWnd)
        {
            return NativeMethods.GetWindowLong(hWnd, GWL.GWL_ID);
        }

        protected string getWindowText(IntPtr hWnd)
        {
            var buffer = new StringBuilder();
            NativeMethods.GetWindowText(hWnd, buffer, 200);

            return buffer.ToString();
        }

        protected IEnumerable<IntPtr> getChildWnd(IntPtr parent)
        {
            List<IntPtr> res = new List<IntPtr>();
            GCHandle gch = GCHandle.Alloc(res);
            try {
                var proc = new NativeMethods.EnumChildProc(childProcCallback);
                NativeMethods.EnumChildWindows(parent, proc, GCHandle.ToIntPtr(gch));
            }
            finally {
                gch.Free();
            }

            return res;
        }

        private bool childProcCallback(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            try {
                ((List<IntPtr>)gch.Target).Add(handle);
                return true;
            }
            catch(Exception ex) {
                log.debug(ex.Message);
            }

            return false;
        }
    }
}

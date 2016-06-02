/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace net.r_eg.TmVTweaks.WinAPI
{
    public static class NativeMethods
    {
        /// <summary>
        /// The system assigns a slightly higher priority to the thread that created the foreground window. 
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms633539%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetForegroundWindow(HandleRef hWnd);

        /// <summary>
        /// Enumerates the child windows that belong to the specified parent window.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms633494%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="hWndParent">A handle to the parent window.</param>
        /// <param name="lpEnumFunc">A pointer to an application-defined callback function.</param>
        /// <param name="lParam">Allocated list that to be passed to the callback function.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildProc lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// The delegate for callback function that will be used with the EnumChildWindows function.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms633493%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="hWnd">A handle to a child window.</param>
        /// <param name="lParam">Allocated list of child handles.</param>
        /// <returns></returns>
        public delegate bool EnumChildProc(IntPtr hWnd, IntPtr lParam);

        /// <summary>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms633520%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpString"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowText(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// Retrieves information about the specified window.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms633584%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        /// <summary>
        /// Changes an attribute of the specified window.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms633591%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong);

        /// <summary>
        /// Defines a system-wide hot key.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms646309%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <param name="fsModifiers"></param>
        /// <param name="vk"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        /// <summary>
        /// Frees a hot key previously registered by the calling thread.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms646327%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms644950%28v=vs.85%29.aspx
        /// Messages: 
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms644927%28v=vs.85%29.aspx#app_defined
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Adds a rectangle to the specified window's update region. The update region represents the portion of the window's client area that must be redrawn.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/dd145002%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpRect">If this parameter is NULL, the entire client area is added to the update region.</param>
        /// <param name="bErase">If this parameter is TRUE, the background is erased when the BeginPaint function is called. If this parameter is FALSE, the background remains unchanged.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        /// <summary>
        /// Updates the client area of the specified window by sending a WM_PAINT message to the window if the window's update region is not empty.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/dd145167%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateWindow(IntPtr hWnd);

        /// <summary>
        /// Retrieves the status of the specified virtual key.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms646301%28v=vs.85%29.aspx
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="nVirtKey"></param>
        /// <returns></returns>
        [DllImport("USER32.dll", CharSet = CharSet.Auto)]
        public static extern short GetKeyState(int nVirtKey);

        /// <summary>
        /// Changes the position and dimensions of the specified window. 
        /// For a top-level window, the position and dimensions are relative to the upper-left corner of the screen. 
        /// For a child window, they are relative to the upper-left corner of the parent window's client area. 
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms633534%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        /// <param name="bRepaint">
        ///     If this parameter is TRUE, the window receives a message. 
        ///     If the parameter is FALSE, no repainting of any kind occurs. 
        ///     This applies to the client area, the nonclient area (including the title bar and scroll bars), 
        ///     and any part of the parent window uncovered as a result of moving a child window.
        /// </param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

        /// <summary>
        /// The RECT structure defines the coordinates of the upper-left and lower-right corners of a rectangle.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/dd162897%28v=vs.85%29.aspx
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;   // x1
            public int top;    // y1
            public int right;  // x2
            public int bottom; // y2
        }

        /// <summary>
        /// Retrieves the coordinates of a window's client area.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms633503%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpRect"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);
    }
}

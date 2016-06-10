/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;
using System.Runtime.InteropServices;
using net.r_eg.TmVTweaks.WinAPI;

namespace net.r_eg.TmVTweaks
{
    public sealed class TweakScreen: WndEx, ITweakScreen
    {
        private ITeamViewerCollection data;

        /// <summary>
        /// Update position of screen to x1(0), y1(0)
        /// </summary>
        public void zeroPosition()
        {
            foreach(var tvs in data.TeamViewers)
            {
                ITeamViewer tv  = tvs.Value;
                THandleResult h = tv.handleBy(TVControls.MainScreen.NAME, TVControls.MainScreen.CID);
                if(!h.Found) {
                    continue;
                }
                log.debug($"zeroPosition: found handle - {h.HWnd}");

                NativeMethods.RECT r;

                if(!NativeMethods.GetClientRect(h.HWnd, out r)) {
                    log.info($"GetClientRect [Error: {Marshal.GetLastWin32Error()}]");
                    continue;
                }

                // Fix Top 1 -> 0
                if(!NativeMethods.MoveWindow(h.HWnd, 0, 0, r.right + r.left, r.bottom + r.top, true)) {
                    log.info($"MoveWindow [Error: {Marshal.GetLastWin32Error()}]");
                    continue;
                }
            }
        }

        /// <param name="tvc"></param>
        public TweakScreen(ITeamViewerCollection tvc)
        {
            if(tvc == null) {
                throw new ArgumentException("Collection cannot be as null", "tvc");
            }

            data = tvc;
        }
    }
}

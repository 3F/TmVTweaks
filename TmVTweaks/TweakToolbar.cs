/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;

namespace net.r_eg.TmVTweaks
{
    public sealed class TweakToolbar: WndEx, ITweakToolbar
    {
        private ITeamViewerCollection data;

        /// <summary>
        /// To show/hide the top toolbar.
        /// </summary>
        /// <param name="status"></param>
        public void showPanel(bool status)
        {
            foreach(var tvs in data.TeamViewers)
            {
                ITeamViewer tv  = tvs.Value;
                THandleResult h = tv.handleBy(TVControls.ToolBar.NAME, TVControls.ToolBar.CID);
                if(h.Found) {
                    log.debug($"showPanel({status}): found handle - {h.HWnd}");
                    tv.showControl(h.HWnd, status);

                    // to redraw controls
                    THandleResult hScr = tv.handleBy(TVControls.MainScreen.NAME, TVControls.MainScreen.CID);
                    refresh(status ? h.HWnd : hScr.HWnd);
                }
            }
        }

        /// <summary>
        /// To minimize/maximize the top toolbar.
        /// </summary>
        public void minimizePanel()
        {
            foreach(var tvs in data.TeamViewers)
            {
                ITeamViewer tv  = tvs.Value;
                THandleResult h = tv.handleByCID(TVControls.ToolBar.MINIMIZE_CID);
                if(h.Found) {
                    log.debug($"minimizePanel: found handle - {h.HWnd}");
                    tv.sendClickFor(h.HWnd);
                }
            }
        }

        /// <summary>
        /// Switching of the fullscreen mode.
        /// </summary>
        public void fullscreen()
        {
            foreach(var tvs in data.TeamViewers)
            {
                ITeamViewer tv  = tvs.Value;
                THandleResult h = tv.handleByCID(TVControls.ToolBar.FULLSCR_CID);
                if(h.Found) {
                    log.debug($"fullscreen: found handle - {h.HWnd}");
                    tv.sendClickFor(h.HWnd);
                }
            }
        }

        /// <param name="tvc"></param>
        public TweakToolbar(ITeamViewerCollection tvc)
        {
            if(tvc == null) {
                throw new ArgumentException("Collection cannot be as null", "tvc");
            }

            data = tvc;
        }
    }
}

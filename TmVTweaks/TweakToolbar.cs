/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;
using System.Collections.Generic;

namespace net.r_eg.TmVTweaks
{
    public sealed class TweakToolbar: WndEx, ITweakToolbar
    {
        private ITeamViewerCollection data;

        private struct IterResult
        {
            public ITeamViewer teamViewer;
            public IntPtr hWnd;

            public IterResult(ITeamViewer tv, IntPtr hWnd)
            {
                teamViewer  = tv;
                this.hWnd   = hWnd;
            }
        }

        /// <summary>
        /// Available toolbars from existing TeamViwer collection.
        /// </summary>
        private IEnumerable<IterResult> Toolbars
        {
            get
            {
                foreach(var tvs in data.TeamViewers)
                {
                    ITeamViewer tv  = tvs.Value;
                    THandleResult h = tv.handleBy(TVControls.ToolBar.NAME, TVControls.ToolBar.CID);
                    if(h.Found) {
                        yield return new IterResult(tv, h.HWnd);
                    }
                }
            }
        }

        /// <summary>
        /// To show/hide the top toolbar.
        /// </summary>
        /// <param name="status"></param>
        public void showPanel(bool status)
        {
            foreach(IterResult t in Toolbars)
            {
                log.debug($"showPanel({status}): found handle - {t.hWnd}");
                t.teamViewer.showControl(t.hWnd, status);

                // to redraw controls
                THandleResult hScr = t.teamViewer.handleBy(TVControls.MainScreen.NAME, TVControls.MainScreen.CID);
                if(hScr.Found) {
                    refresh(status ? t.hWnd : hScr.HWnd);
                }
            }
        }

        /// <summary>
        /// To minimize/maximize the top toolbar.
        /// </summary>
        public void minimizePanel()
        {
            foreach(IterResult t in Toolbars)
            {
                THandleResult h = t.teamViewer.handleByCID(TVControls.ToolBar.MINIMIZE_CID);
                if(h.Found) {
                    log.debug($"minimizePanel: found handle - {h.HWnd}");
                    t.teamViewer.sendClickFor(h.HWnd);
                }
            }
        }

        /// <summary>
        /// Switching of the fullscreen mode.
        /// </summary>
        public void fullscreen()
        {
            foreach(IterResult t in Toolbars)
            {
                THandleResult h = t.teamViewer.handleByCID(TVControls.ToolBar.FULLSCR_CID);
                if(h.Found) {
                    log.debug($"fullscreen: found handle - {h.HWnd}");
                    t.teamViewer.sendClickFor(h.HWnd);
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

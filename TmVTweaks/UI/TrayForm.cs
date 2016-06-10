/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using net.r_eg.TmVTweaks.HotKeys;
using net.r_eg.TmVTweaks.WinAPI;

namespace net.r_eg.TmVTweaks.UI
{
    public sealed partial class TrayForm: Form
    {
        private GlobalKeys hotKeys = new GlobalKeys();
        private ITeamViewerCollection teamViewers = new TeamViewerCollection();

        private ITweakToolbar twToolbar;
        private ITweakScreen twScreen;

        private IUsualLog log = UsualLog._;

        public TrayForm()
        {
            InitializeComponent();

            try {
                notifyIconMain.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            catch(ArgumentException ex) {
                log.debug(ex.Message);
            }

            notifyIconMain.Text = menuCaption.Text
                                = $"{Text} v{Application.ProductVersion}";

            hotKeys.KeyPress        += onHotKeys;
            teamViewers.BeforeAdd   += onTvBeforeAdd;
            teamViewers.Updated     += onTvUpdated;
            log.Received            += LogMsgReceived;

            tweaksInit(teamViewers);
            monitoring(true);
        }

        private void tweaksInit(ITeamViewerCollection tvs)
        {
            tvs.findAll();
            twToolbar   = new TweakToolbar(tvs);
            twScreen    = new TweakScreen(tvs);

            Modifiers mcomb = Modifiers.ControlKey | Modifiers.AltKey | Modifiers.ShiftKey;
            try {
                hotKeys.register(mcomb, Keys.F12);
                hotKeys.register(mcomb, Keys.F11);
                hotKeys.register(mcomb, Keys.F10);
                hotKeys.register(mcomb, Keys.F1);
            }
            catch(Exception ex) {
                log.info(ex.Message);
            }
        }

        /// <summary>
        /// thread-safe ui changes
        /// </summary>
        /// <param name="m"></param>
        private void uiAction(MethodInvoker m)
        {
            if(InvokeRequired) {
                BeginInvoke(m);
                return;
            }
            m();
        }

        private void showToolbar(bool status)
        {
            twToolbar.showPanel(status);
            menuToolBarShow.Checked = status;
        }

        private void monitoring(bool status)
        {
            teamViewers.monitoring(status);
            menuMonitoring.Checked = status;
        }

        /// <summary>
        /// Open url in default web-browser
        /// </summary>
        /// <param name="url"></param>
        private void openUrl(string url)
        {
            System.Diagnostics.Process.Start(url);
        }

        private void dispose()
        {
            log.Received -= LogMsgReceived;
            hotKeys.Dispose();
        }

        private void onHotKeys(object sender, HotKeyEventArgs e)
        {
            if(e.Modifier != (Modifiers.ControlKey | Modifiers.AltKey | Modifiers.ShiftKey)) {
                return;
            }

            if(!hotKeys.highOrderBitIsOne(Keys.RShiftKey)) {
                return;
            }

            log.info($"Received [Ctrl + Alt + RShift] + {e.Key}");
            switch(e.Key)
            {
                case Keys.F9: {
                    menuReposScreen_Click(sender, e);
                    return;
                }
                case Keys.F11: {
                    menuFullScreen_Click(sender, e);
                    return;
                }
                case Keys.F10: {
                    menuToolBarShow_Click(sender, e);
                    return;
                }
                case Keys.F1: {
                    menuToolBarMinimize_Click(sender, e);
                    return;
                }
                case Keys.F12: {
                    showToolbar(false);
                    menuFullScreen_Click(sender, e);
                    menuReposScreen_Click(sender, e);
                    return;
                }
            }
        }

        private void onTvUpdated(object sender, EventArgs e)
        {
            var collection = ((ITeamViewerCollection)sender).TeamViewers;

            uiAction(() => menuTeamViewers.Enabled = (collection.Count > 0));
            uiAction(() => menuTeamViewers.DropDownItems.Clear());

            foreach(var tvs in collection)
            {
                ITeamViewer tv = tvs.Value;
                uiAction(() =>
                    menuTeamViewers.DropDownItems.Add(
                        new ToolStripMenuItem($"PID: {tv.MainProcess.Id} :: {tv.ExecutablePath}") {
                            ToolTipText = tv.CommandLine
                        }
                    )
                );
            }
        }

        private void onTvBeforeAdd(object sender, TeamViewerEventArgs e)
        {

        }

        private void LogMsgReceived(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            const int MAXL = 70;

            if(menuMessages.DropDownItems.Count >= 15) {
                uiAction(() => menuMessages.DropDownItems.RemoveAt(0));
            }

            uiAction(() =>
                    menuMessages.DropDownItems.Add(
                        new ToolStripMenuItem((msg.Length > MAXL)? msg.Substring(0, MAXL) + "..." : msg) {
                            ToolTipText = msg
                        }
                    )
            );
        }

        private void notifyIconMain_Click(object sender, EventArgs e)
        {
            NativeMethods.SetForegroundWindow(new HandleRef(sender, Handle)); // fixes of destroying menu
            menuTray.Show(this, PointToClient(Cursor.Position));
        }

        private void notifyIconMain_DoubleClick(object sender, EventArgs e)
        {
            notifyIconMain_Click(sender, e);
        }

        private void menuSearch_Click(object sender, EventArgs e)
        {
            teamViewers.findAll();
        }

        private void menuMonitoring_Click(object sender, EventArgs e)
        {
            monitoring(!menuMonitoring.Checked);
        }

        private void menuToolBarShow_Click(object sender, EventArgs e)
        {
            showToolbar(!menuToolBarShow.Checked);
        }

        private void menuToolBarMinimize_Click(object sender, EventArgs e)
        {
            menuToolBarMinimize.Checked = !menuToolBarMinimize.Checked;
            twToolbar.minimizePanel();
        }

        private void menuFullScreen_Click(object sender, EventArgs e)
        {
            menuFullScreen.Checked = !menuFullScreen.Checked;
            twToolbar.fullscreen();
        }

        private void menuReposScreen_Click(object sender, EventArgs e)
        {
            twScreen.zeroPosition();
        }

        private void menuTweakNew_Click(object sender, EventArgs e)
        {
            openUrl("https://github.com/3F/TmVTweaks/fork");
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Version: {Application.ProductVersion}\n\nLicense: MIT\nDenis Kuzmin < entry.reg@gmail.com >", 
                            Text, 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
        }

        private void menuSrcCode_Click(object sender, EventArgs e)
        {
            openUrl("https://github.com/3F/TmVTweaks");
        }

        private void TrayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            dispose();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

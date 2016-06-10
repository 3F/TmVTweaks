namespace net.r_eg.TmVTweaks.UI
{
    partial class TrayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            hotKeys.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCaption = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuTweaks = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolBarShow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolBarMinimize = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuReposScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuTweakNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSrcCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTeamViewers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMonitoring = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.menuTray;
            this.notifyIconMain.Text = "TmVTweaks";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.Click += new System.EventHandler(this.notifyIconMain_Click);
            this.notifyIconMain.DoubleClick += new System.EventHandler(this.notifyIconMain_DoubleClick);
            // 
            // menuTray
            // 
            this.menuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCaption,
            this.toolStripSeparator4,
            this.menuTweaks,
            this.menuSrcCode,
            this.menuSettings,
            this.menuSearch,
            this.menuMonitoring,
            this.menuTeamViewers,
            this.toolStripSeparator1,
            this.menuAbout,
            this.menuExit});
            this.menuTray.Name = "menuTray";
            this.menuTray.Size = new System.Drawing.Size(189, 236);
            // 
            // menuCaption
            // 
            this.menuCaption.Enabled = false;
            this.menuCaption.Name = "menuCaption";
            this.menuCaption.Size = new System.Drawing.Size(188, 22);
            this.menuCaption.Text = "TmVTweaks v1.0";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(185, 6);
            // 
            // menuTweaks
            // 
            this.menuTweaks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolBarShow,
            this.menuToolBarMinimize,
            this.menuFullScreen,
            this.toolStripSeparator2,
            this.menuReposScreen,
            this.toolStripSeparator3,
            this.toolStripMenuItem1,
            this.toolStripSeparator5,
            this.menuTweakNew});
            this.menuTweaks.Name = "menuTweaks";
            this.menuTweaks.Size = new System.Drawing.Size(188, 22);
            this.menuTweaks.Text = "Tweaks";
            // 
            // menuToolBarShow
            // 
            this.menuToolBarShow.Checked = true;
            this.menuToolBarShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuToolBarShow.Name = "menuToolBarShow";
            this.menuToolBarShow.ShortcutKeyDisplayString = "[ Ctrl + Alt + RShift + F10 ]";
            this.menuToolBarShow.Size = new System.Drawing.Size(403, 22);
            this.menuToolBarShow.Text = "Show/Hide incredible ToolBar";
            this.menuToolBarShow.Click += new System.EventHandler(this.menuToolBarShow_Click);
            // 
            // menuToolBarMinimize
            // 
            this.menuToolBarMinimize.Name = "menuToolBarMinimize";
            this.menuToolBarMinimize.ShortcutKeyDisplayString = "[ Ctrl + Alt + RShift + F1   ]";
            this.menuToolBarMinimize.Size = new System.Drawing.Size(403, 22);
            this.menuToolBarMinimize.Text = "Minimize/Maximize ToolBar";
            this.menuToolBarMinimize.Click += new System.EventHandler(this.menuToolBarMinimize_Click);
            // 
            // menuFullScreen
            // 
            this.menuFullScreen.Name = "menuFullScreen";
            this.menuFullScreen.ShortcutKeyDisplayString = "[ Ctrl + Alt + RShift + F11 ]";
            this.menuFullScreen.Size = new System.Drawing.Size(403, 22);
            this.menuFullScreen.Text = "FullScreen";
            this.menuFullScreen.Click += new System.EventHandler(this.menuFullScreen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(400, 6);
            // 
            // menuReposScreen
            // 
            this.menuReposScreen.Name = "menuReposScreen";
            this.menuReposScreen.ShortcutKeyDisplayString = "[ Ctrl + Alt + RShift + F9   ]";
            this.menuReposScreen.Size = new System.Drawing.Size(403, 22);
            this.menuReposScreen.Text = "Reposition screen: Fix top Y1 -> Y0";
            this.menuReposScreen.Click += new System.EventHandler(this.menuReposScreen_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(400, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeyDisplayString = "[ Ctrl + Alt + RShift + F12 ]";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(403, 22);
            this.toolStripMenuItem1.Text = "Hide ToolBar && Fullscreen + Repos";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(400, 6);
            // 
            // menuTweakNew
            // 
            this.menuTweakNew.Name = "menuTweakNew";
            this.menuTweakNew.Size = new System.Drawing.Size(403, 22);
            this.menuTweakNew.Text = "Add new Tweak";
            this.menuTweakNew.Click += new System.EventHandler(this.menuTweakNew_Click);
            // 
            // menuSrcCode
            // 
            this.menuSrcCode.Name = "menuSrcCode";
            this.menuSrcCode.Size = new System.Drawing.Size(188, 22);
            this.menuSrcCode.Text = "Source code [GitHub]";
            this.menuSrcCode.Click += new System.EventHandler(this.menuSrcCode_Click);
            // 
            // menuSettings
            // 
            this.menuSettings.Enabled = false;
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(188, 22);
            this.menuSettings.Text = "Settings";
            // 
            // menuSearch
            // 
            this.menuSearch.Name = "menuSearch";
            this.menuSearch.Size = new System.Drawing.Size(188, 22);
            this.menuSearch.Text = "New search";
            this.menuSearch.Click += new System.EventHandler(this.menuSearch_Click);
            // 
            // menuTeamViewers
            // 
            this.menuTeamViewers.Name = "menuTeamViewers";
            this.menuTeamViewers.Size = new System.Drawing.Size(188, 22);
            this.menuTeamViewers.Text = "Found TeamViewers";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(188, 22);
            this.menuAbout.Text = "About";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(188, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuMonitoring
            // 
            this.menuMonitoring.Name = "menuMonitoring";
            this.menuMonitoring.Size = new System.Drawing.Size(188, 22);
            this.menuMonitoring.Text = "Monitoring";
            this.menuMonitoring.Click += new System.EventHandler(this.menuMonitoring_Click);
            // 
            // TrayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 32);
            this.Location = new System.Drawing.Point(-400, -400);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrayForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TmVTweaks";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TrayForm_FormClosed);
            this.menuTray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ContextMenuStrip menuTray;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuTweaks;
        private System.Windows.Forms.ToolStripMenuItem menuToolBarShow;
        private System.Windows.Forms.ToolStripMenuItem menuToolBarMinimize;
        private System.Windows.Forms.ToolStripMenuItem menuFullScreen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuReposScreen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuTweakNew;
        private System.Windows.Forms.ToolStripMenuItem menuSrcCode;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem menuTeamViewers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem menuCaption;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuSearch;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuMonitoring;
    }
}


/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace net.r_eg.TmVTweaks
{
    public class TeamViewerCollection: ITeamViewerCollection
    {
        /// <summary>
        /// The process name by default.
        /// </summary>
        protected const string DEFAULT_PROCNAME = "TeamViewer";

        /// <summary>
        /// Before adding TeamViewer to collection.
        /// </summary>
        public event EventHandler<TeamViewerEventArgs> BeforeAdd = delegate(object sender, TeamViewerEventArgs e) { };

        /// <summary>
        /// When collection finally updated.
        /// </summary>
        public event EventHandler<EventArgs> Updated = delegate(object sender, EventArgs e) { };

        internal IUsualLog log = UsualLog._;

        /// <summary>
        /// flag of processing of monitoring.
        /// </summary>
        private volatile bool isMonitoringActive;
        private object _lock = new object();

        /// <summary>
        /// The process name for searching of the TeamViewer for this collection.
        /// </summary>
        public string ProcessName
        {
            get;
            protected set;
        }

        /// <summary>
        /// Interval of monitoring of processes.
        /// </summary>
        public int MonitoringInterval
        {
            get;
            set;
        }

        /// <summary>
        /// List of the TeamViewer instances by PID.
        /// </summary>
        public Dictionary<int, ITeamViewer> TeamViewers
        {
            get { return teamViewers; }
        }
        protected Dictionary<int, ITeamViewer> teamViewers = new Dictionary<int, ITeamViewer>();

        /// <summary>
        /// To find all processes.
        /// </summary>
        public void findAll()
        {
            teamViewers.Clear();
            foreach(var p in Process.GetProcessesByName(ProcessName))
            {
                ITeamViewer tv = new TeamViewer(p);
                BeforeAdd(this, new TeamViewerEventArgs(tv));
                teamViewers[p.Id] = tv;
            }

            Updated(this, new EventArgs());
        }

        /// <summary>
        /// Monitoring of processes.
        /// </summary>
        /// <param name="enable"></param>
        public void monitoring(bool enable)
        {
            lock(_lock)
            {
                if(enable && isMonitoringActive) {
                    log.debug("The monitoring of processes is already started.");
                    return;
                }
                log.info($"Monitoring of processes: {(enable ? "start" : "stop")}. Interval: {MonitoringInterval}");

                isMonitoringActive = enable;
                if(!enable) {
                    return;
                }
                monitoring();
            }
        }

        /// <param name="pname">Optional custom process name for searching of the TeamViewer.</param>
        public TeamViewerCollection(string pname = null)
        {
            ProcessName         = String.IsNullOrWhiteSpace(pname) ? DEFAULT_PROCNAME : pname;
            MonitoringInterval  = 3400;
        }

        protected void monitoring()
        {
            Task.Factory.StartNew(() =>
            {
                while(isMonitoringActive) {
                    removeProcess();
                    findProcess();
                    Thread.Sleep(Math.Max(250, MonitoringInterval));
                }
            });
        }

        /// <summary>
        /// To find each process.
        /// </summary>
        protected virtual void findProcess()
        {
            bool isAdded = false;
            foreach(var p in Process.GetProcessesByName(ProcessName))
            {
                if(teamViewers.ContainsKey(p.Id)) {
                    updateProcess(teamViewers[p.Id], p);
                    continue;
                }
                ITeamViewer tv = new TeamViewer(p);

                BeforeAdd(this, new TeamViewerEventArgs(tv));
                teamViewers[p.Id] = tv;
                isAdded = true;

                log.info($"Found process: {p.Id} : {tv.CommandLine}");
            }

            if(isAdded) {
                Updated(this, new EventArgs());
            }
        }

        /// <summary>
        /// To remove each obsolete process.
        /// </summary>
        protected virtual void removeProcess()
        {
            bool isRemoved = false;
            foreach(var tvs in teamViewers.ToArray()) //collection may be changed, use ToArray()
            {
                int pid = tvs.Key;

                if(!processExists(pid)) {
                    teamViewers.Remove(pid);
                    isRemoved = true;
                    log.info($"Process: {pid} has been removed.");
                }
            }

            if(isRemoved) {
                Updated(this, new EventArgs());
            }
        }

        private bool processExists(int pid)
        {
            return Process.GetProcesses().Any(p => p.Id == pid);
        }

        private void updateProcess(ITeamViewer tv, Process p)
        {
            if(tv.MainHandle != p.MainWindowHandle) {
                tv.updateProcess(p);
            }
        }
    }
}

/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;

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

        /// <summary>
        /// The process name for searching of the TeamViewer for this collection.
        /// </summary>
        public string ProcessName
        {
            get;
            protected set;
        }

        /// <summary>
        /// List of the TeamViewer instances.
        /// </summary>
        public List<ITeamViewer> TeamViewers
        {
            get { return teamViewers; }
        }
        protected List<ITeamViewer> teamViewers = new List<ITeamViewer>();

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
                teamViewers.Add(tv);
            }

            Updated(this, new EventArgs());
        }

        /// <param name="pname">Optional custom process name for searching of the TeamViewer.</param>
        public TeamViewerCollection(string pname = null)
        {
            ProcessName = String.IsNullOrWhiteSpace(pname) ? DEFAULT_PROCNAME : pname;
        }

    }
}

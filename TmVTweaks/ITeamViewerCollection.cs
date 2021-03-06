﻿/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;
using System.Collections.Generic;

namespace net.r_eg.TmVTweaks
{
    public interface ITeamViewerCollection
    {
        /// <summary>
        /// Before adding TeamViewer to collection.
        /// </summary>
        event EventHandler<TeamViewerEventArgs> BeforeAdd;

        /// <summary>
        /// When collection finally updated.
        /// </summary>
        event EventHandler<EventArgs> Updated;

        /// <summary>
        /// List of the TeamViewer instances by PID.
        /// </summary>
        Dictionary<int, ITeamViewer> TeamViewers { get; }

        /// <summary>
        /// The process name for searching of the TeamViewer for this collection.
        /// </summary>
        string ProcessName { get; }

        /// <summary>
        /// Interval of monitoring of processes.
        /// </summary>
        int MonitoringInterval { get; set; }

        /// <summary>
        /// To find all processes.
        /// </summary>
        void findAll();

        /// <summary>
        /// Monitoring of processes.
        /// </summary>
        /// <param name="enable"></param>
        void monitoring(bool enable);
    }
}

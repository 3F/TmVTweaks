/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;

namespace net.r_eg.TmVTweaks
{
    public class TeamViewerEventArgs: EventArgs
    {
        public ITeamViewer TeamViewer
        {
            get;
            protected set;
        }

        public TeamViewerEventArgs(ITeamViewer tv)
        {
            TeamViewer = tv;
        }
    }
}

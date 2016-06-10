/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;

namespace net.r_eg.TmVTweaks
{
    internal interface IUsualLog
    {
        /// <summary>
        /// When the message has been received.
        /// </summary>
        event EventHandler<MessageEventArgs> Received;

        /// <summary>
        /// Flag of Diagnostic mode
        /// </summary>
        bool IsDiagnostic { get; set; }

        /// <summary>
        /// Message for information level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void info(string message, params object[] args);

        /// <summary>
        /// Message for debug level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void debug(string message, params object[] args);
    }
}

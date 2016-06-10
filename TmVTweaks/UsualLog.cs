/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;
using System.Diagnostics;
using System.Globalization;

namespace net.r_eg.TmVTweaks
{
    /// <summary>
    /// Here would be powerful logger like NLog etc., but...
    /// </summary>
    internal class UsualLog: IUsualLog
    {
        /// <summary>
        /// When the message has been received.
        /// </summary>
        public event EventHandler<MessageEventArgs> Received = delegate(object sender, MessageEventArgs e) { };

        /// <summary>
        /// Flag of Diagnostic mode
        /// </summary>
        public bool IsDiagnostic
        {
            get;
            set;
        }

        /// <summary>
        /// Writes message for information level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void info(string message, params object[] args)
        {
            write(message, null);
        }

        /// <summary>
        /// Writes message for debug level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void debug(string message, params object[] args)
        {
            if(IsDiagnostic) {
                info(message, args);
            }
        }

        /// <summary>
        /// Thread-safe getting the instance of UsualLog class
        /// </summary>
        public static IUsualLog _
        {
            get { return _lazy.Value; }
        }
        private static readonly Lazy<IUsualLog> _lazy = new Lazy<IUsualLog>(() => new UsualLog());

        protected UsualLog(bool diag = true)
        {
            IsDiagnostic = diag;
        }

        protected void write(string msg, string level)
        {
            msg = format(msg, level);
            //Debug.WriteLine(msg);
            Console.WriteLine(msg);

            Received(this, new MessageEventArgs(msg, level));
        }

        /// <summary>
        /// Used format.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        /// <returns>formatted</returns>
        protected virtual string format(string message, string level)
        {
            string stamp = DateTime.Now.ToString("H:mm:ss.fff");
            return $"{stamp}: {message}";
        }
    }
}

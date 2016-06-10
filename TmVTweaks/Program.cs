/*
 * Copyright (c) 2016  Denis Kuzmin (reg) <entry.reg@gmail.com>
 * 
 * Distributed under the MIT license
 * (see accompanying file LICENSE or a copy at https://opensource.org/licenses/MIT)
*/

using System;
using System.Threading;
using System.Windows.Forms;

namespace net.r_eg.TmVTweaks
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic);
            Application.ThreadException += onThreadException;

            try {
                Application.Run(new UI.TrayForm());
            }
            catch(Exception ex) {
                mfail(ex, false);
            }
        }

        private static void mfail(Exception ex, bool threadEx)
        {
            string msg = $"{ex.Message}{(threadEx ? "[TH]" : "[M]")}\n---\n{ex.ToString()}";

            Console.WriteLine(msg);
            MessageBox.Show(msg, "Something went wrong -_-", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void onThreadException(object sender, ThreadExceptionEventArgs e)
        {
            mfail(e.Exception, true);
        }
    }
}

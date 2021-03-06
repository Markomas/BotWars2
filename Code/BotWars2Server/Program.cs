﻿using BotWars2Server.Code.Communication;
using BotWars2Server.Code.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotWars2Server
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

            var commander = new Commander();
            var listener = new HttpListenerClass(5999, commander);
            Application.Run(new MainForm(commander));
        }
    }
}

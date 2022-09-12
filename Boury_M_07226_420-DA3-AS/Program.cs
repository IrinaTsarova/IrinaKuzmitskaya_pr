﻿/*
 * (c) Copyright 2022 Marc-Eric Boury
 */

using IrinaKuzmitskaya_pr.Utils;
using IrinaKuzmitskaya_pr.Views;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boury_M_07226_420_DA3_AS {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new IrinaKuzmitskaya_pr.Views.MainWindow());
        }
    }
}

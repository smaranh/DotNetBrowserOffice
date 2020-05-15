﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using DotNetBrowser.Engine;
using DotNetBrowser.Browser;
using System.Threading.Tasks;
using CoreLib;

namespace dotnetbrowserExcelAddin
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Core.isExcelAlive = true;
            Core.InititateEngine();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            Core.isExcelAlive = false;
            Core.DisposeEngine();
        }

        

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
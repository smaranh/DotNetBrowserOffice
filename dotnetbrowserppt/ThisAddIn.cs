using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using DotNetBrowser.Engine;
using CoreLib;

namespace dotnetbrowserppt
{
    public partial class ThisAddIn
    {
        
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Core.isPptAlive = true;
            Core.InititateEngine();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            Core.isPptAlive = false;
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

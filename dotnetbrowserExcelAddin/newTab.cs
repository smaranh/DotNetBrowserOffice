using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace dotnetbrowserExcelAddin
{
    public partial class newTab
    {
        private void newTab_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void newBtn_Click(object sender, RibbonControlEventArgs e)
        {
            var cont = new Container();
            cont.Show();
        }
    }
}

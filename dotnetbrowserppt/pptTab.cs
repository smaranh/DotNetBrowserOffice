﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace dotnetbrowserppt
{
    public partial class pptTab
    {
        private void pptTab_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            var cont = new pptContainer();
            cont.Show();
        }
    }
}

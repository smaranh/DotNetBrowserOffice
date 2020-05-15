using DotNetBrowser.Browser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreLib;

namespace dotnetbrowserppt
{
    public partial class pptContainer : Form
    {
        private IBrowser browser;
        public pptContainer()
        {
            Task.Run(() =>
                Core.engine?.CreateBrowser()
            ).ContinueWith(t =>
            {
                browser = t.Result;
                browserView1.InitializeFrom(browser);
                browser.Navigation.LoadUrl("https://developers.arcgis.com");
            }, TaskScheduler.FromCurrentSynchronizationContext());
            InitializeComponent();
        }

        private void pptContainer_FormClosing(object sender, FormClosingEventArgs e)
        {
            browser?.Dispose();
        }
    }
}

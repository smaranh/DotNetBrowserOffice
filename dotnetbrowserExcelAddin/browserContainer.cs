using DotNetBrowser.Browser;
using DotNetBrowser.Browser.Dialogs.Handlers;
using DotNetBrowser.Engine;
using DotNetBrowser.Handlers;
using DotNetBrowser.Net.Certificates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using DotNetBrowser.Net.Handlers;

namespace dotnetbrowserExcelAddin
{
    public partial class browserContainer : Form
    {
        private IEngine engine;
        private IBrowser browser;
        public browserContainer()
        {
            Task.Run(() =>
            {
                engine = EngineFactory.Create(new EngineOptions.Builder
                {
                    RenderingMode = RenderingMode.HardwareAccelerated
                }
                .Build());
                browser = engine.CreateBrowser();
            })
            .ContinueWith(t =>
            {
                browserView1.InitializeFrom(browser);
                //engine.Network.VerifyCertificateHandler =
                //new Handler<VerifyCertificateParameters, VerifyCertificateResponse>(VerifyCert);
                //handlePKI(browser);
                //browser.Navigation.LoadUrl("https://developers.arcgis.com/javascript/latest/sample-code/");
                //browser.Navigation.LoadUrl("https://nustar.esri.com/portal/");
                browser.Navigation.LoadUrl("https://material.angular.io/cdk/drag-drop/examples");
            }, TaskScheduler.FromCurrentSynchronizationContext());
            InitializeComponent();
        }

        //private static VerifyCertificateResponse VerifyCert(VerifyCertificateParameters parameters)
        //{
        //    // Reject SSL certificate for all "google.com" hosts.
        //    //if (parameters.HostName.Contains("google.com"))
        //    //{
        //    //    Console.WriteLine("Rejected certificate for " + parameters.HostName);
        //    //    return VerifyCertificateResponse.Invalid();
        //    //}

        //    return VerifyCertificateResponse.Default();
        //}

        //void handlePKI(IBrowser browser)
        //{
        //    browser.SelectCertificateHandler =
        //        new Handler<SelectCertificateParameters, SelectCertificateResponse>(p =>
        //        {
        //            // The dialog title.
        //            string title = p.Title;
        //            // The dialog message.
        //            string message = p.Message;
        //            // Available SSL certificates.
        //            IEnumerable<Certificate> certificates = p.Certificates;
        //            //...
        //            // The last certificate in the list has been selected.
        //            //X509Certificate2Collection selectedCertificateCollection = X509Certificate2UI.SelectFromCollection(certificates, title, message, X509SelectionFlag.SingleSelection);
        //            return SelectCertificateResponse.Select(p.Certificates.Count() - 3);
        //        });
        //}

        private void browserContainer_FormClosing(object sender, FormClosingEventArgs e)
        {
            browser?.Dispose();
            //engine?.Dispose();
        }
    }
}

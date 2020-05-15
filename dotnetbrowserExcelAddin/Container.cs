using DotNetBrowser.Browser;
using DotNetBrowser.Browser.Dialogs.Handlers;
using DotNetBrowser.Handlers;
using DotNetBrowser.Net.Certificates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using DotNetBrowser.Net.Handlers;
using CoreLib;

namespace dotnetbrowserExcelAddin
{
    public partial class Container : Form
    {
        private IBrowser browser;
        public Container()
        {
            Task.Run(() =>
                Core.engine?.CreateBrowser()
            ).ContinueWith(t =>
            {
                browser = t.Result;
                browserView1.InitializeFrom(browser);
                handlePKI(browser);
                browser.Navigation.LoadUrl("https://developers.arcgis.com/javascript/latest/sample-code/");
            }, TaskScheduler.FromCurrentSynchronizationContext());
            InitializeComponent();

        }

        private void Container_FormClosing(object sender, FormClosingEventArgs e)
        {
            browser?.Dispose();
        }

        void handlePKI(IBrowser browser)
        {
            browser.SelectCertificateHandler =
                new Handler<SelectCertificateParameters, SelectCertificateResponse>(parameters =>
                {
                    // The dialog title.
                    string title = parameters.Title;
                    // The dialog message.
                    string message = parameters.Message;
                    // Available SSL certificates.
                    IEnumerable<Certificate> certificates = parameters.Certificates;

                    List<X509Certificate2> x509Certs = new List<X509Certificate2>();
                    Dictionary<X509Certificate2, int> mapping = new Dictionary<X509Certificate2, int>();

                    int index = 0;
                    foreach (Certificate cert in certificates)
                    {
                        X509Certificate2 x509Certificate2 = cert.X509Certificate2;
                        x509Certs.Add(x509Certificate2);
                        mapping[x509Certificate2] = index;
                        index++;
                    }

                    X509Certificate2Collection x509collection = new X509Certificate2Collection(x509Certs.ToArray());
                    X509Certificate2Collection selectedCertificateCollection =
                        X509Certificate2UI.SelectFromCollection(x509collection, title, message,
                                                                X509SelectionFlag.SingleSelection);
                    if (selectedCertificateCollection.Count < 1)
                    {
                        return SelectCertificateResponse.Cancel();
                    }

                    X509Certificate2 x509 = selectedCertificateCollection[0];

                    return SelectCertificateResponse.Select(mapping[x509]);
                    //return SelectCertificateResponse.Select(parameters.Certificates.Count() - 3);
                });
        }
    }
}

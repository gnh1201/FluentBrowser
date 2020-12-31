using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace FluentBrowser.Engine.Trident
{
    class Browser
    {
        private WebBrowser browser;
        public string Address { get; set; }
        public string UserAgent { get; set; }
        public string CachePath { get; set; }

        public void Initialize(string address)
        {
            if (address.IndexOf(":/") < 0)
            {
                address = "http://" + address;
            }

            browser = new WebBrowser();
            browser.Navigate(new Uri(address));
            browser.Navigated += (sender, e) =>
            {
                Address = browser.Url.AbsoluteUri;
            };
        }

        public WindowsFormsHost getBrowser()
        {
            WindowsFormsHost whost = new WindowsFormsHost();
            whost.Child = browser;
            return whost;
        }
    }
}
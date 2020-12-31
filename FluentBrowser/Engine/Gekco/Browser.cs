using Gecko;
using System.Windows.Forms.Integration;

namespace FluentBrowser.Engine.Gekco
{
    class Browser
    {
        private GeckoWebBrowser browser;
        public string Address { get; set; }
        public string UserAgent { get; set; }
        public string CachePath { get; set; }

        public void Initialize(string address)
        {
            if (!Xpcom.IsInitialized)
            {
                Xpcom.Initialize("Firefox64");
            }

            browser = new GeckoWebBrowser();
            browser.Navigate("google.com");
            browser.LocationChanged += (sender, e) =>
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
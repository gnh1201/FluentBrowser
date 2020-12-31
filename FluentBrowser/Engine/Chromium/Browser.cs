using CefSharp;
using CefSharp.Wpf;
using System.IO;
using System.Reflection;

namespace FluentBrowser.Engine.Chromium
{
    class Browser
    {
        private ChromiumWebBrowser browser;
        public string Address { get; set; }
        public string UserAgent { get; set; }
        public string CachePath { get; set; }

        public Browser()
        {
            CachePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "data/cache/Chromium");
            UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/11.1.2 Safari/605.1.15";
        }

        public void Initialize(string address)
        {
            if (!Cef.IsInitialized)
            {
                CefSettings cfsettings = new CefSettings();
                cfsettings.CachePath = CachePath;
                cfsettings.UserAgent = UserAgent;
                Cef.Initialize(cfsettings);
            }

            browser = new ChromiumWebBrowser(address);
            browser.AddressChanged += (sender, e) =>
            {
                Address = browser.Address;
            };
        }

        public ChromiumWebBrowser getBrowser()
        {
            return browser;
        }
    }
}

using Fluent;
using System.Windows.Controls;
using CefSharp.Wpf;
using Gecko;
using System.Windows.Forms.Integration;
using System.IO;
using System.Reflection;

namespace FluentBrowser
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateChromiumTab();
        }

        private void CreateChromiumTab()
        {
            var browser = new ChromiumWebBrowser("m.naver.com");
            browser.AddressChanged += (sender, e) =>
            {
                URLText.Text = browser.Address;
            };

            var tab = new TabItem();
            tab.Header = "Chromium";
            tab.Content = browser;
            BrowserTab.Items.Add(tab);
            tab.Focus();
        }

        private void CreateGekcoTab()
        {
            Xpcom.Initialize("Firefox64");

            var browser = new GeckoWebBrowser();
            browser.Navigate("m.naver.com");
            browser.LocationChanged += (sender, e) => {
                URLText.Text = browser.Url.AbsoluteUri;
            };

            WindowsFormsHost whost = new WindowsFormsHost();
            whost.Child = browser;

            var tab = new TabItem();
            tab.Header = "Gekco";
            tab.Content = whost;
            BrowserTab.Items.Add(tab);
            tab.Focus();
        }

        private void Button_Click_Chromium(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateChromiumTab();
        }

        private void Button_Click_Gekco(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateGekcoTab();
        }
    }
}

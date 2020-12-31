using Fluent;
using System.Windows.Controls;
using Gecko;
using System.Windows.Forms.Integration;
using System;

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
            var browser = new Engine.Chromium.Browser();
            browser.Initialize("google.com");

            var tab = new TabItem();
            tab.Header = "Chromium";
            tab.Content = browser.getBrowser();
            BrowserTab.Items.Add(tab);
            tab.Focus();
        }

        private void CreateGekcoTab()
        {
            var browser = new Engine.Gekco.Browser();
            browser.Initialize("google.com");

            var tab = new TabItem();
            tab.Header = "Gekco";
            tab.Content = browser.getBrowser();
            BrowserTab.Items.Add(tab);
            tab.Focus();
        }

        private void CreateDefaultTab()
        {
            var browser = new Engine.Trident.Browser();
            browser.Initialize("google.com");

            var tab = new TabItem();
            tab.Header = "WebBrowser";
            tab.Content = browser.getBrowser();
            BrowserTab.Items.Add(tab);
            tab.Focus();
        }

        private void Button_Click_Browser_Chromium(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateChromiumTab();
        }

        private void Button_Click_Browser_Gekco(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateGekcoTab();
        }

        private void Button_Click_Browser_Default(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateDefaultTab();
        }
    }
}

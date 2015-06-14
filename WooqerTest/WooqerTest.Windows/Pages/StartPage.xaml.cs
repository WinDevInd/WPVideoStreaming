using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WooqerTest.Pages;
using WooqerTest.Shared;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace WooqerTest.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StartPage : BasePage
    {
        public StartPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Button pressedButton = sender as Button;
            if (pressedButton != null)
            {
                string action = pressedButton.CommandParameter.ToString();
                Type navigationPageType = null;
                switch (action)
                {
                    case "Media":
                        navigationPageType = typeof(PlayerPage);
                        break;
                    case "Doc":
                        navigationPageType = typeof(DocumentViewerPage);
                        break;
                    case "PDF":
                        navigationPageType = typeof(PDFViewer);
                        break;
                }
                if(navigationPageType!=null)
                {
                    this.Frame.Navigate(navigationPageType);
                }
            }
        }
    }
}

using SharedLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WooqerTest.Shared;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace WooqerTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : BasePage
    {

        private SearchViewModel searchVM;
        public SearchPage()
        {
            searchVM = new SearchViewModel();
            this.DataContext = searchVM;
            searchVM.NavigationAction = Navigate;
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private void Navigate(string pageparams)
        {
            this.Frame.Navigate(typeof(PlayerPage), pageparams);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
        }

        private void Image_Unloaded(object sender, RoutedEventArgs e)
        {
           
        }

        private async void SearchBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter || e.Key == Windows.System.VirtualKey.Search)
            {
                searchVM.SearchText = this.SearchBox.Text.ToString();
                InputPane.GetForCurrentView().TryHide();
                await searchVM.LoadSearchResult();
            }
        }
    }
}

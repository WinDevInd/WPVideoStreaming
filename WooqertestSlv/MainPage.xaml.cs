using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WooqertestSlv.Resources;
using SharedLibrary.ViewModels;
using System.Threading.Tasks;

namespace WooqertestSlv
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        private SearchViewModel searchViewModel;
        public MainPage()
        {
            InitializeComponent();
            searchViewModel = new SearchViewModel();
            this.DataContext = searchViewModel;
        }

        private async void SearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                searchViewModel.SearchText = this.SearchBox.Text.ToString();
                await searchViewModel.LoadSearchResult();
            }
        }
    }
}
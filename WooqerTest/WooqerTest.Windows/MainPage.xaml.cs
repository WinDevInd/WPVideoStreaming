using GoogleApis;
using GoogleApiSearch;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WooqerTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Search s;
        public MainPage()
        {
            this.InitializeComponent();
            s = new Search();
            Get();
        }


        public async void Get()
        {
            
            var data = await s.SearchYoutubeVideo("Microsft");
            foreach(var s1 in data)
            {
                var d = await YoutubeVideoGenerator.GetVideoUriAsync(s1.URL, YoutubeVideoGenerator.YouTubeQuality.QualityMedium);
            }
        }
    }
}

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
    public sealed partial class BlankPage : Page
    {
        //private Search searchApi;
        public BlankPage()
        {
            this.InitializeComponent();
            //searchApi = new Search();
            Get();
        }

        public async void Get()
        {

            //var data = await searchApi.SearchYoutubeVideo("Microsoft");
            //foreach (var videos in data)
            //{
            //    string url = videos.URL + "&key=AIzaSyCUFxMevnFvsA_BwQWnBpALmKdbx2XVwgE";
            //    var d = await YoutubeVideoGenerator.GetVideoUriAsync(url, YoutubeVideoGenerator.YouTubeQuality.Quality480P);
            //    if (d.HasVideo)
            //    {
            //        this.player.Source = d.Uri;
            //        break;
            //    }
            //}
        }
    }
}

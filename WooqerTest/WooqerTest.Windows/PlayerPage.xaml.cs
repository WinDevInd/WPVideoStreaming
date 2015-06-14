using GoogleApiSearch;
using Models;
using Newtonsoft.Json;
using SharedLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class PlayerPage : Page
    {
        private SearchViewModel searchVM;
        public PlayerPage()
        {
            searchVM = new SearchViewModel();
            this.InitializeComponent();
            this.DataContext = searchVM;
            searchVM.NavigationAction = LoadVideo;
            
        }

        private void LoadVideo(string data)
        {
            YoutubeData video =  JsonConvert.DeserializeObject<YoutubeData>(data);
            EmbadeVideoInPlayer(video);
        }

        private async Task EmbadeVideoInPlayer(YoutubeData video)
        {
            
            if (video != null)
            {
                this.player.Stop();
                this.player.Source = null;
                this.player.Source = await Task.Run(async () =>
                {
                    var res = await YoutubeVideoGenerator.GetVideoUriAsync(video.URL, YoutubeVideoGenerator.YouTubeQuality.Quality480P);
                    return res.Uri;
                });
                this.player.Play();

            }
        }
        private async void SearchBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter || e.Key == Windows.System.VirtualKey.Search)
            {
                searchVM.SearchText = this.SearchBox.Text.ToString();
                await searchVM.LoadSearchResult();
            }
        }
    }
}

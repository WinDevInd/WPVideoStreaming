using GoogleApis;
using GoogleApiSearch;
using Models;
using Newtonsoft.Json;
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
using WooqerTest.Shared;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WooqerTest.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayerPage : BasePage
    {
        private Search searchApi;
        public PlayerPage()
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
            if (e.NavigationMode == NavigationMode.New)
            {
                string data = e.Parameter as string;
                YoutubeData video = JsonConvert.DeserializeObject<YoutubeData>(data);
                EmbadeVideoInPlayer(video);

            }
        }

        private async Task EmbadeVideoInPlayer(YoutubeData video)
        {
            if (video != null)
            {
                this.player.Source = await Task.Run(async () =>
                {
                    var res = await YoutubeVideoGenerator.GetVideoUriAsync(video.URL, YoutubeVideoGenerator.YouTubeQuality.Quality480P);
                    return res.Uri;
                });

            }
        }
    }
}

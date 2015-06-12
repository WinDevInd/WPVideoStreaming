using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Utils;

namespace ViewModels
{
    public class YoutubeSearchResultModel
    {
        public YoutubeData Data
        {
            get;
            set;
        }
        public RelayCommand ItemTapped
        {
            get;
            set;
        }
    }

    public class SearchViewModel : BaseViewModel
    {
        private GoogleApis.Search search = null;
        public Action<string> NavigationAction = null;

        public SearchViewModel()
        {
            search = new GoogleApis.Search();
            SearchResults = new ObservableCollection<YoutubeSearchResultModel>();
            ItemTapped = new RelayCommand(ItemTapped_Action);
        }

        private void ItemTapped_Action(object obj)
        {
            YoutubeData data = obj as YoutubeData;
            if (data != null)
            {
                if (NavigationAction != null)
                {
                    NavigationAction(JsonConvert.SerializeObject(data));
                }
            }
        }

        public bool IsLoading
        {
            get;
            set;
        }
        private new RelayCommand ItemTapped
        {
            get;
            set;
        }

        public ObservableCollection<YoutubeSearchResultModel> SearchResults
        {
            get;
            private set;
        }

        private string _SearchText;

        public string SearchText
        {
            get { return _SearchText; }
            set { SetFieldAndNotify(ref _SearchText, value); }
        }

        public async Task LoadSearchResult()
        {
            if (string.IsNullOrWhiteSpace(this.SearchText))
            {
                return;
            }
            IsLoading = true;
            try
            {
                var result = await search.SearchYoutubeVideo(SearchText);
                foreach (var item in result)
                {
                    SearchResults.Add(new YoutubeSearchResultModel()
                    {
                        Data = item,
                        ItemTapped = this.ItemTapped
                    });
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
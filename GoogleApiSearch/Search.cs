
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Models;

namespace GoogleApis
{
    public class Search
    {
        public async Task<List<YoutubeData>> SearchYoutubeVideo(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return null;
            }

            List<YoutubeData> youtubeVideoList = new List<YoutubeData>();
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCUFxMevnFvsA_BwQWnBpALmKdbx2XVwgE",
                ApplicationName = this.GetType().ToString()
            });

            
            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = search;
            searchListRequest.MaxResults = 10;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        youtubeVideoList.Add(new YoutubeData()
                        {
                            Description = searchResult.Snippet.Description,
                            Title = searchResult.Snippet.Title,
                            Thumbnails = new ThumbnailData()
                            {
                                Default = searchResult.Snippet.Thumbnails.Default.Url,
                                HighRes = searchResult.Snippet.Thumbnails.High.Url,
                                Medium = searchResult.Snippet.Thumbnails.Medium.Url
                            },
                            URL = "" + searchResult.Id.VideoId
                        });
                        break;
                }
            }
            return youtubeVideoList;
        }
    }
}

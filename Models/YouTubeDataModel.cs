using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class YoutubeData
    {
        public string URL { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string ThumbnailSmall { get; set; }
        public ThumbnailData Thumbnails { get; set; }
    }

    public class ThumbnailData
    {
        public string Default { get; set; }
        public string Medium { get; set; }
        public string HighRes { get; set; }
    }
}

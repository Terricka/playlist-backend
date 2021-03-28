using System;
namespace playlist_api
{
    public class Playlist
    {
        public DateTime createdDate { get; set; }

        public DateTime modifiedDate { get; set; }

        public int id { get; set; }

        public string title { get; set; } 

        public string description { get; set; }

        public string genre { get; set; }
    }
}

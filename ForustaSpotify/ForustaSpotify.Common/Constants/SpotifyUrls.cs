using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForustaSpotify.Common.Constants
{
    public static class SpotifyUrls
    {
        /// <summary>
        /// Base Spotify Web API url
        /// </summary>
        public const string baseUrl = "https://api.spotify.com/v1/";

        /// <summary>
        /// Spotify Web API authorization url
        /// </summary>
        public const string AuthUrl = "https://accounts.spotify.com/authorize/";

        /// <summary>
        /// Spotify Web API Account Token Url
        /// </summary>
        public const string AccountApiTokenUrl = "https://accounts.spotify.com/api/token";

        /// <summary>
        /// Get Spotify current user profile data
        /// </summary>
        public const string Profile = baseUrl + "me";

        /// <summary>
        /// Searches artist or track data 
        /// URL template: /search?q={name}&type={artist | track}
        /// </summary>
        public const string Search = baseUrl + "search?q=";

        /// <summary>
        /// Get artist data by its Spotify ID
        /// URL template: /artists/{id}
        /// </summary>
        public const string GetArtist = baseUrl + "artists/";
    }
}

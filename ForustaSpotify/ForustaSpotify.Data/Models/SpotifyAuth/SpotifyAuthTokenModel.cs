using ForustaSpotify.Common.Constants;
using Newtonsoft.Json;

namespace ForustaSpotify.Data.Models.SpotifyAuth
{
    /// <summary>
    /// Model for spotify web api authorization
    /// </summary>
    public class SpotifyAuthTokenModel
    {
        [JsonProperty(SpotifyWebFields.AccessToken)]
        public string AccessToken { get; set; }

        [JsonProperty(SpotifyWebFields.RefreshToken)]
        public string RefreshToken { get; set; }

        [JsonProperty(SpotifyWebFields.TokenType)]
        public string TokenType { get; set; }

        [JsonProperty(SpotifyWebFields.ExpiresIn)]
        public int ExpiresIn { get; set; }

        [JsonProperty(SpotifyWebFields.Scope)]
        public string Scope { get; set; }
    }
}

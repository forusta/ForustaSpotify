using ForustaSpotify.Data.Models.SpotifyResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForustaSpotify.BL.Clients.SpotifyRequest
{
    /// <summary>
    /// Service for requesting Spotify's Data
    /// </summary>
    public interface ISpotifyRequestClient
    {
        /// <summary>
        /// Retrieve data from Spotify Web API
        /// </summary>
        /// <param name="accessToken">Autorization Token to access Spotify Web API</param>
        /// <param name="url">Spotify Web API url. HTTP GET</param>
        /// <returns></returns>
        Task<TResponse> GetData<TResponse>(string url)
            where TResponse : class, ISpotifyResponseModel;
    }
}

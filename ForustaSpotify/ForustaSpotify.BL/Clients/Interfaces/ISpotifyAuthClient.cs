using ForustaSpotify.Data.Models.SpotifyAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForustaSpotify.BL.Clients.Interfaces
{
    /// <summary>
    /// Spotify authorization service. 
    /// </summary>
    public interface ISpotifyAuthClient
    {
        /// <summary>
        /// Builds spotify authorization query string
        /// </summary>
        /// <returns></returns>
        string BuildAuthQuery(string redirectUrl);

        /// <summary>
        /// Authorize Spotify
        /// </summary>
        /// <param name="inputCode"></param>
        /// <returns>Return token model</returns>
        Task<SpotifyAuthTokenModel> Auth(string inputCode, string returnUrl);
    }
}

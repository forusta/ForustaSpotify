using ForustaSpotify.Data.Models.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForustaSpotify.BL.Services.Interfaces
{
    /// <summary>
    /// Artist data read service
    /// </summary>
    public interface IArtistReadService
    {
        /// <summary>
        /// Retrieves artist data by its ID
        /// </summary>
        /// <param name="id">Artist ID</param>
        /// <returns></returns>
        Task<ArtistsResponse> GetArtist(string id);

        /// <summary>
        /// Search artists data by filter name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<ICollection<ArtistModel>> SearchArtists(string name);
    }
}

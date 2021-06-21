using ForustaSpotify.BL.Clients.SpotifyRequest;
using ForustaSpotify.BL.Services.Interfaces;
using ForustaSpotify.Common.Constants;
using ForustaSpotify.Data.Models.Artist;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForustaSpotify.BL.Services
{
    public class ArtistReadService : IArtistReadService
    {
        private readonly ISpotifyRequestClient _spotifyRequestClient;

        public ArtistReadService(ISpotifyRequestClient spotifyRequestClient)
        {
            _spotifyRequestClient = spotifyRequestClient;
        }

        public async Task<ICollection<ArtistModel>> SearchArtists(string name)
        {
            var paramsUrl = $"{SpotifyUrls.Search}{name}&type=artist";

            var responseData = await _spotifyRequestClient.GetData<ArtistsResponse>(paramsUrl);

            return responseData.Artists?.Items;
        }

        public async Task<ArtistsResponse> GetArtist(string id)
        {
            var paramsUrl = $"{SpotifyUrls.GetArtist}/{id}";

            var responseData = await _spotifyRequestClient
                .GetData<ArtistsResponse>(paramsUrl);

            return responseData;
        }
    }
}

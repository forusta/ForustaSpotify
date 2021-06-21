using ForustaSpotify.Data.Models.SpotifyResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForustaSpotify.Data.Models.Artist
{
    public class ArtistsResponse : ISpotifyResponseModel 
    {
        public Artists Artists { get; set; }
    }

    public class Artists
    {
        public ICollection<ArtistModel> Items { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForustaSpotify.Data.Models.Artist
{
    public class ArtistModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<string> Genres { get; set; }
    }
}

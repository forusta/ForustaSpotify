using ForustaSpotify.BL.Repositories.Interfaces;
using ForustaSpotify.Data.Configuration;

namespace ForustaSpotify.BL.Repositories
{
    public class Repository : BaseRepository<ForustaSpotifyDbContext>, IRepository
    {
        public Repository(ForustaSpotifyDbContext context) :
            base(context)
        {
        }
    }
}

using ForustaSpotify.Data.Configuration;
using ForustaSpotify.DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForustaSpotify.DataAccess.Repositories
{
    public class Repository : BaseRepository<ForustaSpotifyDbContext>, IRepository
    {
        public Repository(ForustaSpotifyDbContext context) : 
            base(context)
        {
        }
    }
}

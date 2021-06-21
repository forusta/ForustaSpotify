using ForustaSpotify.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForustaSpotify.Data.Configuration
{
    public class ForustaSpotifyDbContext : DbContext
    {
        public DbSet<ApplicationConfig> ApplicationConfigs { get; set; }


        public ForustaSpotifyDbContext(DbContextOptions options) :
            base(options)
        {
        }
    }
}

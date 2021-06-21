using ForustaSpotify.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForustaSpotify.Data.Entities
{
    public class ApplicationConfig : BaseEntity<int>
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}

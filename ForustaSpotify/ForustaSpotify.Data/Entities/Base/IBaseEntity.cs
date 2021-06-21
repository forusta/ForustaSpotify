using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForustaSpotify.Data.Entities.Base
{
    public interface IBaseEntity
    {
        object Id { get; set; }
        DateTime CreatedDate { get; set; }
    }

    public interface IBaseEntity<T> : IBaseEntity
    {
        new T Id { get; set; }
    }
}

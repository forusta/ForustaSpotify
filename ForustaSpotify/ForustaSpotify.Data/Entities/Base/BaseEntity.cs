using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForustaSpotify.Data.Entities.Base
{
    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        object IBaseEntity.Id
        {
            get { return Id; }
            set => Id = (T)value;
        }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
    }
}

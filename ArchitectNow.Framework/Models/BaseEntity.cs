using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectNow.Framework.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }

        public DateTime LastEdited { get; set; }


    }
}

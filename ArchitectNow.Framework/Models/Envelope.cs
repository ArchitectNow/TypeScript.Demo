using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectNow.Framework.Models
{
    public class Envelope<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Content { get; set; }
    }
}

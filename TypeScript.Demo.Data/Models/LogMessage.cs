using ArchitectNow.Framework.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScript.Demo.Data.Models
{
    [JsonObject]
    public class LogMessage : BaseEntity 
    {
        public DateTime LogDate { get; set; }
        public string Message { get; set; }
    }
}

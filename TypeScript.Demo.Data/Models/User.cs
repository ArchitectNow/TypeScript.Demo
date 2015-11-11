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
    public class User : BaseEntity 
    {
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public string GetDisplayName()
        {
            return Email.ToString();
        }
    }
}

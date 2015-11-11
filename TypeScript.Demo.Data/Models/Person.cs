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
    public class Person : BaseEntity 
    {
        public string NameFirst { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ChrisName { get; set; }

    }
}

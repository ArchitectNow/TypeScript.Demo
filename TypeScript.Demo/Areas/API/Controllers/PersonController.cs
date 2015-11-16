using ArchitectNow.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TypeScript.Demo.Data.Models;
using TypeScript.Demo.Data.Repositories;

namespace TypeScript.Demo.Areas.API.Controllers
{
    [AllowAnonymous]
    public class PersonController : BaseDataController<Person>
    {
        public IPersonRepository PersonRepository { get; set; }

        public PersonController(IPersonRepository PersonRepository) 
        {
            this.PersonRepository = PersonRepository;
            this.Repository = PersonRepository;
        }

        public Envelope<bool> CheckActive(Guid ID)
        {
            return new Envelope<bool>() { Content = true };
        }
    }
}

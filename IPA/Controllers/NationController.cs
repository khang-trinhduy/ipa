using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IPA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NationController : ControllerBase
    {
        private List<Nation> nations { get; set; }
        private IConfiguration configuration { get; set; }
        public NationController(IConfiguration _configuration)
        {
            configuration = _configuration;
            StreamReader r = new StreamReader(configuration["Nation"]);
            string json = r.ReadToEnd();
            nations = JsonConvert.DeserializeObject<List<Nation>>(json);
        }
        // GET: api/Nation
        [HttpGet]
        public IEnumerable<Nation> Get()
        {
            return nations;
        }

        // GET: api/Nation/5
        [HttpGet("{id}", Name = "GetNation")]
        public Nation Get(int id)
        {
            if (id < 0 || id > nations.Count - 1)
            {
                return new Nation();
            }
            return nations[id];
        }

        //// POST: api/Nation
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Nation/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

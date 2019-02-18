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
    public class ReligionController : ControllerBase
    {
        private List<Religion> religions { get; set; }
        private IConfiguration configuration { get; set; }
        public ReligionController(IConfiguration _configuration)
        {
            configuration = _configuration;
            StreamReader r = new StreamReader(configuration["Religion"]);
            string json = r.ReadToEnd();
            religions = JsonConvert.DeserializeObject<List<Religion>>(json);
        }
        // GET: api/Religion
        [HttpGet]
        public IEnumerable<Religion> Get()
        {
            return religions;
        }

        // GET: api/Religion/5
        [HttpGet("{id}", Name = "GetReligion")]
        public Religion Get(int id)
        {
            if (id < 0 || id > religions.Count - 1)
            {
                return new Religion();
            }
            return religions[id];
        }

        //// POST: api/Religion
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Religion/5
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

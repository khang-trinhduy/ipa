using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Api.Models;
using Microsoft.Extensions.Configuration;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private List<Address> addresses { get; set; }
        private IConfiguration configuration { get; set; }
        public AddressController(IConfiguration _configuration)
        {
            configuration = _configuration;
            StreamReader r = new StreamReader(configuration["Address"]);
            string json = r.ReadToEnd();
            addresses = JsonConvert.DeserializeObject<List<Address>>(json);
        }

        // GET: api/Address
        [HttpGet]
        public IEnumerable<string> Get()
        {            
            return new string[] { "value1", "value2" };
        }

        // GET: api/Address/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Address
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Address/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

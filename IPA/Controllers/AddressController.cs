using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using IPA.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace IPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private List<Address> addresses { get; set; }
        private IConfiguration configuration { get; set; }
        public AddressController(IConfiguration _configuration)
        {
            configuration = _configuration;
            StreamReader r = new StreamReader(configuration["Address"]);
            string json = r.ReadToEnd();
            Dictionary<string, List<Town>> contents = JsonConvert.DeserializeObject<Dictionary<string, List<Town>>>(json);
            addresses = new List<Address>();
            foreach (KeyValuePair<string, List<Town>> elem in contents)
            {
                addresses.Add(new Address(elem.Key, elem.Value));
            }
        }

        // GET: api/Address
        [HttpGet]
        public IEnumerable<Address> Get()
        {
            if (addresses != null)
            {
                return addresses;
            }
            return new List<Address>();
        }

        // GET: api/Address/5
        [HttpGet("{Name}")]
        public Address Get(string name)
        {
            string new_name = String.Join(" ", name.Split("_"));
            Address address = addresses.FirstOrDefault(a => a.Name.ToLower() == new_name.ToLower());
            return address != null? address:new Address("", new List<Town>());
        }

        //// POST: api/Address
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Address/5
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

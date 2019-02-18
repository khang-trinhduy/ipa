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
    public class ProvinceController : ControllerBase
    {
        private List<Province> provinces { get; set; }
        private IConfiguration configuration { get; set; }
        public ProvinceController(IConfiguration _configuration)
        {
            configuration = _configuration;
            StreamReader r = new StreamReader(configuration["Province"]);
            string json = r.ReadToEnd();
            provinces = JsonConvert.DeserializeObject<List<Province>>(json);
        }
        // GET: api/Province
        [HttpGet]
        public IEnumerable<Province> Get()
        {
            return provinces;
        }

        // GET: api/Province/5
        [HttpGet("{id}", Name = "GetProvince")]
        public Province Get(int id)
        {
            if (id < 0 || id > provinces.Count - 1)
            {
                return new Province();
            }
            return provinces[id];
        }

        //// POST: api/Province
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Province/5
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

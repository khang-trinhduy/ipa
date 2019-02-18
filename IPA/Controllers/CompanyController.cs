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
    public class CompanyController : ControllerBase
    {
        private List<Company> companies { get; set; }
        private IConfiguration configuration { get; set; }
        public CompanyController(IConfiguration _configuration)
        {
            configuration = _configuration;
            StreamReader r = new StreamReader(configuration["Company"]);
            string json = r.ReadToEnd();
            companies = JsonConvert.DeserializeObject<List<Company>>(json);
        }

        // GET: api/Company
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return companies;
        }

        // GET: api/Company/5
        [HttpGet("{id}", Name = "GetCompany")]
        public Company Get(int id)
        {
            if (id < 0 || id > companies.Count - 1)
            {
                return new Company();
            }
            return companies[id];
        }

        //// POST: api/Company
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Company/5
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

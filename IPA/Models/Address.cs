using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPA.Models
{
    public class Address
    {
        public Address()
        {
            this.Towns = new List<Town>();
        }

        public Address(string key, List<Town> value)
        {
            this.Name = key;
            this.Towns = value;
        }

        public string Name { get; set; }
        public List<Town> Towns { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class Grant
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ResoueceId { get; set; }
        public string Permission { get; set; }
        public string Operation { get; set; }
    }
}

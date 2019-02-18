using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PermissionApi.Models
{
    public class PermissionApiContext : DbContext
    {
        public PermissionApiContext (DbContextOptions<PermissionApiContext> options)
            : base(options)
        {
        }

        public DbSet<Grant> Grants { get; set; }
    }
}

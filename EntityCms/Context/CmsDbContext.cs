using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCms.Context
{
    public class CmsDbContext : DbContext
    {
        public DbSet<User> ObjRegisterUser { get; set; }
    }
}

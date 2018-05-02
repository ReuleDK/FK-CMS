using System.Data.Entity;

namespace EntityCms.Context
{
    public class CmsDbContext : DbContext
    {
        public CmsDbContext()
        {
            Database.SetInitializer(new CmsDbInitializer());
        }

        public DbSet<User> ObjRegisterUser { get; set; }
        public DbSet<Role> ObjRoles { get; set; }
    }
}

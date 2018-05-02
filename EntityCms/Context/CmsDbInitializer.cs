using System;
using System.Collections.Generic;
using System.Data.Entity;
using EntityCms.Context;

namespace EntityCms
{
    public class CmsDbInitializer : DropCreateDatabaseAlways<CmsDbContext>
    {
        protected override void Seed(CmsDbContext context)
        {
            IList<Role> defaultRoles = new List<Role>();

            defaultRoles.Add(new Role() {  RoleName = "Admin" });
            defaultRoles.Add(new Role() { RoleName = "User" });

            context.ObjRoles.AddRange(defaultRoles);

            base.Seed(context);
        }
    }
}

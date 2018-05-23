using System;
using System.Linq;
using EntityCms.Context;

namespace EntityCms {
    public static class AuthHelper {
		public static bool CheckUser(string emailId, int[] roles) {
			using (var context = new CmsDbContext()) {
				try {
                    var user = context.ObjUsers.Where(x => x.EmailId == emailId).SingleOrDefault();
					if(user != null) {
						int userId = user.UserId;
						//check if user has one of the given rights
						// source: https://stackoverflow.com/questions/30466696/query-a-many-to-many-relationship-with-linq-entity-framework-codefirst/30467114
						var checkRole = context.ObjRoles.Where(x => roles.Contains(x.RoleId)).SelectMany(x => x.Users);
						return true;
					} else { return false; }
				} catch (Exception e) {
					throw e;
                }
			}
		}      
    }
}
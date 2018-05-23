using System;
using System.Linq;
using EntityCms.Context;

namespace EntityCms {
    public static class AuthHelper {
		public static bool CheckUser(string emailId, int[] roles) {
			using (var context = new CmsDbContext()) {
				try {
                    var userFromDB = context.ObjUsers.Where(x => x.EmailId == emailId).SingleOrDefault();
					if(userFromDB != null) {
						int userId = userFromDB.UserId;

						//check if user has one of the given rights
                        // source: https://stackoverflow.com/questions/10505595/linq-many-to-many-relationship-how-to-write-a-correct-where-clause
                        var checkRole = context.ObjUsers.Where(user => user.Roles.All(x => roles.Contains(x.RoleId))).Where(y => y.UserId == userId).SingleOrDefault();
                        if(checkRole != null) return true;
                        return false;
					} else { return false; }
				} catch (Exception e) {
					throw e;
                }
			}
		}      
    }
}
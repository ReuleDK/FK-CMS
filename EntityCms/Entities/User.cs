using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityCms {
    public class User {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string VCode { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
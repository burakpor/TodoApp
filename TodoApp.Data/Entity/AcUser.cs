using System;
using System.Collections.Generic;

#nullable disable

namespace TodoApp.Entity
{
    public partial class AcUser
    {
        public AcUser()
        {
            AcTasks = new HashSet<AcTask>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<AcTask> AcTasks { get; set; }
    }
}

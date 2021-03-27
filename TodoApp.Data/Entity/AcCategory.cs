using System;
using System.Collections.Generic;

#nullable disable

namespace TodoApp.Entity
{
    public partial class AcCategory
    {
        public AcCategory()
        {
            AcTasks = new HashSet<AcTask>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<AcTask> AcTasks { get; set; }
    }
}

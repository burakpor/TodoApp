using System;
using System.Collections.Generic;

#nullable disable

namespace TodoApp.Entity
{
    public partial class AcTaskActivity
    {
        public int TaskActivityId { get; set; }
        public int? TaskId { get; set; }
        public string Activity { get; set; }
        public DateTime? ActivityDate { get; set; }

        public virtual AcTask Task { get; set; }
    }
}

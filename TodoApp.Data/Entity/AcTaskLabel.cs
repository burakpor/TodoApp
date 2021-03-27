using System;
using System.Collections.Generic;

#nullable disable

namespace TodoApp.Entity
{
    public partial class AcTaskLabel
    {
        public int TaskLabelId { get; set; }
        public int? TaskId { get; set; }
        public string Label { get; set; }

        public virtual AcTask Task { get; set; }
    }
}

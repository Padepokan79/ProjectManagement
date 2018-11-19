namespace ProjectManagement.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectTimeline")]
    public partial class ProjectTimeline
    {
        [Key]
        public int TimelineId { get; set; }

        public int? ProjectScheduleId { get; set; }

        public int? ProjectId { get; set; }

        public int? ModulId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual Modul Modul { get; set; }

        public virtual Project Project { get; set; }

        public virtual ProjectSchedule ProjectSchedule { get; set; }
    }
}

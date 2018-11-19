namespace ProjectManagement.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectSchedule")]
    public partial class ProjectSchedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectSchedule()
        {
            ProjectTimelines = new HashSet<ProjectTimeline>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectScheduleId { get; set; }

        public int? ProjectId { get; set; }

        [StringLength(50)]
        public string Version { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual Project Project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectTimeline> ProjectTimelines { get; set; }
    }
}

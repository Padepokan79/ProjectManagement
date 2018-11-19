namespace ProjectManagement.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project")]
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            Moduls = new HashSet<Modul>();
            ProjectDocuments = new HashSet<ProjectDocument>();
            ProjectSchedules = new HashSet<ProjectSchedule>();
            ProjectTimelines = new HashSet<ProjectTimeline>();
            Requirements = new HashSet<Requirement>();
        }

        public int ProjectId { get; set; }

        public int? ClientId { get; set; }

        public int? ProjectStatusId { get; set; }

        [StringLength(50)]
        public string ProjectName { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string PIC { get; set; }

        public DateTime? StartDatePlan { get; set; }

        public DateTime? EndDatePlan { get; set; }

        public DateTime? StartDateActual { get; set; }

        public DateTime? EndDateActual { get; set; }

        public decimal? MandaysEstimation { get; set; }

        public decimal? MandaysEstimationCal { get; set; }

        [StringLength(50)]
        public string CreationBy { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Modul> Moduls { get; set; }

        public virtual ProjectStatu ProjectStatu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectDocument> ProjectDocuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectSchedule> ProjectSchedules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectTimeline> ProjectTimelines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}

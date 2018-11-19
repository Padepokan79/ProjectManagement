namespace ProjectManagement.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Requirement")]
    public partial class Requirement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Requirement()
        {
            ChangeRequests = new HashSet<ChangeRequest>();
            RequirementDocuments = new HashSet<RequirementDocument>();
            Requirement1 = new HashSet<Requirement>();
            RequirementHistories = new HashSet<RequirementHistory>();
        }

        [Key]
        public int RequimentId { get; set; }

        public int? ParentRequimentId { get; set; }

        public int? ProjectId { get; set; }

        public int? ModulId { get; set; }

        public int? RequimentTypeId { get; set; }

        [StringLength(50)]
        public string RequirementNumber { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public int? Level { get; set; }

        [StringLength(50)]
        public string CreationBy { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChangeRequest> ChangeRequests { get; set; }

        public virtual Modul Modul { get; set; }

        public virtual Project Project { get; set; }

        public virtual RequimentType RequimentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequirementDocument> RequirementDocuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Requirement> Requirement1 { get; set; }

        public virtual Requirement Requirement2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequirementHistory> RequirementHistories { get; set; }
    }
}

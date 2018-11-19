namespace ProjectManagement.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChangeRequest")]
    public partial class ChangeRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChangeRequest()
        {
            ChangeRequestDocuments = new HashSet<ChangeRequestDocument>();
            RequirementHistories = new HashSet<RequirementHistory>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChangeRequestId { get; set; }

        public int? RequimentId { get; set; }

        [StringLength(50)]
        public string ChangeRequestNumber { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public DateTime? ChangeRequestDate { get; set; }

        public decimal? MandaysEstimation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChangeRequestDocument> ChangeRequestDocuments { get; set; }

        public virtual Requirement Requirement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequirementHistory> RequirementHistories { get; set; }
    }
}

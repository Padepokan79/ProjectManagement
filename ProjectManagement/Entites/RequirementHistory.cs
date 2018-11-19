namespace ProjectManagement.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequirementHistory")]
    public partial class RequirementHistory
    {
        [Key]
        public int HistoryId { get; set; }

        public int RequimentId { get; set; }

        public int? ChangeRequestId { get; set; }

        public int? ParentRequimentId { get; set; }

        public int? ProjectId { get; set; }

        public int? ModulId { get; set; }

        [StringLength(50)]
        public string RequirementNumber { get; set; }

        public string Description { get; set; }

        public int? Level { get; set; }

        [StringLength(50)]
        public string CreationBy { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual ChangeRequest ChangeRequest { get; set; }

        public virtual Requirement Requirement { get; set; }
    }
}

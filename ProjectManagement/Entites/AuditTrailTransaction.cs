namespace ProjectManagement.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AuditTrailTransaction")]
    public partial class AuditTrailTransaction
    {
        [Key]
        public int AuditTrailId { get; set; }

        [StringLength(50)]
        public string TableName { get; set; }

        [StringLength(50)]
        public string Action { get; set; }

        public string Details { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        public DateTime? AuditDate { get; set; }
    }
}

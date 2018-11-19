namespace ProjectManagement.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectDocumentType")]
    public partial class ProjectDocumentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DocumentTypeId { get; set; }

        public virtual DocumentType DocumentType { get; set; }
    }
}

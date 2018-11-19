namespace ProjectManagement.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DocumentType")]
    public partial class DocumentType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocumentType()
        {
            ChangeRequestDocuments = new HashSet<ChangeRequestDocument>();
            ModulDocuments = new HashSet<ModulDocument>();
            ProjectDocuments = new HashSet<ProjectDocument>();
            RequirementDocuments = new HashSet<RequirementDocument>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DocumentTypeId { get; set; }

        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChangeRequestDocument> ChangeRequestDocuments { get; set; }

        public virtual ChangeRequestDocumentType ChangeRequestDocumentType { get; set; }

        public virtual ModulDocumentType ModulDocumentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModulDocument> ModulDocuments { get; set; }

        public virtual ProjectDocumentType ProjectDocumentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectDocument> ProjectDocuments { get; set; }

        public virtual RequirementDocumentType RequirementDocumentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequirementDocument> RequirementDocuments { get; set; }
    }
}

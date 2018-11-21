using ProjectManagement.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class ProjectDocumentViewModel
    {
        [Key]
        public int DocumentId { get; set; }

        public int? ProjectId { get; set; }

        public int? DocumentTypeId { get; set; }

        [StringLength(50)]
        public string DocumentName { get; set; }

        public string FilePath { get; set; }

        [StringLength(50)]
        public string Version { get; set; }

        public virtual DocumentType DocumentType { get; set; }

        public virtual Project Project { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class RequirementViewModel
    {
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
    }
}
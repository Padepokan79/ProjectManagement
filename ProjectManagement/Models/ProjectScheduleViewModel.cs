using ProjectManagement.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class ProjectScheduleViewModel
    {
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
    }
}
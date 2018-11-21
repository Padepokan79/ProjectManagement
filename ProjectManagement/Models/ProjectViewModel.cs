using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class ProjectViewModel
    {
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
    }
}
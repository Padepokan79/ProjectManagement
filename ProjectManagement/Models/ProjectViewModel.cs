using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagement.Entites;

namespace ProjectManagement.Models
{
    public class ProjectViewModel
    {
        /*
        public ProjectViewModel() { }
        public ProjectViewModel(Project project) {
            ProjectId = project.ProjectId;
            ClientId = project.ClientId;
            ProjectStatusId = project.ProjectStatusId;
            ProjectName = project.ProjectName;
            Description = project.Description;
            PIC = project.PIC;
            StartDatePlan = project.StartDatePlan;
            StartDateActual = project.StartDateActual;
            EndDatePlan = project.EndDatePlan;
            EndDateActual = project.EndDateActual;
            MandaysEstimation = project.MandaysEstimation;
            MandaysEstimationCal = project.MandaysEstimationCal;
            CreationBy = project.CreationBy;
            CreationDate = project.CreationDate;
            ModifiedBy = project.ModifiedBy;
            ModifiedDate = project.ModifiedDate;
        }
        */



        public int ProjectId { get; set; }

        public int? ClientId { get; set; }

        public string ClientName { get; set; }
        public string ProjectStatusName { get; set; }

        public int? ProjectStatusId { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public string PIC { get; set; }

        public string StartDatePlanStr { get; set; }
        public DateTime? StartDatePlan { get; set; }
        public string EndDatePlanStr { get; set; }

        public DateTime? EndDatePlan { get; set; }
        public string StartDateActualStr { get; set; }

        public DateTime? StartDateActual { get; set; }
        public string EndDateActualStr { get; set; }

        public DateTime? EndDateActual { get; set; }

        public decimal? MandaysEstimation { get; set; }

        public decimal? MandaysEstimationCal { get; set; }


        public string CreationBy { get; set; }

        public DateTime? CreationDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string FromDatePlan { get; set; }
        
        public string FromDateActual { get; set; }
        public string ToDateActual { get; set; }
        public string ToDatePlan { get; set; }
        public string EndFromDatePlan { get; set; }
        public string EndFromDateActual { get; set; }
        public string EndToDatePlan { get; set; }
        public string EndToDateActual { get; set; }
    }
}
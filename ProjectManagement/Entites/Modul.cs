namespace ProjectManagement.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Modul")]
    public partial class Modul
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Modul()
        {
            Modul1 = new HashSet<Modul>();
            ModulDependencies = new HashSet<ModulDependency>();
            ModulDependencies1 = new HashSet<ModulDependency>();
            ModulDocuments = new HashSet<ModulDocument>();
            ProjectTimelines = new HashSet<ProjectTimeline>();
            Requirements = new HashSet<Requirement>();
        }

        public int ModulId { get; set; }

        public int? ParentModulId { get; set; }

        public int? ProjectId { get; set; }

        public int? ModulStatusId { get; set; }

        [StringLength(50)]
        public string ModulName { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string PIC { get; set; }

        [StringLength(50)]
        public string ModulNumber { get; set; }

        public decimal? MadaysEstimation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Modul> Modul1 { get; set; }

        public virtual Modul Modul2 { get; set; }

        public virtual ModulStatu ModulStatu { get; set; }

        public virtual Project Project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModulDependency> ModulDependencies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModulDependency> ModulDependencies1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModulDocument> ModulDocuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectTimeline> ProjectTimelines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}

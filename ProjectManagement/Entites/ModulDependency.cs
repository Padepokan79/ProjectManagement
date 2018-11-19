namespace ProjectManagement.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ModulDependency")]
    public partial class ModulDependency
    {
        [Key]
        public int DependencyId { get; set; }

        public int? ModulId { get; set; }

        public int? DependToModulId { get; set; }

        public virtual Modul Modul { get; set; }

        public virtual Modul Modul1 { get; set; }
    }
}

namespace ProjectManagement.Entites
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectManagementDbContext : DbContext
    {
        public ProjectManagementDbContext()
            : base("name=ProjectManagementDbContext")
        {
        }

        public virtual DbSet<AuditTrailTransaction> AuditTrailTransactions { get; set; }
        public virtual DbSet<ChangeRequest> ChangeRequests { get; set; }
        public virtual DbSet<ChangeRequestDocument> ChangeRequestDocuments { get; set; }
        public virtual DbSet<ChangeRequestDocumentType> ChangeRequestDocumentTypes { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Modul> Moduls { get; set; }
        public virtual DbSet<ModulDependency> ModulDependencies { get; set; }
        public virtual DbSet<ModulDocument> ModulDocuments { get; set; }
        public virtual DbSet<ModulDocumentType> ModulDocumentTypes { get; set; }
        public virtual DbSet<ModulStatu> ModulStatus { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectDocument> ProjectDocuments { get; set; }
        public virtual DbSet<ProjectDocumentType> ProjectDocumentTypes { get; set; }
        public virtual DbSet<ProjectSchedule> ProjectSchedules { get; set; }
        public virtual DbSet<ProjectStatu> ProjectStatus { get; set; }
        public virtual DbSet<ProjectTimeline> ProjectTimelines { get; set; }
        public virtual DbSet<RequimentType> RequimentTypes { get; set; }
        public virtual DbSet<Requirement> Requirements { get; set; }
        public virtual DbSet<RequirementDocument> RequirementDocuments { get; set; }
        public virtual DbSet<RequirementDocumentType> RequirementDocumentTypes { get; set; }
        public virtual DbSet<RequirementHistory> RequirementHistories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditTrailTransaction>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<AuditTrailTransaction>()
                .Property(e => e.Action)
                .IsUnicode(false);

            modelBuilder.Entity<AuditTrailTransaction>()
                .Property(e => e.Details)
                .IsUnicode(false);

            modelBuilder.Entity<AuditTrailTransaction>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeRequest>()
                .Property(e => e.ChangeRequestNumber)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeRequest>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeRequest>()
                .Property(e => e.MandaysEstimation)
                .HasPrecision(14, 2);

            modelBuilder.Entity<ChangeRequestDocument>()
                .Property(e => e.DocumentName)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeRequestDocument>()
                .Property(e => e.FilePath)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeRequestDocument>()
                .Property(e => e.Version)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.ContactPerson)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<DocumentType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<DocumentType>()
                .HasOptional(e => e.ChangeRequestDocumentType)
                .WithRequired(e => e.DocumentType);

            modelBuilder.Entity<DocumentType>()
                .HasOptional(e => e.ModulDocumentType)
                .WithRequired(e => e.DocumentType);

            modelBuilder.Entity<DocumentType>()
                .HasOptional(e => e.ProjectDocumentType)
                .WithRequired(e => e.DocumentType);

            modelBuilder.Entity<DocumentType>()
                .HasOptional(e => e.RequirementDocumentType)
                .WithRequired(e => e.DocumentType);

            modelBuilder.Entity<Modul>()
                .Property(e => e.ModulName)
                .IsUnicode(false);

            modelBuilder.Entity<Modul>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Modul>()
                .Property(e => e.PIC)
                .IsUnicode(false);

            modelBuilder.Entity<Modul>()
                .Property(e => e.ModulNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Modul>()
                .Property(e => e.MadaysEstimation)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Modul>()
                .HasMany(e => e.Modul1)
                .WithOptional(e => e.Modul2)
                .HasForeignKey(e => e.ParentModulId);

            modelBuilder.Entity<Modul>()
                .HasMany(e => e.ModulDependencies)
                .WithOptional(e => e.Modul)
                .HasForeignKey(e => e.DependToModulId);

            modelBuilder.Entity<Modul>()
                .HasMany(e => e.ModulDependencies1)
                .WithOptional(e => e.Modul1)
                .HasForeignKey(e => e.ModulId);

            modelBuilder.Entity<ModulDocument>()
                .Property(e => e.DocumentName)
                .IsUnicode(false);

            modelBuilder.Entity<ModulDocument>()
                .Property(e => e.FilePath)
                .IsUnicode(false);

            modelBuilder.Entity<ModulDocument>()
                .Property(e => e.Version)
                .IsUnicode(false);

            modelBuilder.Entity<ModulStatu>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProjectName)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.PIC)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.MandaysEstimation)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Project>()
                .Property(e => e.MandaysEstimationCal)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Project>()
                .Property(e => e.CreationBy)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectDocument>()
                .Property(e => e.DocumentName)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectDocument>()
                .Property(e => e.FilePath)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectDocument>()
                .Property(e => e.Version)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectSchedule>()
                .Property(e => e.Version)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectSchedule>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectStatu>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<RequimentType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Requirement>()
                .Property(e => e.RequirementNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Requirement>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Requirement>()
                .Property(e => e.Details)
                .IsUnicode(false);

            modelBuilder.Entity<Requirement>()
                .Property(e => e.CreationBy)
                .IsUnicode(false);

            modelBuilder.Entity<Requirement>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Requirement>()
                .HasMany(e => e.Requirement1)
                .WithOptional(e => e.Requirement2)
                .HasForeignKey(e => e.ParentRequimentId);

            modelBuilder.Entity<Requirement>()
                .HasMany(e => e.RequirementHistories)
                .WithRequired(e => e.Requirement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequirementDocument>()
                .Property(e => e.DocumentName)
                .IsUnicode(false);

            modelBuilder.Entity<RequirementDocument>()
                .Property(e => e.FilePath)
                .IsUnicode(false);

            modelBuilder.Entity<RequirementDocument>()
                .Property(e => e.Version)
                .IsUnicode(false);

            modelBuilder.Entity<RequirementHistory>()
                .Property(e => e.RequirementNumber)
                .IsUnicode(false);

            modelBuilder.Entity<RequirementHistory>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<RequirementHistory>()
                .Property(e => e.CreationBy)
                .IsUnicode(false);

            modelBuilder.Entity<RequirementHistory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);
        }
    }
}

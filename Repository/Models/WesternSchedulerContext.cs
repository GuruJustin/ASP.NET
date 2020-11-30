using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repository.Models
{
    public partial class WesternSchedulerContext : DbContext
    {
        public WesternSchedulerContext()
        {
        }

        public WesternSchedulerContext(DbContextOptions<WesternSchedulerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressDescriptors> AddressDescriptors { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<ListOfValues> ListOfValues { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<ProjectDevelopers> ProjectDevelopers { get; set; }
        public virtual DbSet<ProjectManagers> ProjectManagers { get; set; }
        public virtual DbSet<ProjectNumbers> ProjectNumbers { get; set; }
        public virtual DbSet<ProjectRevisions> ProjectRevisions { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<XProjectDeveloperLocations> XProjectDeveloperLocations { get; set; }
        public virtual DbSet<XProjectManagerLocations> XProjectManagerLocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\PROJECT;Database=western;User Id=sa;Password=Developer123;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Events>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EventColor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Style).IsUnicode(false);

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_resources");


                entity.HasOne(d => d.ProjectNumbers)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_ProjectNumbers");


            });



            modelBuilder.Entity<AddressDescriptors>(entity =>
            {
                entity.HasKey(e => e.AddressDescriptorId)
                    .HasName("PK_Descriptors");

                entity.Property(e => e.AddressDescriptorId).HasColumnName("AddressDescriptorID");

                entity.Property(e => e.AddressDescriptorType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressDescriptorValue)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectNumberId).HasColumnName("ProjectNumberID");

                entity.HasOne(d => d.ProjectNumber)
                    .WithMany(p => p.AddressDescriptors)
                    .HasForeignKey(d => d.ProjectNumberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AddressDescriptors_ProjectNumbers");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Employees_Departments");
            });

            modelBuilder.Entity<ListOfValues>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectDevelopers>(entity =>
            {
                entity.HasKey(e => e.ProjectDeveloperId);

                entity.Property(e => e.ProjectDeveloperId).HasColumnName("ProjectDeveloperID");

                entity.Property(e => e.ProjectDeveloperName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectManagers>(entity =>
            {
                entity.HasKey(e => e.ProjectManagerID);

                entity.Property(e => e.ProjectManagerID).HasColumnName("ProjectManagerID");

                entity.Property(e => e.ProjectManagerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectNumbers>(entity =>
            {
                entity.HasKey(e => e.ProjectNumberId);

                entity.Property(e => e.ProjectNumberId).HasColumnName("ProjectNumberID");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NickName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectDeveloperId).HasColumnName("ProjectDeveloperID");

                entity.Property(e => e.ProjectManagerId).HasColumnName("ProjectManagerID");

                entity.Property(e => e.ProjectNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ProjectNumbers)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectNumbers_Clients");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.ProjectNumbers)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectNumbers_Locations");

                entity.HasOne(d => d.ProjectDeveloper)
                    .WithMany(p => p.ProjectNumbers)
                    .HasForeignKey(d => d.ProjectDeveloperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectNumbers_ProjectDevelopers");

                entity.HasOne(d => d.ProjectManager)
                    .WithMany(p => p.ProjectNumbers)
                    .HasForeignKey(d => d.ProjectManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectNumbers_ProjectManagers");
            });

            modelBuilder.Entity<ProjectRevisions>(entity =>
            {
                entity.HasKey(e => e.ProjectRevisionId);

                entity.Property(e => e.ProjectRevisionId).HasColumnName("ProjectRevisionID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Hours).HasColumnType("numeric(10, 2)");
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.AllDay).HasColumnType("bit");


                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectDeveloperId).HasColumnName("ProjectDeveloperID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectManagerId).HasColumnName("ProjectManagerID");

                entity.HasOne(d => d.ProjectDeveloper)
                    .WithMany(p => p.ProjectRevisions)
                    .HasForeignKey(d => d.ProjectDeveloperId)
                    .HasConstraintName("FK_ProjectRevisions_ProjectDevelopers");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectRevisions)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectRevisions_Projects");

                entity.HasOne(d => d.ProjectManager)
                    .WithMany(p => p.ProjectRevisions)
                    .HasForeignKey(d => d.ProjectManagerId)
                    .HasConstraintName("FK_ProjectRevisions_ProjectManagers");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

             
                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ParentProjectId).HasColumnName("ParentProjectID");

                entity.Property(e => e.ProjectNumberId).HasColumnName("ProjectNumberID");

                entity.Property(e => e.ProjectType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

              //  entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_Employees");

                entity.HasOne(d => d.ProjectNumber)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectNumberId)
                    .HasConstraintName("FK_Projects_ProjectNumbers");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Adname)
                    .IsRequired()
                    .HasColumnName("ADName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XProjectDeveloperLocations>(entity =>
            {
                entity.HasKey(e => new { e.ProjectDeveloperId, e.LocationId });

                entity.ToTable("xProjectDeveloper_Locations");

                entity.Property(e => e.ProjectDeveloperId).HasColumnName("ProjectDeveloperID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.XProjectDeveloperLocations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_xProjectDeveloper_Locations_Locations");

                entity.HasOne(d => d.ProjectDeveloper)
                    .WithMany(p => p.XProjectDeveloperLocations)
                    .HasForeignKey(d => d.ProjectDeveloperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_xProjectDeveloper_Locations_ProjectDevelopers");
            });

            modelBuilder.Entity<XProjectManagerLocations>(entity =>
            {
                entity.HasKey(e => new { e.ProjectManagerID, e.LocationId });

                entity.ToTable("xProjectManager_Locations");

                entity.Property(e => e.ProjectManagerID).HasColumnName("ProjectManagerID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.XProjectManagerLocations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_xProjectManager_Locations_Locations");

                entity.HasOne(d => d.ProjectManagerI)
                    .WithMany(p => p.XProjectManagerLocations)
                    .HasForeignKey(d => d.ProjectManagerID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_xProjectManager_Locations_ProjectManagers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

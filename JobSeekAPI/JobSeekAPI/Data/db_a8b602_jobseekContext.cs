using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using JobSeekAPI.Models;

namespace JobSeekAPI.Data
{
    public partial class db_a8b602_jobseekContext : DbContext
    {
        public db_a8b602_jobseekContext()
        {
        }

        public db_a8b602_jobseekContext(DbContextOptions<db_a8b602_jobseekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<BranchSection> BranchSections { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Certification> Certifications { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Documnet> Documnets { get; set; } = null!;
        public virtual DbSet<Education> Educations { get; set; } = null!;
        public virtual DbSet<Employeer> Employeers { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Savedjob> Savedjobs { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.HasIndex(e => e.Email, "Email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.LogInDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.LogOutDate).HasColumnType("datetime");

                entity.Property(e => e.Paswword).HasMaxLength(50);
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("branch");

                entity.HasIndex(e => e.Address, "Address_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CityId, "Fkey_City_Branch_idx");

                entity.HasIndex(e => e.CompanyId, "Fkey_Company_Branch_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE1")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("Fkey_City_Branch");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("Fkey_Company_Branch");
            });

            modelBuilder.Entity<BranchSection>(entity =>
            {
                entity.ToTable("branch_section");

                entity.HasIndex(e => e.BranchId, "Fkey_Branch_idx");

                entity.HasIndex(e => e.SectionId, "Fkey_Section_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE2")
                    .IsUnique();

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.BranchSections)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("Fkey_Branch");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.BranchSections)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("Fkey_Section");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.HasIndex(e => e.Id, "Id_UNIQUE3")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "Name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(350);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.ToTable("certification");

                entity.HasIndex(e => e.Id, "Id_UNIQUE4")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "Name_UNIQUE1")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(45);

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasIndex(e => e.Id, "Id_UNIQUE5")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "Name_UNIQUE2")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.HasIndex(e => e.Email, "Email_UNIQUE1")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "Id_UNIQUE6")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "Name_UNIQUE3")
                    .IsUnique();

                entity.HasIndex(e => e.PassCode, "PassCode_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.WebSite, "WebSite_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Details).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(120);

                entity.Property(e => e.WebSite).HasMaxLength(200);
            });

            modelBuilder.Entity<Documnet>(entity =>
            {
                entity.ToTable("documnet");

                entity.HasIndex(e => e.Id, "Id_UNIQUE7")
                    .IsUnique();

                entity.Property(e => e.ExtraInfo).HasMaxLength(500);

                entity.Property(e => e.IsCv).HasMaxLength(500);
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("education");

                entity.HasIndex(e => e.Id, "Id_UNIQUE8")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "Name_UNIQUE4")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<Employeer>(entity =>
            {
                entity.ToTable("employeer");

                entity.HasIndex(e => e.Email, "Email_UNIQUE2")
                    .IsUnique();

                entity.HasIndex(e => e.CompanyId, "Fkey_Company_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE9")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(120);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.State)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employeers)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("Fkey_Company");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("job");

                entity.HasIndex(e => e.BranchSectionId, "Fkey_BranchSection_job_idx");

                entity.HasIndex(e => e.CategoryId, "Fkey_Category_Job_idx");

                entity.HasIndex(e => e.CertificationId, "Fkey_Certification_Job_idx");

                entity.HasIndex(e => e.EducationId, "Fkey_Education_Job_idx");

                entity.HasIndex(e => e.EmployeerId, "Fkey_Employeer_Job_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE10")
                    .IsUnique();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasMaxLength(350);

                entity.Property(e => e.GenderRequired).HasMaxLength(45);

                entity.Property(e => e.JobType).HasMaxLength(100);

                entity.Property(e => e.PersonsNumRequired).HasDefaultValueSql("'1'");

                entity.Property(e => e.Salary).HasPrecision(10);

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.HasOne(d => d.BranchSection)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.BranchSectionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Fkey_BranchSection_job");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Fkey_Category_Job");

                entity.HasOne(d => d.Certification)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.CertificationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Fkey_Certification_Job");

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.EducationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Fkey_Education_Job");

                entity.HasOne(d => d.Employeer)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.EmployeerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Fkey_Employeer_Job");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => e.DocumentId, "Fkey_Document_Order_idx");

                entity.HasIndex(e => e.JobId, "Fkey_Job_Order_idx");

                entity.HasIndex(e => e.UserId, "Fkey_User_Order_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE11")
                    .IsUnique();

                entity.Property(e => e.Acceptance)
                    .HasColumnType("int")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Fkey_Document_Order");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("Fkey_Job_Order");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Fkey_User_Order");
            });

            modelBuilder.Entity<Savedjob>(entity =>
            {
                entity.ToTable("savedjob");

                entity.HasIndex(e => e.Id, "Id_UNIQUE12")
                    .IsUnique();
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("section");

                entity.HasComment("				");

                entity.HasIndex(e => e.Id, "Id_UNIQUE13")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "Name_UNIQUE5")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email, "Email_UNIQUE3")
                    .IsUnique();

                entity.HasIndex(e => e.CertificationId, "Fkey_Certification_User_idx");

                entity.HasIndex(e => e.CityId, "Fkey_City_User_idx");

                entity.HasIndex(e => e.EducationId, "Fkey_Education_User_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE14")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Gender).HasMaxLength(45);

                entity.Property(e => e.Name).HasMaxLength(120);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(75);

                entity.HasOne(d => d.Certification)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CertificationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Fkey_Certification_User");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Fkey_City_User");

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.EducationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Fkey_Education_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

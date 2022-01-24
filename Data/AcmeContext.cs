using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using acme_employees.Models;

#nullable disable

namespace acme_employees.Data
{
    public partial class AcmeContext : DbContext
    {
        public AcmeContext()
        {
        }

        public AcmeContext(DbContextOptions<AcmeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=localhost;Database=ACME;User=sa;Password=All@34342022;Trusted_Connection=False;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(d => d.SystemUser)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<SystemUser>(d => d.SystemUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__System__30F848ED");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

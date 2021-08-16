using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VehicleLoan.LTIModel
{
    public partial class Vehicle_LoanContext : DbContext
    {
        public Vehicle_LoanContext()
        {
        }

        public Vehicle_LoanContext(DbContextOptions<Vehicle_LoanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EligibilityTable> EligibilityTables { get; set; }
        public virtual DbSet<LoanTable> LoanTables { get; set; }
        public virtual DbSet<LoginTable> LoginTables { get; set; }
        public virtual DbSet<RegisterTable> RegisterTables { get; set; }
        public virtual DbSet<UploadTable> UploadTables { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Vehicle_Loan;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EligibilityTable>(entity =>
            {
                entity.HasKey(e => e.EligId)
                    .HasName("pk_eligId");

                entity.ToTable("EligibilityTable");

                entity.Property(e => e.EligId).HasColumnName("eligId");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.CarMake)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("carMake");

                entity.Property(e => e.CarModel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("carModel");

                entity.Property(e => e.ExistingEmi)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("existingEmi");

                entity.Property(e => e.LoanAmt).HasColumnName("loanAmt");

                entity.Property(e => e.LoanPeriod).HasColumnName("loanPeriod");

                entity.Property(e => e.OnRoadPrice).HasColumnName("onRoadPrice");

                entity.Property(e => e.RateOfInterest).HasColumnName("rateOfInterest");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.Property(e => e.ShowroomPrice).HasColumnName("showroomPrice");

                entity.Property(e => e.Uname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("uname");

                entity.HasOne(d => d.UnameNavigation)
                    .WithMany(p => p.EligibilityTables)
                    .HasForeignKey(d => d.Uname)
                    .HasConstraintName("fk_uname");
            });

            modelBuilder.Entity<LoanTable>(entity =>
            {
                entity.HasKey(e => e.LoanId)
                    .HasName("pk_loanid");

                entity.ToTable("LoanTable");

                entity.Property(e => e.LoanId).HasColumnName("loanId");

                entity.Property(e => e.AnnualSalary).HasColumnName("Annual_salary");

                entity.Property(e => e.CarMake)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Car_make");

                entity.Property(e => e.CarModel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Car_model");

                entity.Property(e => e.EmploymentType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Employment_type");

                entity.Property(e => e.ExistingEmi)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Existing_EMI");

                entity.Property(e => e.LoanAmount).HasColumnName("Loan_amount");

                entity.Property(e => e.LoanStatus)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("loanStatus");

                entity.Property(e => e.LoanTenure).HasColumnName("Loan_tenure");

                entity.Property(e => e.OnRoadPrice).HasColumnName("OnRoad_price");

                entity.Property(e => e.RateOfInterest).HasColumnName("Rate_of_Interest");

                entity.Property(e => e.ShowroomPrice).HasColumnName("Showroom_price");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoanTables)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_userid");
            });

            modelBuilder.Entity<LoginTable>(entity =>
            {
                entity.HasKey(e => e.Uname)
                    .HasName("PK__LoginTab__C7D2484FF67B7083");

                entity.ToTable("LoginTable");

                entity.Property(e => e.Uname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("uname");

                entity.Property(e => e.Uadmin)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("uadmin");

                entity.Property(e => e.Upassword)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("upassword");
            });

            modelBuilder.Entity<RegisterTable>(entity =>
            {
                entity.HasKey(e => e.RuserId)
                    .HasName("pk_ruserid");

                entity.ToTable("RegisterTable");

                entity.Property(e => e.RuserId).HasColumnName("ruserId");

                entity.Property(e => e.Rage).HasColumnName("rage");

                entity.Property(e => e.Remail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("remail");

                entity.Property(e => e.Rgender)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("rgender");

                entity.Property(e => e.Rmobile)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("rmobile");

                entity.Property(e => e.Rname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rname");

                entity.Property(e => e.Rpassword)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("rpassword");

                entity.Property(e => e.Runame)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("runame");
            });

            modelBuilder.Entity<UploadTable>(entity =>
            {
                entity.HasKey(e => e.Adhar)
                    .HasName("PK__UploadTa__C08688D577488F58");

                entity.ToTable("UploadTable");

                entity.Property(e => e.Adhar)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("adhar");

                entity.Property(e => e.Pan)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pan");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UploadTables)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_fuserid");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("pk_userid");

                entity.ToTable("UserTable");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Uaddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("uaddress");

                entity.Property(e => e.Uage).HasColumnName("uage");

                entity.Property(e => e.Ucity)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ucity");

                entity.Property(e => e.Uemail)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("uemail");

                entity.Property(e => e.Ugender)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ugender");

                entity.Property(e => e.Umobile)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("umobile");

                entity.Property(e => e.Uname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("uname");

                entity.Property(e => e.Upassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("upassword");

                entity.Property(e => e.Upin).HasColumnName("upin");

                entity.Property(e => e.Ustate)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ustate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

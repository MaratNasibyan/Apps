using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gap.DataBase.Models
{
    public partial class MyGapContext : DbContext
    {
        public MyGapContext()
        {
        }

        public MyGapContext(DbContextOptions<MyGapContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Login> Login { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=OFFICE39-PC\\MYSQLSERVER; Database=MyGap; User Id=Marat; Password=Marat12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.UsrId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.UserName)
                    .HasName("UC_Username")
                    .IsUnique();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsApproved)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastVisitDate).HasColumnType("datetime");

                entity.Property(e => e.LastVisiteDate).HasColumnType("datetime");

                entity.Property(e => e.LogixContactId)
                    .HasColumnName("LogixContactID")
                    .HasMaxLength(50);

                entity.Property(e => e.MustChangePassword).HasDefaultValueSql("((0))");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordAnswer).HasMaxLength(128);

                entity.Property(e => e.PasswordQuestion).HasMaxLength(256);

                entity.Property(e => e.PasswordSalt).HasMaxLength(128);

                entity.Property(e => e.Source).HasMaxLength(50);

                entity.Property(e => e.TermsAgreedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GNStudentManagement.Models;

public partial class GnstudentManagementContext : DbContext
{
    public GnstudentManagementContext()
    {
    }

    public GnstudentManagementContext(DbContextOptions<GnstudentManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcdPrjProjectGroup> AcdPrjProjectGroups { get; set; }

    public virtual DbSet<AcdPrjProjectGroupMember> AcdPrjProjectGroupMembers { get; set; }

    public virtual DbSet<AcdPrjProjectMeeting> AcdPrjProjectMeetings { get; set; }

    public virtual DbSet<AcdPrjProjectMeetingAttendance> AcdPrjProjectMeetingAttendances { get; set; }

    public virtual DbSet<AcdPrjProjectType> AcdPrjProjectTypes { get; set; }

    public virtual DbSet<AcdStaff> AcdStaffs { get; set; }

    public virtual DbSet<AcdStudent> AcdStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcdPrjProjectGroup>(entity =>
        {
            entity.HasKey(e => e.ProjectGroupId).HasName("PK__ACD_PRJ___17125E7E01F583DB");

            entity.ToTable("ACD_PRJ_ProjectGroup");

            entity.Property(e => e.ProjectGroupId).HasColumnName("ProjectGroupID");
            entity.Property(e => e.AverageCpi)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("AverageCPI");
            entity.Property(e => e.ConvenerStaffId).HasColumnName("ConvenerStaffID");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ExpertStaffId).HasColumnName("ExpertStaffID");
            entity.Property(e => e.GuideStaffName).HasMaxLength(100);
            entity.Property(e => e.Modified).HasColumnType("datetime");
            entity.Property(e => e.ProjectArea).HasMaxLength(100);
            entity.Property(e => e.ProjectGroupName).HasMaxLength(100);
            entity.Property(e => e.ProjectTitle).HasMaxLength(200);
            entity.Property(e => e.ProjectTypeId).HasColumnName("ProjectTypeID");

            entity.HasOne(d => d.ConvenerStaff).WithMany(p => p.AcdPrjProjectGroupConvenerStaffs)
                .HasForeignKey(d => d.ConvenerStaffId)
                .HasConstraintName("FK__ACD_PRJ_P__Conve__534D60F1");

            entity.HasOne(d => d.ExpertStaff).WithMany(p => p.AcdPrjProjectGroupExpertStaffs)
                .HasForeignKey(d => d.ExpertStaffId)
                .HasConstraintName("FK__ACD_PRJ_P__Exper__5441852A");

            entity.HasOne(d => d.ProjectType).WithMany(p => p.AcdPrjProjectGroups)
                .HasForeignKey(d => d.ProjectTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ACD_PRJ_P__Proje__52593CB8");
        });

        modelBuilder.Entity<AcdPrjProjectGroupMember>(entity =>
        {
            entity.HasKey(e => e.ProjectGroupMemberId).HasName("PK__ACD_PRJ___A94CAB8A3172EEC1");

            entity.ToTable("ACD_PRJ_ProjectGroupMember");

            entity.Property(e => e.ProjectGroupMemberId).HasColumnName("ProjectGroupMemberID");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Modified).HasColumnType("datetime");
            entity.Property(e => e.ProjectGroupId).HasColumnName("ProjectGroupID");
            entity.Property(e => e.StudentCgpa)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("StudentCGPA");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.ProjectGroup).WithMany(p => p.AcdPrjProjectGroupMembers)
                .HasForeignKey(d => d.ProjectGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ACD_PRJ_P__Proje__5812160E");

            entity.HasOne(d => d.Student).WithMany(p => p.AcdPrjProjectGroupMembers)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ACD_PRJ_P__Stude__59063A47");
        });

        modelBuilder.Entity<AcdPrjProjectMeeting>(entity =>
        {
            entity.HasKey(e => e.ProjectMeetingId).HasName("PK__ACD_PRJ___029539C9364A2FE7");

            entity.ToTable("ACD_PRJ_ProjectMeeting");

            entity.Property(e => e.ProjectMeetingId).HasColumnName("ProjectMeetingID");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.GuideStaffId).HasColumnName("GuideStaffID");
            entity.Property(e => e.MeetingDateTime).HasColumnType("datetime");
            entity.Property(e => e.MeetingLocation).HasMaxLength(200);
            entity.Property(e => e.MeetingPurpose).HasMaxLength(200);
            entity.Property(e => e.MeetingStatus).HasMaxLength(50);
            entity.Property(e => e.MeetingStatusDatetime).HasColumnType("datetime");
            entity.Property(e => e.MeetingStatusDescription).HasMaxLength(200);
            entity.Property(e => e.Modified).HasColumnType("datetime");
            entity.Property(e => e.ProjectGroupId).HasColumnName("ProjectGroupID");

            entity.HasOne(d => d.GuideStaff).WithMany(p => p.AcdPrjProjectMeetings)
                .HasForeignKey(d => d.GuideStaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ACD_PRJ_P__Guide__5EBF139D");

            entity.HasOne(d => d.ProjectGroup).WithMany(p => p.AcdPrjProjectMeetings)
                .HasForeignKey(d => d.ProjectGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ACD_PRJ_P__Proje__5DCAEF64");
        });

        modelBuilder.Entity<AcdPrjProjectMeetingAttendance>(entity =>
        {
            entity.HasKey(e => e.ProjectMeetingAttendanceId).HasName("PK__ACD_PRJ___679727B44A477CD2");

            entity.ToTable("ACD_PRJ_ProjectMeetingAttendance");

            entity.Property(e => e.ProjectMeetingAttendanceId).HasColumnName("ProjectMeetingAttendanceID");
            entity.Property(e => e.AttendanceRemarks).HasMaxLength(200);
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Modified).HasColumnType("datetime");
            entity.Property(e => e.ProjectMeetingId).HasColumnName("ProjectMeetingID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.ProjectMeeting).WithMany(p => p.AcdPrjProjectMeetingAttendances)
                .HasForeignKey(d => d.ProjectMeetingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ACD_PRJ_P__Proje__628FA481");

            entity.HasOne(d => d.Student).WithMany(p => p.AcdPrjProjectMeetingAttendances)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ACD_PRJ_P__Stude__6383C8BA");
        });

        modelBuilder.Entity<AcdPrjProjectType>(entity =>
        {
            entity.HasKey(e => e.ProjectTypeId).HasName("PK__ACD_PRJ___6F245E4394F1591F");

            entity.ToTable("ACD_PRJ_ProjectType");

            entity.Property(e => e.ProjectTypeId).HasColumnName("ProjectTypeID");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Modified).HasColumnType("datetime");
            entity.Property(e => e.ProjectTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<AcdStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__ACD_Staf__96D4AAF7E87D9145");

            entity.ToTable("ACD_Staff");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Modified).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.StaffName).HasMaxLength(100);
        });

        modelBuilder.Entity<AcdStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__ACD_Stud__32C52A79CF4DA025");

            entity.ToTable("ACD_Student");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Modified).HasColumnType("datetime");
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.StudentName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

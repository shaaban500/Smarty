﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smarty.Data.SmartyDBContext;

#nullable disable

namespace Smarty.Migrations
{
    [DbContext(typeof(SmartyDbContext))]
    partial class SmartyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Smarty.Data.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("AccessCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("RegisterCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Smarty.Data.Models.CourseGrade", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<double>("Grade")
                        .HasColumnType("float");

                    b.HasKey("Name", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("CoursesGrades");
                });

            modelBuilder.Entity("Smarty.Data.Models.Lab", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("Name", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("Labs");
                });

            modelBuilder.Entity("Smarty.Data.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MemberType")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Members");

                    b.HasDiscriminator<string>("MemberType").HasValue("Member");
                });

            modelBuilder.Entity("Smarty.Data.Models.StudentsCourses", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentsCourses");
                });

            modelBuilder.Entity("Smarty.Data.Models.StudentsLabs", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("LabName")
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("StudentId", "CourseId", "LabName");

                    b.HasIndex("LabName", "CourseId");

                    b.ToTable("StudentsLabs");
                });

            modelBuilder.Entity("Smarty.Data.Models.Instructor", b =>
                {
                    b.HasBaseType("Smarty.Data.Models.Member");

                    b.HasDiscriminator().HasValue("Instructor");
                });

            modelBuilder.Entity("Smarty.Data.Models.Student", b =>
                {
                    b.HasBaseType("Smarty.Data.Models.Member");

                    b.Property<string>("Department")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Smarty.Data.Models.Course", b =>
                {
                    b.HasOne("Smarty.Data.Models.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Smarty.Data.Models.CourseGrade", b =>
                {
                    b.HasOne("Smarty.Data.Models.Course", "Course")
                        .WithMany("CourseGrades")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Smarty.Data.Models.Lab", b =>
                {
                    b.HasOne("Smarty.Data.Models.Course", "Course")
                        .WithMany("Labs")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Smarty.Data.Models.StudentsCourses", b =>
                {
                    b.HasOne("Smarty.Data.Models.Course", "Course")
                        .WithMany("StudentsCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smarty.Data.Models.Student", "Student")
                        .WithMany("StudentsCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Smarty.Data.Models.StudentsLabs", b =>
                {
                    b.HasOne("Smarty.Data.Models.Student", "Student")
                        .WithMany("StudentsLabs")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smarty.Data.Models.Lab", "Lab")
                        .WithMany("StudentsLabs")
                        .HasForeignKey("LabName", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lab");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Smarty.Data.Models.Course", b =>
                {
                    b.Navigation("CourseGrades");

                    b.Navigation("Labs");

                    b.Navigation("StudentsCourses");
                });

            modelBuilder.Entity("Smarty.Data.Models.Lab", b =>
                {
                    b.Navigation("StudentsLabs");
                });

            modelBuilder.Entity("Smarty.Data.Models.Instructor", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Smarty.Data.Models.Student", b =>
                {
                    b.Navigation("StudentsCourses");

                    b.Navigation("StudentsLabs");
                });
#pragma warning restore 612, 618
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore_School.Models;

namespace EFCore_School.DataAccess
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "School.db");
            optionsBuilder.UseSqlite($"Filename-{path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(p => p.Id).IsRequired(); // to samo co [Required] w klasie Student

            modelBuilder.Entity<Course>().Property(p => p.Title).HasColumnName("title");

            InitDatabase(modelBuilder);
        }

        private void InitDatabase(ModelBuilder modelBuilder)
        {
            Student s1 = new() { Id = 1, FirstName = "aaaa", LastName = "aaaaa" };
            Student s2 = new() { Id = 2, FirstName = "ssss", LastName = "ssss" };
            modelBuilder.Entity<Student>().HasData(s1, s2, new() { Id = 1, FirstName = "dupa", LastName = "www" });


            Course c1 = new Course() { Id = 1, Title = "Matma" };
            Course c2 = new Course() { Id = 2, Title = "Algorytmy" };
            modelBuilder.Entity<Course>().HasData(c1, c2, new() { Id = 1, Title = "AI" });

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Studencts)
                .WithMany(s => s.Courses)
                .UsingEntity(cs => cs
                .HasData(
                    new { CoursesId = c1.Id, StudentsId = s1.Id },
                    new { CoursesId = c1.Id, StudentsId = s2.Id },
                    new { CoursesId = c2.Id, StudentsId = s2.Id }));
        }
    }
}

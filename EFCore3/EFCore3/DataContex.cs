using EFCore3.Migrations;
using EFCore3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCore3
{
    class DataContex : DbContext
    {
        public DbSet<University> universitie { get; set; }
        public DbSet<College> college { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<Professor> professor { get; set; }
        public DbSet<Student> student { get; set; }

        //public DataContex(DbContextOptions<DataContex> options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;database=LinqPracticeWithProject2;User=root;Password=Bapuji@999;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.31-mariadb"))
                  //.EnableSensitiveDataLogging()
                  //.LogTo(Console.WriteLine, LogLevel.Information)
                  ;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<University>()
                .HasKey(u => u.UniversityId);

            modelBuilder.Entity<College>()
                .HasKey(c => c.CollegeId);

            modelBuilder.Entity<Department>()
                .HasKey(c => c.DepartmentId); 

            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);

            modelBuilder.Entity<University>()
               .HasMany(u => u.Colleges)
               .WithOne(c => c.University)
               .HasForeignKey(c => c.UniversityId);

            modelBuilder.Entity<College>()
               .HasMany(u => u.Departments)
               .WithOne(c => c.College)
               .HasForeignKey(c => c.CollegeId);

            modelBuilder.Entity<Department>()
               .HasMany(u => u.Professors)
               .WithOne(c => c.Department)
               .HasForeignKey(c => c.DepartmentId);

            modelBuilder.Entity<Department>()
               .HasMany(u => u.Students)
               .WithOne(c => c.Department)
               .HasForeignKey(c => c.DepartmentId);
            SeedData(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>().HasData(
                new University
                {
                    UniversityId = 1,
                    UniversityName = "Harvard University",
                    UnversityType = "Private",
                    UnvesrsityGrade = "A+",
                    UnversityAddress = "Cambridge, Massachusetts"
                }, 
                new University
                {
                    UniversityId = 2,
                    UniversityName = "MIT",
                    UnversityType = "Private",
                    UnvesrsityGrade = "A",
                    UnversityAddress = "Cambridge, Massachusetts"
                },
                new University
                {
                    UniversityId = 3,
                    UniversityName = "Stanford University",
                    UnversityType = "Private",
                    UnvesrsityGrade = "A+",
                    UnversityAddress = "Stanford, California"
                }
            );
            modelBuilder.Entity<College>().HasData(
                    new College
                 {
                     CollegeId = 1,
                     CollegeName = "Engineering College 1",
                     CollegeType = "Technical",
                     CollegeAddress = "123 College Street 1",
                     UniversityId = 1
                 },
                    new College
                    {
                        CollegeId = 2,
                        CollegeName = "Engineering College 2",
                        CollegeType = "Technical",
                        CollegeAddress = "123 College Street 2",
                        UniversityId = 1
                    },
                    new College
                    {
                        CollegeId = 3,
                        CollegeName = "Engineering College 3",
                        CollegeType = "Technical",
                        CollegeAddress = "123 College Street 3",
                        UniversityId = 2
                    },
                    new College
                    {
                        CollegeId = 4,
                        CollegeName = "Engineering College 4",
                        CollegeType = "Technical",
                        CollegeAddress = "123 College Street 4",
                        UniversityId = 2
                    },
                    new College
                    {
                        CollegeId = 5,
                        CollegeName = "Engineering College 5",
                        CollegeType = "Technical",
                        CollegeAddress = "123 College Street 5",
                        UniversityId = 3
                    },
                    new College
                    {
                        CollegeId = 6,
                        CollegeName = "Engineering College 6",
                        CollegeType = "Technical",
                        CollegeAddress = "123 College Street 6",
                        UniversityId = 3
                    }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "Computer Science",
                    NuumberOfClass = 5,
                    DepartmentHead = "Prof. Muktesh",
                    CollegeId = 1
                },
                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "Mech",
                    NuumberOfClass = 3,
                    DepartmentHead = "Prof. Resav",
                    CollegeId = 1
                },
                new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "ETC",
                    NuumberOfClass = 4,
                    DepartmentHead = "Prof. John",
                    CollegeId = 2
                },
                new Department
                {
                    DepartmentId = 4,
                    DepartmentName = "Civil",
                    NuumberOfClass = 5,
                    DepartmentHead = "Prof. Rekha",
                    CollegeId = 2
                },
                new Department
                {
                    DepartmentId = 5,
                    DepartmentName = "Computer Science",
                    NuumberOfClass = 5,
                    DepartmentHead = "Prof. Albert",
                    CollegeId = 3
                },
                new Department
                {
                    DepartmentId = 6,
                    DepartmentName = "Mech",
                    NuumberOfClass = 5,
                    DepartmentHead = "Prof. Rohit",
                    CollegeId = 3
                },
                new Department
                {
                    DepartmentId = 7,
                    DepartmentName = "ETC",
                    NuumberOfClass = 5,
                    DepartmentHead = "Prof. Jadu",
                    CollegeId = 4
                },
                new Department
                {
                    DepartmentId = 8,
                    DepartmentName = "Civil",
                    NuumberOfClass = 5,
                    DepartmentHead = "Prof. Ramnesh",
                    CollegeId = 4
                },
                new Department
                {
                    DepartmentId = 9,
                    DepartmentName = "Computer Science",
                    NuumberOfClass = 5,
                    DepartmentHead = "Prof. Rghav",
                    CollegeId = 5
                },
                new Department
                {
                    DepartmentId = 10,
                    DepartmentName = "Computer Science",
                    NuumberOfClass = 5,
                    DepartmentHead = "Prof. Jignesh",
                    CollegeId = 6
                }
            );
            modelBuilder.Entity<Professor>().HasData(
                new Professor
                {
                    ProfessorId = 1,
                    ProfessorName = "Prof. Muktesh",
                    ProfessorAddress = "Muktanagar 1234",
                    ProfessorAge = 40,
                    Salary = 50000.120,
                    DepartmentId = 1
                },
                new Professor
                {
                    ProfessorId = 2,
                    ProfessorName = "Prof. Resav",
                    ProfessorAddress = "Resavnagar 1234",
                    ProfessorAge = 34,
                    Salary = 35000.120,
                    DepartmentId = 2
                },
                new Professor
                {
                    ProfessorId = 3,
                    ProfessorName = "Prof. John",
                    ProfessorAddress = "JohnNagar 1234",
                    ProfessorAge = 34,
                    Salary = 15000.34,
                    DepartmentId = 3
                },
                new Professor
                {
                    ProfessorId = 4,
                    ProfessorName = "Prof. Rekha",
                    ProfessorAddress = "RekhaNagar 1234",
                    ProfessorAge = 29,
                    Salary = 25000.46,
                    DepartmentId = 4
                },
                new Professor
                {
                    ProfessorId = 5,
                    ProfessorName = "Prof. Albert",
                    ProfessorAddress = "AlbertNagar 1234",
                    ProfessorAge = 58,
                    Salary = 60000.00,
                    DepartmentId = 5
                },
                new Professor
                {
                    ProfessorId = 6,
                    ProfessorName = "Prof. Rohit",
                    ProfessorAddress = "RohitNagar 1234",
                    ProfessorAge = 28,
                    Salary = 26000.00,
                    DepartmentId = 6
                },
                new Professor
                {
                    ProfessorId = 7,
                    ProfessorName = "Prof. Jadu",
                    ProfessorAddress = "JaduNagar 1234",
                    ProfessorAge = 38,
                    Salary = 58000.00,
                    DepartmentId = 7
                },
                new Professor
                {
                    ProfessorId = 8,
                    ProfessorName = "Prof. Ramnesh",
                    ProfessorAddress = "RamneshNagar 1234",
                    ProfessorAge = 34,
                    Salary = 38000.00,
                    DepartmentId = 8
                },
                new Professor
                {
                    ProfessorId = 9,
                    ProfessorName = "Prof. Rghav",
                    ProfessorAddress = "RghavNagar 1234",
                    ProfessorAge = 41,
                    Salary = 45000.00,
                    DepartmentId = 9
                },
                new Professor
                {
                    ProfessorId = 10,
                    ProfessorName = "Prof. Jignesh",
                    ProfessorAddress = "JigneshNagar 1234",
                    ProfessorAge = 46,
                    Salary = 55000.00,
                    DepartmentId = 10
                }
            );
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    StudentName = "Prasad",
                    Age = 18,
                    StudentAddress = "Prakash Nagar 2589",
                    StudentMarks = 980,
                    DepartmentId = 1
                }, 
                new Student
                {
                    StudentId = 2,
                    StudentName = "Aras",
                    Age = 19,
                    StudentAddress = "Prakash Nagar 2589",
                    StudentMarks = 680,
                    DepartmentId = 1
                },
                new Student
                {
                    StudentId = 3,
                    StudentName = "Anubhab",
                    Age = 16,
                    StudentAddress = "Prakash Nagar 2589",
                    StudentMarks = 520,
                    DepartmentId = 2
                },
                new Student
                {
                    StudentId = 4,
                    StudentName = "Pranab",
                    Age = 17,
                    StudentAddress = "Prakash Nagar 2589",
                    StudentMarks = 750,
                    DepartmentId = 2
                },
                new Student
                {
                    StudentId = 5,
                    StudentName = "Amit",
                    Age = 20,
                    StudentAddress = "Some Address",
                    StudentMarks = 850,
                    DepartmentId = 3
                },
                new Student
                {
                    StudentId = 6,
                    StudentName = "Sara",
                    Age = 18,
                    StudentAddress = "Another Address",
                    StudentMarks = 720,
                    DepartmentId = 3
                },
                new Student
                {
                    StudentId = 7,
                    StudentName = "Rahul",
                    Age = 21,
                    StudentAddress = "Yet Another Address",
                    StudentMarks = 920,
                    DepartmentId = 4
                },
                new Student
                {
                    StudentId = 8,
                    StudentName = "Neha",
                    Age = 22,
                    StudentAddress = "One More Address",
                    StudentMarks = 630,
                    DepartmentId = 4
                },
                new Student
                {
                    StudentId = 9,
                    StudentName = "Sandeep",
                    Age = 19,
                    StudentAddress = "Sunset Avenue",
                    StudentMarks = 200,
                    DepartmentId = 5
                },
                new Student
                {
                    StudentId = 10,
                    StudentName = "Monica",
                    Age = 20,
                    StudentAddress = "Maple Street",
                    StudentMarks = 720,
                    DepartmentId = 5
                },
                new Student
                {
                    StudentId = 11,
                    StudentName = "Rajesh",
                    Age = 18,
                    StudentAddress = "Greenfield Road",
                    StudentMarks = 190,
                    DepartmentId = 6
                },
                new Student
                {
                    StudentId = 12,
                    StudentName = "Pooja",
                    Age = 21,
                    StudentAddress = "Cypress Lane",
                    StudentMarks = 670,
                    DepartmentId = 6
                },
                new Student
                {
                    StudentId = 13,
                    StudentName = "Vinay",
                    Age = 22,
                    StudentAddress = "Oak Street",
                    StudentMarks = 950,
                    DepartmentId = 7
                },
                new Student
                {
                    StudentId = 14,
                    StudentName = "Aisha",
                    Age = 19,
                    StudentAddress = "Cedar Avenue",
                    StudentMarks = 820,
                    DepartmentId = 7
                },
                new Student
                {
                    StudentId = 15,
                    StudentName = "Rakesh",
                    Age = 20,
                    StudentAddress = "Pine Road",
                    StudentMarks = 890,
                    DepartmentId = 7
                },
                new Student
                {
                    StudentId = 16,
                    StudentName = "Nina",
                    Age = 21,
                    StudentAddress = "Birch Lane",
                    StudentMarks = 750,
                    DepartmentId = 8
                },
                new Student
                {
                    StudentId = 17,
                    StudentName = "Kiran",
                    Age = 18,
                    StudentAddress = "Redwood Boulevard",
                    StudentMarks = 910,
                    DepartmentId = 8
                },
                new Student
                {
                    StudentId = 18,
                    StudentName = "Aditi",
                    Age = 22,
                    StudentAddress = "Fir Street",
                    StudentMarks = 680,
                    DepartmentId = 9
                },
                new Student
                {
                    StudentId = 19,
                    StudentName = "Suman",
                    Age = 20,
                    StudentAddress = "Willow Lane",
                    StudentMarks = 870,
                    DepartmentId = 9
                },
                new Student
                {
                    StudentId = 20,
                    StudentName = "Vikas",
                    Age = 21,
                    StudentAddress = "Magnolia Street",
                    StudentMarks = 720,
                    DepartmentId = 9
                },
                new Student
                {
                    StudentId = 21,
                    StudentName = "Nisha",
                    Age = 19,
                    StudentAddress = "Cherry Avenue",
                    StudentMarks = 930,
                    DepartmentId = 10
                },
                new Student
                {
                    StudentId = 22,
                    StudentName = "Rohit",
                    Age = 22,
                    StudentAddress = "Chestnut Road",
                    StudentMarks = 690,
                    DepartmentId = 10
                }
            );
        }
    }
}

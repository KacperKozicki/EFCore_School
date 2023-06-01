using EFCore_School.Models;
using EFCore_School.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EFCore_School
{
    internal class Program
    {
        
        static async Task Main(string[] args)
        {
            //Student s1 = new() { Id=1,FirstName="aaaa",LastName="aaaaa"};
            // Student s2 = new() { Id = 2, FirstName = "ssss", LastName = "ssss" };

            // Course c1 = new Course() { Id=1,Title="Matma"};
            // Course c2 = new Course() { Id = 2, Title = "Algorytmy" };


            // c1.Studencts = new List<Student>();
            // c2.Studencts = new HashSet<Student>();


            // s1.Courses = new LinkedList<Course>();
            // s1.Courses.Add(c1); c1.Studencts.Add(s1);
            // s1.Courses.Add(c2); c2.Studencts.Add(s1);

            // foreach (var s in s1.Courses)
            // {
            //     Console.WriteLine(s.Title);
            // }
            using (SchoolContext school = new())
            {
                bool deleted = await school.Database.EnsureDeletedAsync();
                Console.WriteLine($"Baza skasowana: {deleted}");

                bool created = await school.Database.EnsureCreatedAsync();
                Console.WriteLine($"Baza utworzona: {created}");

                string sqlScript = school.Database.GenerateCreateScript();
                Console.WriteLine(sqlScript);

            }



        }
    }
}
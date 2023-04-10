using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EKundalik.Domain.Models;
using EKundalik.Infrastructure.Persistence;

namespace EKundalik.Application.Handler
{
    public class GradeCommandHandler : IRepository<Grade>
    {
        private readonly DbContext dbContext = new();

        public async Task AddAsync(Grade obj)
        {
            await dbContext.Grades.AddAsync(obj);
        }

        public async Task AddRangeAsync(List<Grade> obj)
        {
            await dbContext.Grades.AddRangeAsync(obj);
        }

        public async Task DeleteAsync(int id)
        {
            await dbContext.Grades.DeleteAsync(id);
        }

        public async Task<IEnumerable<Grade>> GetAllAsync()
        {
            return await dbContext.Grades.GetAllAsync();
        }

        public async Task<Grade> GetByIdAsync(int id)
        {
            return await dbContext.Grades.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Grade entity)
        {
            return await dbContext.Grades.UpdateAsync(entity);
        }

        public async Task<Grade> CreateNewGradeFromConsole()
        {
            StudentTeacherCommandHandler stHendler = new StudentTeacherCommandHandler();

            Console.WriteLine("Please enter the student-teacher ID:");
            int studentTeacherId = Convert.ToInt32(Console.ReadLine());
            StudentTeacher studentTeacher = await stHendler.GetByIdAsync(studentTeacherId);

            Console.WriteLine("Please enter the grade (0-100):");
            int grade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the date (YYYY-MM-DD):");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Grade newGrade = new Grade
            {
                StudentTeacher = studentTeacher,
                GradeEnum = grade,
                Date = date
            };

            return newGrade;
        }

        public async Task<List<Grade>> CreateNewGradesFromConsole()
        {
            List<Grade> grades = new List<Grade>();

            StudentTeacherCommandHandler stHandler = new StudentTeacherCommandHandler();

            Console.WriteLine("How many grades do you want to create?");
            int numGrades = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numGrades; i++)
            {
                Console.WriteLine($"\nCreating grade {i + 1}:");
                Console.WriteLine("Please enter the student-teacher ID:");
                int studentTeacherId = Convert.ToInt32(Console.ReadLine());
                StudentTeacher studentTeacher = await stHandler.GetByIdAsync(studentTeacherId);

                Console.WriteLine("Please enter the grade (0-100):");
                int grade = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter the date (YYYY-MM-DD):");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Grade newGrade = new Grade
                {
                    StudentTeacher = studentTeacher,
                    GradeEnum = grade,
                    Date = date
                };

                grades.Add(newGrade);
            }

            return grades;
        }
    }
}

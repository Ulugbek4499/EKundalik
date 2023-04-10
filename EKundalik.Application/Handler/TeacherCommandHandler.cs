using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EKundalik.Domain.Models;
using EKundalik.Infrastructure.Persistence;

namespace EKundalik.Application.Handler
{
    public class TeacherCommandHandler:IRepository<Teacher>
    {
        private readonly DbContext dbContext = new();

        public async Task AddAsync(Teacher obj)
        {
            await dbContext.Teachers.AddAsync(obj);
        }

        public async Task AddRangeAsync(List<Teacher> obj)
        {
            await dbContext.Teachers.AddRangeAsync(obj);
        }

        public async Task DeleteAsync(int id)
        {
            await dbContext.Teachers.DeleteAsync(id);
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await dbContext.Teachers.GetAllAsync();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await dbContext.Teachers.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Teacher entity)
        {
            return await dbContext.Teachers.UpdateAsync(entity);
        }
     
        public Teacher CreateNewTeacherFromConsole()
        {
            Console.WriteLine("Please enter the teacher's full name:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Please enter the teacher's birth date (YYYY-MM-DD):");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the teacher's gender (M/F):");
            string genderInput = Console.ReadLine();
            bool gender = (genderInput.ToLower() == "m");

            Console.WriteLine("Please enter the teacher's ID number:");
            int teacherId = Convert.ToInt32(Console.ReadLine());

            Teacher newTeacher = new Teacher
            {
                FullName = fullName,
                BirthDate = birthDate,
                Gender = gender,
                TeacherId = teacherId
            };

            return newTeacher;
        }

        public List<Teacher> CreateMultipleTeachersFromConsole()
        {
            Console.WriteLine("How many teachers would you like to create?");
            int numTeachers = Convert.ToInt32(Console.ReadLine());

            List<Teacher> teachers = new List<Teacher>();

            for (int i = 1; i <= numTeachers; i++)
            {
                Console.WriteLine($"Please enter information for teacher #{i}:");

                Console.WriteLine("Please enter the teacher's full name:");
                string fullName = Console.ReadLine();

                Console.WriteLine("Please enter the teacher's birth date (YYYY-MM-DD):");
                DateTime birthDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Please enter the teacher's gender (M/F):");
                string genderInput = Console.ReadLine();
                bool gender = (genderInput.ToLower() == "m");

                Console.WriteLine("Please enter the teacher's ID number:");
                int teacherId = Convert.ToInt32(Console.ReadLine());

                Teacher newTeacher = new Teacher
                {
                    FullName = fullName,
                    BirthDate = birthDate,
                    Gender = gender,
                    TeacherId = teacherId
                };

                teachers.Add(newTeacher);
            }

            return teachers;
        }
    }
}

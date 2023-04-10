using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EKundalik.Domain.Models;
using EKundalik.Infrastructure.Persistence;

namespace EKundalik.Application.Handler
{
    public class StudentCommanHandler : IRepository<Student>
    {
        private readonly DbContext dbContext = new();

        public async Task AddAsync(Student obj)
        {
            await dbContext.Students.AddAsync(obj);
        }

        public async Task AddRangeAsync(List<Student> obj)
        {
            await dbContext.Students.AddRangeAsync(obj);
        }

        public async Task DeleteAsync(int id)
        {
            await dbContext.Students.DeleteAsync(id);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await dbContext.Students.GetAllAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await dbContext.Students.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Student entity)
        {
            return await dbContext.Students.UpdateAsync(entity);
        }

        public Student CreateNewStudentFromConsole()
        {
            Console.WriteLine("Please enter the student's full name:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Please enter the student's birth date (YYYY-MM-DD):");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the student's gender (M/F):");
            string genderInput = Console.ReadLine();
            bool gender = (genderInput.ToLower() == "m");

            Console.WriteLine("Please enter the student's ID number:");
            int studentId = Convert.ToInt32(Console.ReadLine());

            Student newStudent = new Student
            {
                FullName = fullName,
                BirthDate = birthDate,
                Gender = gender,
                StudentId = studentId
            };

            return newStudent;
        }

        public List<Student> CreateMultipleStudentsFromConsole()
        {
            Console.WriteLine("How many students would you like to create?");
            int numStudents = Convert.ToInt32(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 1; i <= numStudents; i++)
            {
                Console.WriteLine($"Please enter information for student #{i}:");

                Console.WriteLine("Please enter the student's full name:");
                string fullName = Console.ReadLine();

                Console.WriteLine("Please enter the student's birth date (YYYY-MM-DD):");
                DateTime birthDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Please enter the student's gender (M/F):");
                string genderInput = Console.ReadLine();
                bool gender = (genderInput.ToLower() == "m");

                Console.WriteLine("Please enter the student's ID number:");
                int studentId = Convert.ToInt32(Console.ReadLine());

                Student newStudent = new Student
                {
                    FullName = fullName,
                    BirthDate = birthDate,
                    Gender = gender,
                    StudentId = studentId
                };

                students.Add(newStudent);
            }

            return students;
        }
    }
}

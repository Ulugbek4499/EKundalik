using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EKundalik.Domain.Models;
using EKundalik.Infrastructure.Persistence;

namespace EKundalik.Application.Handler
{
    public class SubjectCommandHandler : IRepository<Subject>
    {
        private readonly DbContext dbContext = new();

        public async Task AddAsync(Subject obj)
        {
            await dbContext.Subjects.AddAsync(obj);
        }

        public async Task AddRangeAsync(List<Subject> obj)
        {
            await dbContext.Subjects.AddRangeAsync(obj);
        }

        public async Task DeleteAsync(int id)
        {
            await dbContext.Subjects.DeleteAsync(id);
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await dbContext.Subjects.GetAllAsync();
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            return await dbContext.Subjects.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Subject entity)
        {
            return await dbContext.Subjects.UpdateAsync(entity);
        }
        
        public Subject CreateNewSubjectFromConsole()
        {
            Console.WriteLine("Please enter the subject name:");
            string subjectName = Console.ReadLine();

            Console.WriteLine("Please enter the subject ID:");
            int subjectId = Convert.ToInt32(Console.ReadLine());

            Subject newSubject = new Subject
            {
                SubjectId = subjectId,
                SubjectName = subjectName
            };

            return newSubject;
        }
        
        public List<Subject> CreateNewSubjectsFromConsole()
        {
            Console.WriteLine("Please enter the number of subjects:");
            int numSubjects = Convert.ToInt32(Console.ReadLine());

            List<Subject> subjects = new List<Subject>();

            for (int i = 0; i < numSubjects; i++)
            {
                Console.WriteLine($"Please enter the details for subject #{i + 1}:");

                Console.WriteLine("Please enter the subject name:");
                string subjectName = Console.ReadLine();

                Console.WriteLine("Please enter the subject ID:");
                int subjectId = Convert.ToInt32(Console.ReadLine());

                Subject newSubject = new Subject
                {
                    SubjectId = subjectId,
                    SubjectName = subjectName
                };

                subjects.Add(newSubject);
            }

            return subjects;
        }
    }
}

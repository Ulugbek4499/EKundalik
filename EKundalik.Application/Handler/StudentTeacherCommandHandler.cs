using EKundalik.Domain.Models;
using EKundalik.Infrastructure.Persistence;

namespace EKundalik.Application.Handler
{
    public class StudentTeacherCommandHandler : IRepository<StudentTeacher>
    {
        private readonly DbContext dbContext = new();

        public async Task AddAsync(StudentTeacher obj)=>
            await dbContext.StudentTeachers.AddAsync(obj);
        
        public async Task AddRangeAsync(List<StudentTeacher> obj)=>
            await dbContext.StudentTeachers.AddRangeAsync(obj);
      
        public async Task DeleteAsync(int id)=>
            await dbContext.StudentTeachers.DeleteAsync(id);

        public async Task<IEnumerable<StudentTeacher>> GetAllAsync()
        {
            return await dbContext.StudentTeachers.GetAllAsync();
        }

        public async Task<StudentTeacher> GetByIdAsync(int id)
        {
            return await dbContext.StudentTeachers.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(StudentTeacher entity)
        {
            return await dbContext.StudentTeachers.UpdateAsync(entity);
        }
        
        public async Task<StudentTeacher> CreateNewStudentTeacherFromConsole()
        {
            StudentCommanHandler stHendler= new StudentCommanHandler();
            TeacherCommandHandler tHendeler= new TeacherCommandHandler();
            SubjectCommandHandler subHendler= new SubjectCommandHandler();

            Console.WriteLine("Please enter the student ID:");
            int studentId = Convert.ToInt32(Console.ReadLine());
            Student student = await stHendler.GetByIdAsync(studentId);

            Console.WriteLine("Please enter the teacher ID:");
            int teacherId = Convert.ToInt32(Console.ReadLine());
            Teacher teacher = await tHendeler.GetByIdAsync(teacherId);

            Console.WriteLine("Please enter the subject ID:");
            int subjectId = Convert.ToInt32(Console.ReadLine());
            Subject subject = await subHendler.GetByIdAsync(subjectId);

            StudentTeacher newStudentTeacher = new StudentTeacher
            {
                Student = student,
                Teacher = teacher,
                Subject = subject
            };

            return newStudentTeacher;
        }

        public async Task<List<StudentTeacher>> CreateStudentTeacherListFromConsole()
        {
            StudentCommanHandler stHendler = new StudentCommanHandler();
            TeacherCommandHandler tHendeler = new TeacherCommandHandler();
            SubjectCommandHandler subHendler = new SubjectCommandHandler();

            Console.WriteLine("How many student-teacher pairs do you want to create?");
            int numStudentTeachers = Convert.ToInt32(Console.ReadLine());

            List<StudentTeacher> studentTeachers = new List<StudentTeacher>();

            for (int i = 0; i < numStudentTeachers; i++)
            {
                Console.WriteLine($"Creating student-teacher pair {i + 1} of {numStudentTeachers}");

                Console.WriteLine("Please enter the student ID:");
                int studentId = Convert.ToInt32(Console.ReadLine());
                Student student = await stHendler.GetByIdAsync(studentId);

                Console.WriteLine("Please enter the teacher ID:");
                int teacherId = Convert.ToInt32(Console.ReadLine());
                Teacher teacher = await tHendeler.GetByIdAsync(teacherId);

                Console.WriteLine("Please enter the subject ID:");
                int subjectId = Convert.ToInt32(Console.ReadLine());
                Subject subject = await subHendler.GetByIdAsync(subjectId);

                StudentTeacher newStudentTeacher = new StudentTeacher
                {
                    Student = student,
                    Teacher = teacher,
                    Subject = subject
                };

                studentTeachers.Add(newStudentTeacher);
            }

            return studentTeachers;
        }
    }
}

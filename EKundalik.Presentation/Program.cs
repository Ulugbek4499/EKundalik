using EKundalik.Application.Handler;
using EKundalik.Domain.Models;
using EKundalik.Infrastructure.Persistence;

namespace EKundalik.Presentation
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            DbContext db = new DbContext();
            db.CreateDb();

            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Which class do you want to work with?");
                    Console.WriteLine("1. Student");
                    Console.WriteLine("2. Teacher");
                    Console.WriteLine("3. Subject");
                    Console.WriteLine("4. Grade");
                    Console.WriteLine("5. StudentTeacher");
                    Console.WriteLine("6. Exit");

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            await StudentOperations();
                            break;
                        case "2":
                            await TeacherOperations();
                            break;
                        case "3":
                            await SubjectOperations();
                            break;
                        case "4":
                            await GradeOperations();
                            break;
                        case "5":
                            await StudentTeacherOperations();
                            break;
                        case "6":
                            return;
                        default:
                            Console.WriteLine("Invalid input, please try again.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        static async Task StudentOperations()
        {
            StudentCommanHandler studentHandler= new StudentCommanHandler();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What operation do you want to perform?");
                Console.WriteLine("1. Add a student");
                Console.WriteLine("2. Add multiple students");
                Console.WriteLine("3. Get all students");
                Console.WriteLine("4. Get student by ID");
                Console.WriteLine("5. Update a student");
                Console.WriteLine("6. Delete a student");
                Console.WriteLine("7. Back to main menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Student newStudent = studentHandler.CreateNewStudentFromConsole();
                        await studentHandler.AddAsync(newStudent);
                        Console.ReadKey();
                        break;

                    case "2":
                        List<Student> myList= studentHandler.CreateMultipleStudentsFromConsole();
                        await studentHandler.AddRangeAsync(myList);
                        Console.ReadKey();
                        break;

                    case "3":
                        List<Student> result = (List<Student>)await studentHandler.GetAllAsync();

                        foreach (var item in result)
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.WriteLine("Enter grade ID:");
                        int num= int.Parse(Console.ReadLine());
                        Student myStudent=await studentHandler.GetByIdAsync(num);
                        Console.WriteLine(myStudent);
                        Console.ReadKey();
                        break;
                   
                    case "5":
                        Console.WriteLine("Enter old id number and you can enter other updated info");
                        Student myStudent1 = studentHandler.CreateNewStudentFromConsole();
                        await studentHandler.UpdateAsync(myStudent1);
                        Console.ReadKey();
                        break;
                   
                    case "6":
                        Console.WriteLine("Enter student ID to delete:");
                        int number = int.Parse(Console.ReadLine());
                        await studentHandler.DeleteAsync(number);
                        Console.ReadKey();
                        break;
                   
                    case "7":
                        return;
                   
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        static async Task TeacherOperations()
        {
            TeacherCommandHandler teacherHandler = new TeacherCommandHandler();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What operation do you want to perform?");
                Console.WriteLine("1. Add a teacher");
                Console.WriteLine("2. Add multiple teachers");
                Console.WriteLine("3. Get all teachers");
                Console.WriteLine("4. Get teacher by ID");
                Console.WriteLine("5. Update a teacher");
                Console.WriteLine("6. Delete a teacher");
                Console.WriteLine("7. Back to main menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Teacher newTeacher = teacherHandler.CreateNewTeacherFromConsole();
                        await teacherHandler.AddAsync(newTeacher);
                        Console.ReadKey();
                        break;

                    case "2":
                        List<Teacher> myList = teacherHandler.CreateMultipleTeachersFromConsole();
                        await teacherHandler.AddRangeAsync(myList);
                        Console.ReadKey();
                        break;

                    case "3":
                        List<Teacher> result = (List<Teacher>)await teacherHandler.GetAllAsync();

                        foreach (var item in result)
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.WriteLine("Enter grade ID:");
                        int num = int.Parse(Console.ReadLine());
                        Teacher myTeacher = await teacherHandler.GetByIdAsync(num);
                        Console.WriteLine(myTeacher);
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.WriteLine("Enter old id number and you can enter other updated info");
                        Teacher myTeacher1 = teacherHandler.CreateNewTeacherFromConsole();
                        await teacherHandler.UpdateAsync(myTeacher1);
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.WriteLine("Enter teacher ID to delete:");
                        int number = int.Parse(Console.ReadLine());
                        await teacherHandler.DeleteAsync(number);
                        Console.ReadKey();
                        break;

                    case "7":
                        return;

                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        static async Task SubjectOperations()
        {
            SubjectCommandHandler subjectHandler=new SubjectCommandHandler();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What operation do you want to perform?");
                Console.WriteLine("1. Add a subject");
                Console.WriteLine("2. Add multiple subjects");
                Console.WriteLine("3. Get all subjects");
                Console.WriteLine("4. Get subject by ID");
                Console.WriteLine("5. Update a subject");
                Console.WriteLine("6. Delete a subject");
                Console.WriteLine("7. Back to main menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Subject newSubject = subjectHandler.CreateNewSubjectFromConsole();
                        await subjectHandler.AddAsync(newSubject);
                        Console.ReadKey();
                        break;

                    case "2":
                        List<Subject> myList = subjectHandler.CreateNewSubjectsFromConsole();
                        await subjectHandler.AddRangeAsync(myList);
                        Console.ReadKey();
                        break;

                    case "3":
                        List<Subject> result = (List<Subject>)await subjectHandler.GetAllAsync();

                        foreach (var item in result)
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.WriteLine("Enter subject ID:");
                        int num = int.Parse(Console.ReadLine());
                        Subject mySubject = await subjectHandler.GetByIdAsync(num);
                        Console.WriteLine(mySubject);
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.WriteLine("Enter old id number and you can enter other updated info");
                        Subject mySubject1 = subjectHandler.CreateNewSubjectFromConsole();
                        await subjectHandler.UpdateAsync(mySubject1);
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.WriteLine("Enter subject ID to delete:");
                        int number = int.Parse(Console.ReadLine());
                        await subjectHandler.DeleteAsync(number);
                        Console.ReadKey();
                        break;

                    case "7":
                        return;

                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        static async Task GradeOperations()
        {
            GradeCommandHandler gradeHandler = new GradeCommandHandler();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What operation do you want to perform?");
                Console.WriteLine("1. Add a grade");
                Console.WriteLine("2. Add multiple grades");
                Console.WriteLine("3. Get all grades");
                Console.WriteLine("4. Get grade by ID");
                Console.WriteLine("5. Update a grade");
                Console.WriteLine("6. Delete a grade");
                Console.WriteLine("7. Back to main menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Grade newGrade = await gradeHandler.CreateNewGradeFromConsole();
                        await gradeHandler.AddAsync(newGrade);
                        Console.ReadKey();
                        break;

                    case "2":
                        List<Grade> myGrade = await gradeHandler.CreateNewGradesFromConsole();
                        await gradeHandler.AddRangeAsync(myGrade);
                        Console.ReadKey();
                        break;

                    case "3":
                        List<Grade> result = (List<Grade>)await gradeHandler.GetAllAsync();

                        foreach (var item in result)
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.WriteLine("Enter grade ID:");
                        int num = int.Parse(Console.ReadLine());
                        Grade myGrade1 = await gradeHandler.GetByIdAsync(num);
                        Console.WriteLine(myGrade1);
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.WriteLine("Enter old id number and you can enter other updated info");
                        Grade myGrade2 = await gradeHandler.CreateNewGradeFromConsole();
                        await gradeHandler.UpdateAsync(myGrade2);
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.WriteLine("Enter grade ID to delete:");
                        int number = int.Parse(Console.ReadLine());
                        await gradeHandler.DeleteAsync(number);
                        Console.ReadKey();
                        break;

                    case "7":
                        return;

                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        static async Task StudentTeacherOperations()
        {
            StudentTeacherCommandHandler stHandler = new StudentTeacherCommandHandler();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What operation do you want to perform?");
                Console.WriteLine("1. Add a Student-Teacher pair");
                Console.WriteLine("2. Add multiple Student-Teacher pairs");
                Console.WriteLine("3. Get all Student-Teacher pairs");
                Console.WriteLine("4. Get Student-Teacher pair by ID");
                Console.WriteLine("5. Update a Student-Teacher pair");
                Console.WriteLine("6. Delete a Student-Teacher pair");
                Console.WriteLine("7. Back to main menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        StudentTeacher newStudent_Teacher = await stHandler.CreateNewStudentTeacherFromConsole();
                        await stHandler.AddAsync(newStudent_Teacher);
                        Console.ReadKey();
                        break;

                    case "2":
                        List<StudentTeacher> myList = await stHandler.CreateStudentTeacherListFromConsole();
                        await stHandler.AddRangeAsync(myList);
                        Console.ReadKey();
                        break;

                    case "3":
                        List<StudentTeacher> result = (List<StudentTeacher>)await stHandler.GetAllAsync();

                        foreach (var item in result)
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.WriteLine("Enter subject ID:");
                        int num = int.Parse(Console.ReadLine());
                        StudentTeacher myStudentTeacher = await stHandler.GetByIdAsync(num);
                        Console.WriteLine(myStudentTeacher);
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.WriteLine("Enter old id number and you can enter other updated info");
                        StudentTeacher myStudentTeacher1 = await stHandler.CreateNewStudentTeacherFromConsole();
                        await stHandler.UpdateAsync(myStudentTeacher1);
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.WriteLine("Enter subject ID to delete:");
                        int number = int.Parse(Console.ReadLine());
                        await stHandler.DeleteAsync(number);
                        Console.ReadKey();
                        break;

                    case "7":
                        return;

                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

    }

}
/*
int max = result.Max(x => x.FullName.Length);
Teacher? teacher = result.FirstOrDefault(x => x.FullName.Length == max);*/
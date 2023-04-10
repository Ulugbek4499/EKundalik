using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Dapper;
using EKundalik.Domain.Models;
using Npgsql;

namespace EKundalik.Infrastructure.Persistence
{
    public class DbStudentTeacher : IRepository<StudentTeacher>
    {
        public static string connectionString = File.ReadAllText(@"..\..\..\..\EKundalik.Infrastructure\Appconfig.txt");

        public async Task AddAsync(StudentTeacher studentTeacher)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string cmdText = @"INSERT INTO student_teacher(student_id, teacher_id,subject_id)
                            VALUES (@st_id, @t_id, @sb_id)";
            
            NpgsqlCommand cmd=new NpgsqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@st_id", studentTeacher.Student.StudentId);
            cmd.Parameters.AddWithValue("@t_id", studentTeacher.Teacher.TeacherId);
            cmd.Parameters.AddWithValue("@sb_id", studentTeacher.Subject.SubjectId);

            int rowAffected = await cmd.ExecuteNonQueryAsync();
            if (rowAffected > 0)
                Console.WriteLine($"Added successfully.");
            else
                Console.WriteLine($"Add row failed.");
        }

        public async Task AddRangeAsync(List<StudentTeacher> obj)
        {
            foreach (StudentTeacher objItem in obj)
            {
                await AddAsync(objItem);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
          
            string cmdText = @"delete from student_teacher where id = @id";
            NpgsqlCommand cmd = new NpgsqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);
            int rowAffected = await cmd.ExecuteNonQueryAsync();
            
            if (rowAffected > 0)
                 Console.WriteLine("Deleted succesfully");
            else 
                Console.WriteLine("Delete row faild");
        }

        public async Task<IEnumerable<StudentTeacher>> GetAllAsync()
        {
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string cmdText = @"SELECT * FROM student_teacher";
            NpgsqlCommand cmd = new NpgsqlCommand(cmdText, connection);
            NpgsqlDataReader reader= await cmd.ExecuteReaderAsync();
            ICollection<StudentTeacher> studentTeachers = new List<StudentTeacher>();

            while (reader.Read())
            {
                studentTeachers.Add(new()
                {
                    Id = (int)reader["id"],
                    Student = await new DbStudent().GetByIdAsync((int)reader["student_id"]),
                    Teacher = await new DbTeacher().GetByIdAsync((int)reader["teacher_id"]),
                    Subject = await new DbSubject().GetByIdAsync((int)reader["subject_id"])
                });

            }
            return studentTeachers;            
        }

        public async Task<StudentTeacher> GetByIdAsync(int id)
        {

            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            string cmdText = @"select * from student_teacher where id=@id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

            StudentTeacher student_teachers = null;
            while (reader.Read())
            {
                student_teachers = new()
                {
                    Id = (int)reader["id"],
                    Student = await new DbStudent().GetByIdAsync((int)reader["student_id"]),
                    Teacher = await new DbTeacher().GetByIdAsync((int)reader["teacher_id"]),
                    Subject = await new DbSubject().GetByIdAsync((int)reader["subject_id"])
                };
            }           

            return student_teachers;
        }

        public async Task<bool> UpdateAsync(StudentTeacher entity)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            string cmdText = @"update student_teacher set 
                               student_id=@st_id,
                               teacher_id=@t_id,
                               subject_id=@sb_id
                               where id = @id;";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@st_id", entity.Student.StudentId);
            cmd.Parameters.AddWithValue("@t_id", entity.Teacher.TeacherId);
            cmd.Parameters.AddWithValue("@sb_id", entity.Subject.SubjectId);
            cmd.Parameters.AddWithValue("@id", entity.Id);

            int res = await cmd.ExecuteNonQueryAsync();
            if (res > 0)
            {
                Console.WriteLine("Updated succesfully");
                return true;
            }
            Console.WriteLine("Update row failed");
            return false;
        }
    }
}

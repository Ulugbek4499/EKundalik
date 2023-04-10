using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EKundalik.Domain.Models;
using Npgsql;

namespace EKundalik.Infrastructure.Persistence
{
    public class DbGrade:IRepository<Grade>
    {
        public static string connectionString = File.ReadAllText(@"..\..\..\..\EKundalik.Infrastructure\Appconfig.txt");

        public async Task AddAsync(Grade grade)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            string cmdText = @"insert into grade(grade_rate,grade_date, student_teacher_id) 
                    values (@rate, @grade_date, @studentTeacherId)";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@rate", grade.GradeEnum);
            cmd.Parameters.AddWithValue("@grade_date", grade.Date);
            cmd.Parameters.AddWithValue("@student_teacher_id", grade.StudentTeacher.Id);

            int rowsAffected = await cmd.ExecuteNonQueryAsync();

            if (rowsAffected > 0)
                Console.WriteLine($"Added successfully.");
            else
                Console.WriteLine($"Add row failed.");
        }

        public async Task AddRangeAsync(List<Grade> obj)
        {
            foreach (Grade grade in obj)
            {
               await AddAsync(grade);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();

            string cmdText = @"delete from grade where grade_id=@id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            int rowAffected = await cmd.ExecuteNonQueryAsync();
            if (rowAffected > 0)
                Console.WriteLine("Deleted successfully!");
            else
                Console.WriteLine("Delete row failed!");
        }

        public async Task<IEnumerable<Grade>> GetAllAsync()
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            string cmdText = @"select * from grade";
            NpgsqlCommand cmd = new(cmdText, connection);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            ICollection<Grade> grades = new List<Grade>();
            while (reader.Read())
            {
                grades.Add(new()
                {
                    GradeId = (int)reader["grade_id"],
                    GradeEnum =(int)reader["grade_rate"],
                    StudentTeacher = (StudentTeacher)reader["student_teacher_id"],
                    Date = (DateTime)reader["grade_date"]
                });
            }
            return grades;
        }

        public async Task<Grade> GetByIdAsync(int id)
        {
            using NpgsqlConnection connection = new(connectionString);
            await connection.OpenAsync();
            string cmdText = @"select * from grade where grade_id=@id";
            using NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            using NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                Grade grade = new()
                {
                    GradeId = (int)reader["grade_id"],
                    GradeEnum =(int)reader["grade_rate"],
                    StudentTeacher = (StudentTeacher)reader["student_teacher_id"],
                    Date = (DateTime)reader["grade_date"]
                };
                return grade;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(Grade entity)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            string cmdText = @"update grade set grade_rate=@grade_rate, grade_date=@grade_date, student_teacher_id=@student_teacher_id
                               where teacher_id = @id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@grade_rate", entity.GradeEnum);
            cmd.Parameters.AddWithValue("@grade_date", entity.Date);
            cmd.Parameters.AddWithValue("@student_teacher_id", entity.StudentTeacher.Id);

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

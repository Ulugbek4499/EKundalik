using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Dapper;
using EKundalik.Domain.Models;
using Npgsql;

namespace EKundalik.Infrastructure.Persistence
{
    public class DbStudent : IRepository<Student>
    {
        public static string connectionString = File.ReadAllText(@"..\..\..\..\EKundalik.Infrastructure\Appconfig.txt");

        public async Task AddAsync(Student student)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            string cmdText = @"insert into student(student_name,birth_date, gender) 
                    values (@name, @birth_date, @gender)";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@name", student.FullName);
            cmd.Parameters.AddWithValue("@birth_date", student.BirthDate);
            cmd.Parameters.AddWithValue("@gender", student.Gender);

            int rowsAffected = await cmd.ExecuteNonQueryAsync();

            if (rowsAffected > 0)
                Console.WriteLine($"Added successfully.");
            else
                Console.WriteLine($"Add row failed.");
        }

        public async Task AddRangeAsync(List<Student> students)
        {
            foreach (Student student in students)
            {
                await AddAsync(student);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();

            string cmdText = @"delete from student where student_id=@id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            int rowAffected = await cmd.ExecuteNonQueryAsync();
            if (rowAffected > 0)
                Console.WriteLine("Deleted successfully!");
            else
                Console.WriteLine("Delete row failed!");
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            string cmdText = @"select * from student";
            NpgsqlCommand cmd = new(cmdText, connection);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            ICollection<Student> students = new List<Student>();
            while (reader.Read())
            {
                students.Add(new()
                {
                    StudentId = (int)reader["student_id"],
                    FullName = reader["student_name"]?.ToString(),
                    BirthDate = DateTime.Parse(reader["birth_date"]?.ToString()),
                    Gender = (bool)reader["gender"]
                });
            }
            return students;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            string cmdText = @"select * from student where student_id=@id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            Student student = null;
            while (reader.Read())
            {
                student = new()
                {
                    StudentId = (int)reader["student_id"],
                    FullName = reader["student_name"]?.ToString(),
                    BirthDate = DateTime.Parse(reader["birth_date"]?.ToString()),
                    Gender = (bool)reader["gender"]
                };
            }
            return student;
        }

        public async Task<bool> UpdateAsync(Student entity)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            string cmdText = @"update student set student_name=@name, birth_date=@birth_date, gender=@gender
                               where student_id = @id;";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@name", entity.FullName);
            cmd.Parameters.AddWithValue("@birth_date", entity.BirthDate);
            cmd.Parameters.AddWithValue("@gender", entity.Gender);
            cmd.Parameters.AddWithValue("@id", entity.StudentId);

            int res = await cmd.ExecuteNonQueryAsync();
            if (res > 0)
            {
                Console.WriteLine(entity.FullName + " updated succesfully");
                return true;
            }
            Console.WriteLine(entity.FullName + " update failed");
            return false;
        }
    }
}

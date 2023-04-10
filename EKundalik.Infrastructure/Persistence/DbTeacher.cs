using Dapper;
using EKundalik.Domain.Models;
using Npgsql;

namespace EKundalik.Infrastructure.Persistence
{
    public class DbTeacher : IRepository<Teacher>
    {
        public static string connectionString = File.ReadAllText(@"..\..\..\..\EKundalik.Infrastructure\Appconfig.txt");

        public async Task AddAsync(Teacher teacher)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            string cmdText = @"insert into teacher(teacher_name,birth_date, gender) 
                    values (@name, @birth_date, @gender)";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@name", teacher.FullName);
            cmd.Parameters.AddWithValue("@birth_date", teacher.BirthDate);
            cmd.Parameters.AddWithValue("@gender", teacher.Gender);

            int rowsAffected = await cmd.ExecuteNonQueryAsync();

            if (rowsAffected > 0)
                Console.WriteLine($"Added successfully.");
            else
                Console.WriteLine($"Add row failed.");
        }

        public async Task AddRangeAsync(List<Teacher> teachers)
        {
            foreach (Teacher teacher in teachers)
            {
                await AddAsync(teacher);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();

            string cmdText = @"delete from teacher where teacher_id=@id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            int rowAffected = await cmd.ExecuteNonQueryAsync();
            if (rowAffected > 0)
                Console.WriteLine("Deleted successfully!");
            else
                Console.WriteLine("Delete row failed!");
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            string cmdText = @"select * from teacher";
            NpgsqlCommand cmd = new(cmdText, connection);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            ICollection<Teacher> teachers = new List<Teacher>();
            while (reader.Read())
            {
                teachers.Add(new()
                {
                    TeacherId = (int)reader["teacher_id"],
                    FullName = reader["teacher_name"]?.ToString(),
                    BirthDate = DateTime.Parse(reader["birth_date"]?.ToString()),
                    Gender = (bool)reader["gender"]
                });
            }
            return teachers;
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            string cmdText = @"select * from teacher where teacher_id=@id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            Teacher teacher = null;
            while (reader.Read())
            {
                teacher = new()
                {
                    TeacherId = (int)reader["teacher_id"],
                    FullName = reader["teacher_name"]?.ToString(),
                    BirthDate = DateTime.Parse(reader["birth_date"]?.ToString()),
                    Gender = (bool)reader["gender"]
                };
            }
            return teacher;
        }

        public async Task<bool> UpdateAsync(Teacher entity)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            string cmdText = @"update teacher set teacher_name=@name, birth_date=@birth_date, gender=@gender
                               where teacher_id = @id;";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@name", entity.FullName);
            cmd.Parameters.AddWithValue("@birth_date", entity.BirthDate);
            cmd.Parameters.AddWithValue("@gender", entity.Gender);
            cmd.Parameters.AddWithValue("@id", entity.TeacherId);

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

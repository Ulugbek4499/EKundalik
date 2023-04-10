using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EKundalik.Domain.Models;
using Npgsql;

namespace EKundalik.Infrastructure.Persistence
{
    public class DbSubject:IRepository<Subject>
    {
        public static string connectionString = File.ReadAllText(@"..\..\..\..\EKundalik.Infrastructure\Appconfig.txt");

        public async Task AddAsync(Subject subject)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            string cmdText = @"insert into subject (subject_name) 
                    values (@name)";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@name", subject.SubjectName);
           
            int rowsAffected = await cmd.ExecuteNonQueryAsync();

            if (rowsAffected > 0)
                Console.WriteLine($"Added successfully.");
            else
                Console.WriteLine($"Add row failed.");
        }

        public async Task AddRangeAsync(List<Subject> subjects)
        {
            foreach (Subject subject in subjects) 
            {
                await AddAsync(subject);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();

            string cmdText = @"delete from subject where subject_id=@id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);
            int rowAffected = await cmd.ExecuteNonQueryAsync();

            if (rowAffected > 0)
                Console.WriteLine("Deleted successfully!");
            else 
                Console.WriteLine("Delete row failed!");
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            using NpgsqlConnection connection= new NpgsqlConnection(connectionString); 
            connection.Open();
            string cmdText = @"SELECT * FROM subject";
            NpgsqlCommand cmd = new(cmdText, connection);
            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            ICollection<Subject> subjects = new List<Subject>();

            while (reader.Read())
            {
                subjects.Add(new()
                {
                    SubjectId = (int)reader["subject_id"],
                    SubjectName = reader["subject_name"].ToString()
                });
            }
            return subjects;    
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string cmdText = @"SELECT * FROM subject";
            NpgsqlCommand cmd = new(cmdText, connection);
            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            Subject subject = null;

            while (reader.Read())
            {
                subject =new()
                {
                    SubjectId = (int)reader["subject_id"],
                    SubjectName = reader["subject_name"].ToString()
                };
            }
            return subject;
        }

        public async Task<bool> UpdateAsync(Subject entity)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            string cmdText = @"update subject set subject_name=@name
                               where subject_id = @id;";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@name", entity.SubjectName);
            cmd.Parameters.AddWithValue("@id", entity.SubjectId);

            int res = await cmd.ExecuteNonQueryAsync();
            if (res > 0)
            {
                Console.WriteLine(entity.SubjectName + " updated succesfully");
                return true;
            }
            Console.WriteLine(entity.SubjectName + " update failed");
            return false;
        }
    }
}

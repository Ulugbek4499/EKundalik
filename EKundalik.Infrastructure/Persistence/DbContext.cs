using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace EKundalik.Infrastructure.Persistence
{
    public class DbContext
    {
        public static string connectionString = 
            File.ReadAllText(@"..\..\..\..\EKundalik.Infrastructure\Appconfig.txt");

        public void CreateDb()
        {
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                connection.Close();
            }
            catch (NpgsqlException exception)
            {
                if(exception.Message.Contains("does not exist", StringComparison.OrdinalIgnoreCase))
                {
                    string connectionString2 = connectionString.Replace("ekundalik", "postgres");
                    using NpgsqlConnection connection = new(connectionString2);
                    connection.Open();

                    string query = "Create database ekundalik";
                    NpgsqlCommand command = new (query, connection);
                    command.ExecuteNonQuery();

                    CreateTables();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void CreateTables()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = @"CREATE TABLE student
                                (
                                    student_id serial NOT NULL,
                                    student_name character varying(50) NOT NULL,
                                    birth_date date,
                                    gender boolean DEFAULT true,
                                    PRIMARY KEY (student_id)
                                );
                                CREATE TABLE teacher
                                (
                                    teacher_id serial NOT NULL,
                                    teacher_name character varying(50) NOT NULL,
                                    birth_date date,
                                    gender boolean DEFAULT true,
                                    PRIMARY KEY (teacher_id)
                                );
                                CREATE TABLE subject
                                (
                                    subject_id serial NOT NULL,
                                    subject_name character varying(50) NOT NULL,
                                    PRIMARY KEY (subject_id)
                                );
                                CREATE TABLE student_teacher
                                (
                                    id serial NOT NULL,
                                    student_id integer references student(student_id) NOT NULL,
                                    teacher_id integer references teacher(teacher_id) NOT NULL,
                                    subject_id integer references subject(subject_id) NOT NULL,
                                    PRIMARY KEY (id)
                                );
                                CREATE TABLE grade
                                (
                                    grade_id serial NOT NULL,
                                    grade_rate integer NOT NULL,
                                    grade_date date,
                                    student_teacher_id integer references student_teacher(id) NOT NULL,
                                    PRIMARY KEY (grade_id)
                                );";
                connection.Execute(createTableQuery);
            }
        }
        


        public DbStudent Students { get; set; } = new();
        public DbTeacher Teachers { get; set; } = new();    
        public DbGrade Grades { get; set; } = new();    
        public DbSubject Subjects { get; set; }= new();
        public DbStudentTeacher StudentTeachers { get; set; } = new();
    }
}

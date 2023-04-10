using EKundalik.Application.Handler;
using EKundalik.Domain.Models;

namespace EKundalik.UI
{
    public partial class Form1 : Form
    {
        StudentCommanHandler studentHandler = new StudentCommanHandler();
        List<int> updatedrow= new();  
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            student_grid.Columns.Clear();
            student_grid.Visible = true;
            StudentCommanHandler studentHandler = new StudentCommanHandler();
            List<Student> result = (List<Student>)await studentHandler.GetAllAsync();
            //"StudentId:{StudentId}, FullName:{FullName}, BirthDate:{BirthDate}, Gender:{Gender}
            student_grid.Columns.Add("StudentId", "StudentId");
            student_grid.Columns.Add("FullName", "FullName");
            student_grid.Columns.Add("BirthDate", "BirthDate");
            student_grid.Columns["BirthDate"].ValueType = typeof(DateTime);
            student_grid.Columns.Add("Gender", "Gender");
            student_grid.Columns["Gender"].ValueType= typeof(bool);
            student_grid.AllowUserToResizeColumns = true;
            student_grid.AllowUserToOrderColumns = true;

            foreach (var item in result)
            {
                student_grid.Rows.Add(item.StudentId, item.FullName, item.BirthDate, item.Gender);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            student_grid.Columns.Clear();

            List<StudentTeacher> result = (List<StudentTeacher>)await studentHandler.GetAllAsync();
            //"StudentId:{StudentId}, FullName:{FullName}, BirthDate:{BirthDate}, Gender:{Gender}
            student_grid.Columns.Add("Id", "Id");
            student_grid.Columns.Add("Student", "Student");
            student_grid.Columns.Add("Teacher", "Teacher");
            student_grid.Columns.Add("Subject", "Subject");
            student_grid.AllowUserToResizeColumns = true;
            student_grid.AllowUserToOrderColumns = true;
            // $"Id:{Id},\n Student:{Student},\n Teacher:{Teacher},\n Subject:{Subject}";
            foreach (var item in result)
            {
                student_grid.Rows.Add(item.Id, item.Student.FullName, item.Teacher.FullName, item.Subject.SubjectName);
            }
        }

        private async void Grade_Click(object sender, EventArgs e)
        {
            student_grid.Columns.Clear();
            GradeCommandHandler GradeHandler = new GradeCommandHandler();
            List<Grade> result = (List<Grade>)await GradeHandler.GetAllAsync();
            //"StudentId:{StudentId}, FullName:{FullName}, BirthDate:{BirthDate}, Gender:{Gender}
            student_grid.Columns.Add("GradeId", "GradeId");
            student_grid.Columns.Add("StudentTeacher", "StudentTeacherId");
            student_grid.Columns.Add("GradeEnum", "GradeEnum");
            student_grid.Columns.Add("Date", "Date");
            student_grid.AllowUserToResizeColumns = true;
            student_grid.AllowUserToOrderColumns = true;
            //$"GradeId:{GradeId},\n StudentTeacher:{StudentTeacher},\n GradeEnum:{GradeEnum},\n Date:{Date}"
            foreach (var item in result)
            {
                student_grid.Rows.Add(item.GradeId, item.StudentTeacher, item.GradeEnum, item.Date);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void Teacher_Click(object sender, EventArgs e)
        {
            student_grid.Columns.Clear();

            TeacherCommandHandler studentHandler = new TeacherCommandHandler();
            List<Teacher> result = (List<Teacher>)await studentHandler.GetAllAsync();
            //"StudentId:{StudentId}, FullName:{FullName}, BirthDate:{BirthDate}, Gender:{Gender}
            student_grid.Columns.Add("TeacherId", "TeacherId");
            student_grid.Columns.Add("FullName", "FullName");
            student_grid.Columns.Add("BirthDate", "BirthDate");
            student_grid.Columns.Add("Gender", "Gender");
            student_grid.AllowUserToResizeColumns = true;
            student_grid.AllowUserToOrderColumns = true;

            foreach (var item in result)
            {
                student_grid.Rows.Add(item.TeacherId, item.FullName, item.BirthDate, item.Gender);
            }
        }

        private async void Subject_Click_1(object sender, EventArgs e)
        {
            student_grid.Columns.Clear();
            SubjectCommandHandler studentHandler = new SubjectCommandHandler();
            List<Subject> result = (List<Subject>)await studentHandler.GetAllAsync();
            //"StudentId:{StudentId}, FullName:{FullName}, BirthDate:{BirthDate}, Gender:{Gender}
            student_grid.Columns.Add("SubjectId", "SubjectId");
            student_grid.Columns.Add("SubjectName", "SubjectName");
            student_grid.AllowUserToResizeColumns = true;
            student_grid.AllowUserToOrderColumns = true;

            foreach (var item in result)
            {
                student_grid.Rows.Add(item.SubjectId, item.SubjectName); //, item.BirthDate, item.Gender);
            }
        }

        private void student_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var row = student_grid.SelectedRows[0];
            int id = int.Parse(row.Cells[0].Value.ToString());
            await studentHandler.DeleteAsync(id);
            student_grid.Rows.Remove(row);
        }

        private void button5_Click(object sender, EventArgs e)
        {
           updatedrow.Add( student_grid.Rows.Add());
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            List<Student> students = new();

            for (int i = 0; i < updatedrow.Count; i++)
            {
                students.Add( new Student()
                {
                    FullName = student_grid.Rows[updatedrow[i]].Cells[1].Value.ToString(),
                    BirthDate =DateTime.Parse(student_grid.Rows[updatedrow[i]].Cells[2].Value.ToString()),
                    Gender = (bool)student_grid.Rows[updatedrow[i]].Cells["Gender"].Value
                });
            }
           await  studentHandler.AddRangeAsync(students);
            students.Clear();
        }
    }
}
namespace EKundalik.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Student = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            student_grid = new DataGridView();
            button5 = new Button();
            button7 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)student_grid).BeginInit();
            SuspendLayout();
            // 
            // Student
            // 
            Student.BackColor = SystemColors.ActiveBorder;
            Student.FlatStyle = FlatStyle.Flat;
            Student.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point);
            Student.Location = new Point(291, 35);
            Student.Name = "Student";
            Student.Size = new Size(215, 51);
            Student.TabIndex = 0;
            Student.Text = "Student";
            Student.UseVisualStyleBackColor = false;
            Student.Click += button1_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveBorder;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(733, 35);
            button1.Name = "button1";
            button1.Size = new Size(215, 51);
            button1.TabIndex = 2;
            button1.Text = "Subject";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Subject_Click_1;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveBorder;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(512, 35);
            button2.Name = "button2";
            button2.Size = new Size(215, 51);
            button2.TabIndex = 1;
            button2.Text = "Teacher";
            button2.UseVisualStyleBackColor = false;
            button2.Click += Teacher_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveBorder;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(1175, 35);
            button3.Name = "button3";
            button3.Size = new Size(266, 51);
            button3.TabIndex = 4;
            button3.Text = "Student-Teacher-Pair";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ActiveBorder;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(954, 35);
            button4.Name = "button4";
            button4.Size = new Size(215, 51);
            button4.TabIndex = 3;
            button4.Text = "Grade";
            button4.UseVisualStyleBackColor = false;
            button4.Click += Grade_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(-7, 24);
            label1.Name = "label1";
            label1.Size = new Size(292, 62);
            label1.TabIndex = 5;
            label1.Text = "Select Table:";
            // 
            // student_grid
            // 
            student_grid.AllowUserToAddRows = false;
            student_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            student_grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            student_grid.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new Font("Stencil", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            student_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            student_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Info;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            student_grid.DefaultCellStyle = dataGridViewCellStyle2;
            student_grid.Location = new Point(12, 110);
            student_grid.Name = "student_grid";
            student_grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            student_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            student_grid.RowHeadersWidth = 51;
            student_grid.RowTemplate.Height = 29;
            student_grid.Size = new Size(1314, 529);
            student_grid.TabIndex = 6;
            student_grid.Visible = false;
            student_grid.CellContentClick += student_grid_CellContentClick;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ActiveBorder;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(1342, 131);
            button5.Name = "button5";
            button5.Size = new Size(194, 51);
            button5.TabIndex = 5;
            button5.Text = "Create";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button7
            // 
            button7.BackColor = SystemColors.ActiveBorder;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button7.Location = new Point(1342, 310);
            button7.Name = "button7";
            button7.Size = new Size(194, 51);
            button7.TabIndex = 7;
            button7.Text = "Save";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.ActiveBorder;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(1342, 214);
            button6.Name = "button6";
            button6.Size = new Size(194, 51);
            button6.TabIndex = 6;
            button6.Text = "Delete";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Turquoise;
            ClientSize = new Size(1548, 651);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(student_grid);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Student);
            Name = "Form1";
            Text = "EKundalik";
            ((System.ComponentModel.ISupportInitialize)student_grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Student;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private DataGridView student_grid;
        private Button button5;
        private Button button7;
        private Button button6;
    }
}
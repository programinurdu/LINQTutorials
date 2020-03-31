using LINQTutorials.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQTutorials
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadDataButton_Click(object sender, EventArgs e)
        {
            List<Student> students = new List<Student>();

            using (LINQTestContext db = new LINQTestContext())
            {
                // First Get the data
                students = db.Students.ToList();

                // Then show just the column you want to show.
                students = students.Select(x => new Student()
                {
                    StudentId = x.StudentId,
                    FullName = x.FullName
                }).ToList();
            }

            StudentsDataGridView.DataSource = students;
        }
    }
}

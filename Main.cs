using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace StudentsDiary
{
    public partial class Main : Form
    {
        private string _filePath = Path.Combine(Environment.CurrentDirectory, "..\\..\\", "students.txt");
        public Main()
        {
            InitializeComponent();
            var students = DeserializeFromFile();
            dgvDiary.DataSource = students;
        }
        public void SerializeToFile(List<Student> students)
        {
            var serializer = new XmlSerializer(typeof(List<Student>));
            using (var streamWriter = new StreamWriter(_filePath))
            { 
                serializer.Serialize(streamWriter, students);
                streamWriter.Close();
            }
        }
        private List<Student> DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Student>();
            }
            var serializer = new XmlSerializer(typeof(List<Student>));
            using (var streamReader = new StreamReader(_filePath))
            {
                var students = (List<Student>)serializer.Deserialize(streamReader);
                streamReader.Close();
                return students;
            }
        }
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var addNewStudentForm = new AddNewStudent();
            addNewStudentForm.ShowDialog();

            var students = DeserializeFromFile();
            dgvDiary.DataSource = students;

        }

        private void btnEditGrades_Click(object sender, EventArgs e)
        {
            var valueFromCell = dgvDiary.SelectedRows[0].Cells[0].Value;


            if (dgvDiary.SelectedRows.Count == 1 && int.TryParse(valueFromCell.ToString(),
                    out int id))
            {
                var gradesForm = new GradesForm(id);
                gradesForm.ShowDialog();
            }
            else
            {
                var gradesForm = new GradesForm(0);
                gradesForm.ShowDialog();
            }
                
            
        }

        private void btnEditStudentDetails_Click(object sender, EventArgs e)
        {
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz studenta aby edytować jego oceny");
                return;
            }
            else if (dgvDiary.SelectedRows.Count > 1)
            {
                MessageBox.Show("Możesz edytować oceny tylko jednego studenta naraz.");
                return;
            }

            var editStudentForm = new AddNewStudent(Convert.ToInt32(dgvDiary.SelectedRows[0].Cells[0].Value));
            editStudentForm.ShowDialog();

            var students = DeserializeFromFile();
            dgvDiary.DataSource = students;
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            var students = DeserializeFromFile();
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz studenta aby usunąć go z listy studentów");
                return;
            }
            else if (dgvDiary.SelectedRows.Count > 1)
            {
                MessageBox.Show("Możesz usunąć tylko jednego studenta ");
                return;
            }
            
            var studentToDelete = students.FirstOrDefault(s => s.Id == Convert.ToInt32(dgvDiary.SelectedRows[0].Cells[0].Value));

            if (studentToDelete != null)
            {
                var decision = MessageBox.Show($"Ten proces jest nieodwracalny\nDane studenmta : {studentToDelete.FirstNAme} {studentToDelete.LastName}  \n{studentToDelete.Pesel}  \n{studentToDelete.IndexNumber} ", "Czy na pewno chcesz usunąć studenta ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (decision == DialogResult.Yes)
                {
                    students.RemoveAll(s => s.Id == studentToDelete.Id);
                    MessageBox.Show("Student został usunięty.");
                    SerializeToFile(students);
                    dgvDiary.DataSource = students;
                }
                else 
                {
                    return;
                }
            }

        }


    }
}

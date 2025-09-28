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
    public partial class GradesForm : Form
    {
        private string _filePath = Path.Combine(Environment.CurrentDirectory, "..\\..\\", "students.txt");
        private List<Student> _students;

        public GradesForm()
        {
            InitializeComponent();
            _students = DeserializeFromFile();
            foreach (var student in _students)
            {
                cbChooseStudent.Items.Add(student);
            }
            var listOfSubjects = new List<string> { "Matematyka", "Fizyka", "Chemia", "Biologia", "Historia", "WOS", "Informatyka", "Język Polski", "Język Angielski", "Język Niemiecki", "Wychowanie Fizyczne" };
            foreach (var subject in listOfSubjects)
            {
                cbListOfSubject.Items.Add(subject);
            }

        }

        private void btnAddNewGrades_Click(object sender, EventArgs e)
        {
            if (cbChooseStudent.SelectedItem == null)
            {
                MessageBox.Show("Wybierz studenta");
                return;
            }
            if (cbListOfSubject.SelectedItem == null)
            {
                MessageBox.Show("Wybierz przedmiot");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbGrades.Text))
            {
                MessageBox.Show("Wpisz ocenę");
                return;
            }

            var selectedStudent = (Student)cbChooseStudent.SelectedItem;
            var selectedSubject = cbListOfSubject.SelectedItem.ToString();
            if (!double.TryParse(tbGrades.Text, out double gradeValue) || gradeValue < 1 || gradeValue > 6)
            {
                MessageBox.Show("Wpisz poprawną ocenę (od 1 do 6)");
                return;
            }

            var newGrade = new Grade
            {

                SubjectName = selectedSubject,
                Values = gradeValue,
                DateOfGrade = DateTime.Now

            };

            selectedStudent.Grades.Add(newGrade);

            SerializeToFile(_students);
            dgvGrades.DataSource = null;
            dgvGrades.DataSource = selectedStudent.Grades;
        }
        private void btnEditGrades_Click(object sender, EventArgs e)
        {
            if (cbChooseStudent.SelectedItem == null)
            {
                MessageBox.Show("Wybierz studenta");
                return;
            }
        }

        private void btnDeleteGrades_Click(object sender, EventArgs e)
        {
            if (cbChooseStudent.SelectedItem == null)
            {
                MessageBox.Show("Wybierz studenta");
                return;
            }
            var selectedStudent = (Student)cbChooseStudent.SelectedItem;
            var gradeToDelete = selectedStudent.Grades.FirstOrDefault(g => g.Values.ToString() == dgvGrades.SelectedRows[0].Cells[1].Value.ToString() && g.SubjectName == dgvGrades.SelectedRows[0].Cells[0].Value.ToString() && g.DateOfGrade.ToString() == dgvGrades.SelectedRows[0].Cells[2].Value.ToString());

            if (dgvGrades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz studenta aby usunąć go z listy studentów");
                return;
            }
            else if (dgvGrades.SelectedRows.Count > 1)
            {
                MessageBox.Show("Możesz usunąć tylko jednego studenta ");
                return;
            }



            if (gradeToDelete != null)
            {
                var decision = MessageBox.Show($"Ten proces jest nieodwracalny\nocena którą chcesz usunąć : {gradeToDelete.SubjectName} {gradeToDelete.Values}  \n{gradeToDelete.DateOfGrade}  ", "Czy na pewno chcesz usunąć tą ocenę ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (decision == DialogResult.Yes)
                {
                    selectedStudent.Grades.RemoveAll(g => g.Values.ToString() == dgvGrades.SelectedRows[0].Cells[1].Value.ToString() && g.SubjectName == dgvGrades.SelectedRows[0].Cells[0].Value.ToString() && g.DateOfGrade.ToString() == dgvGrades.SelectedRows[0].Cells[2].Value.ToString());
                    MessageBox.Show("Ocena została usunięta");

                    SerializeToFile(_students);

                    dgvGrades.DataSource = null;
                    dgvGrades.DataSource = selectedStudent.Grades;
                }
                else
                {
                    return;
                }


            }
        }


        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            SerializeToFile(_students);
            this.Close();
        }

        private void btcClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void cbChooseStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedStudent = (Student)cbChooseStudent.SelectedItem;

            lbName.Text = selectedStudent.FirstNAme;
            lbLastname.Text = selectedStudent.LastName;
            lbPesel.Text = selectedStudent.Pesel;
            lbIndeksNumber.Text = selectedStudent.IndexNumber;
            lbBirthDate.Text = selectedStudent.DateOfBirth.ToShortDateString();

            dgvGrades.DataSource = selectedStudent.Grades;
        }

       
    }
}

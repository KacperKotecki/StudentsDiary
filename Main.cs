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
            SetColumnHeaders();
            InicjalizeCombobox(AcademicDataSources.Profiles, cbProfileName);
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
        private void SetColumnHeaders()
        {
            dgvDiary.Columns[0].HeaderText = "Id";
            dgvDiary.Columns[1].HeaderText = "Imię";
            dgvDiary.Columns[2].HeaderText = "Nazwisko";
            dgvDiary.Columns[3].HeaderText = "Pesel";
            dgvDiary.Columns[4].HeaderText = "Numer indeksu";
            dgvDiary.Columns[5].HeaderText = "Data urodzenia";
            
        }

        private void cbProfileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProfile = cbProfileName.SelectedItem.ToString();
            var students = DeserializeFromFile();
            var studentFromProfileName = students.Where(s => s.AcademicProfile.ProfileName == selectedProfile).ToList();
            dgvDiary.DataSource = null;
            if (selectedProfile == "Wszystkie kierunki")
            {
                
                dgvDiary.DataSource = students;
            }
            else
            {
                dgvDiary.DataSource = studentFromProfileName;
            }

        }

        private void InicjalizeCombobox(List<string> listWithtemsToAdd, ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("Wszystkie kierunki");
            comboBox.SelectedIndex = 0;
            foreach (var item in listWithtemsToAdd)
            {
                comboBox.Items.Add(item);
            }
        }
    }
}

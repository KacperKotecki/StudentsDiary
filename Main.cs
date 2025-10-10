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
        private FileHelper _fileHelper = new FileHelper(Path.Combine(Environment.CurrentDirectory, "..\\..\\", "students.txt"));

        private InitializeComponents _initializeComponents = new InitializeComponents();

        private List<string> _listHeadersToAdd = new List<string>() { "id", "Imię", "Nazwisko", "Pesel", "Numer indeksu", "Data urodzenia", "Studia" };

        private List<string> _listOptionsToAdd = AcademicDataSources.Profiles.ToList();


        public Main()
        {
            InitializeComponent();
            var students = _fileHelper.DeserializeFromFile();
            dgvDiary.DataSource = students;

            _listOptionsToAdd.Insert(0, "Wszystkie kierunki");
            _initializeComponents.InicjalizeCombobox(cbProfileName, _listOptionsToAdd);
            _initializeComponents.SetColumnHeaders(dgvDiary, _listHeadersToAdd);
        }
        
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var addNewStudentForm = new AddNewStudent();
            addNewStudentForm.ShowDialog();

            var students = _fileHelper.DeserializeFromFile();
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

            var students = _fileHelper.DeserializeFromFile();
            dgvDiary.DataSource = students;
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            var students = _fileHelper.DeserializeFromFile();
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
                    _fileHelper.SerializeToFile(students);
                    dgvDiary.DataSource = students;
                }
                else 
                {
                    return;
                }
            }

        }
        


        private void cbProfileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProfile = cbProfileName.SelectedItem.ToString();
            var students = _fileHelper.DeserializeFromFile();
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

        //private void InicjalizeCombobox(List<string> listWithtemsToAdd, ComboBox comboBox)
        //{
        //    comboBox.Items.Clear();
        //    comboBox.Items.Add("Wszystkie kierunki");
        //    comboBox.SelectedIndex = 0;
        //    foreach (var item in listWithtemsToAdd)
        //    {
        //        comboBox.Items.Add(item);
        //    }
        //}
    }
}

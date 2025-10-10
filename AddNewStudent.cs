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
    public partial class AddNewStudent : Form
    {
        private FileHelper _fileHelper = new FileHelper(Path.Combine(Environment.CurrentDirectory, "..\\..\\", "students.txt"));
        private bool _isEditMode = false;
        private InitializeComponents _initializeComponents = new InitializeComponents();

        public AddNewStudent()
        {
            InitializeComponent();
            _isEditMode = false;
            tbFirstName.Select();

            _initializeComponents.InicjalizeCombobox(cbProfileName, AcademicDataSources.Profiles);
            _initializeComponents.InicjalizeCombobox(cbDegree, AcademicDataSources.Degrees);
            _initializeComponents.InicjalizeCombobox(cbGroups, AcademicDataSources.Groups);

        }
        public AddNewStudent(int id)
        {
            InitializeComponent();
            _isEditMode = true;
            Text = "Edytuj dane studenta";


            tbFirstName.Select();

            var students = _fileHelper.DeserializeFromFile();
            var thisstudent = students.FirstOrDefault(s => s.Id == id);

            tbId.Text = thisstudent.Id.ToString();
            tbFirstName.Text = thisstudent.FirstNAme;
            tbLastName.Text = thisstudent.LastName;
            tbPesel.Text = thisstudent.Pesel;
            tbIndexNumber.Text = thisstudent.IndexNumber;
            dtpBirthday.Value = thisstudent.DateOfBirth;

            _initializeComponents.InicjalizeCombobox(cbProfileName, AcademicDataSources.Profiles);
            _initializeComponents.InicjalizeCombobox(cbDegree, AcademicDataSources.Degrees);
            _initializeComponents.InicjalizeCombobox(cbGroups, AcademicDataSources.Groups);

            
            cbProfileName.SelectedItem = thisstudent.AcademicProfile.ProfileName.ToString();
            cbDegree.SelectedItem = thisstudent.AcademicProfile.Degree.ToString();
            nudYear.Value = thisstudent.AcademicProfile.Year;
            cbGroups.SelectedItem = thisstudent.AcademicProfile.Group.ToString();
            if(thisstudent.AcademicProfile.Specialization != null)
            {
                chbSpecjalization.Checked = true;
                cbSpecjalization.SelectedItem = thisstudent.AcademicProfile.Specialization.ToString();
            }
            else
            {
                chbSpecjalization.Checked = false;
                cbSpecjalization.SelectedItem = null;
                cbSpecjalization.Enabled = false;
            }


            tbFirstName.Enabled = true;
        }


        private void cbDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudYear.Enabled = true;
            var selectedDegree = cbDegree.SelectedItem.ToString();
            if (AcademicDataSources.YearForDegree.ContainsKey(selectedDegree))
            {
                var (Min, Max) = AcademicDataSources.YearForDegree[selectedDegree];
                nudYear.Minimum = Min;
                nudYear.Maximum = Max;
                nudYear.Value = Min;
            }
            else
            {

                nudYear.Value = 1;
            }
        }

        private void chbSpecjalization_CheckedChanged(object sender, EventArgs e)
        {

            if (cbProfileName.SelectedItem == null)
            {
                MessageBox.Show("Wybierz najpierw profil studiów.");
                chbSpecjalization.Checked = false;
                return;
            }

            if (chbSpecjalization.Checked)
            {
                cbSpecjalization.Enabled = true;
                var selectedProfile = cbProfileName.SelectedItem.ToString();
                List<string> listWithSpecializations = new List<string>();
                listWithSpecializations = AcademicDataSources.SpecializationsByProfile[selectedProfile];

                _initializeComponents.InicjalizeCombobox(cbSpecjalization, listWithSpecializations);
                
            }
            else
            {
                cbSpecjalization.Items.Clear();
                cbSpecjalization.Enabled = false;
                
            }

        }

        private void cbProfileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            chbSpecjalization.Checked = false;
            cbSpecjalization.Enabled = false;
            cbSpecjalization.Items.Clear();
            cbSpecjalization.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var students = _fileHelper.DeserializeFromFile();

            if (_isEditMode)
            {


                var studentToUpdate = students.FirstOrDefault(s => s.Id.ToString() == tbId.Text);
                if (studentToUpdate != null)
                {
                    studentToUpdate.FirstNAme = tbFirstName.Text;
                    studentToUpdate.LastName = tbLastName.Text;
                    studentToUpdate.Pesel = tbPesel.Text;
                    studentToUpdate.IndexNumber = tbIndexNumber.Text;
                    studentToUpdate.DateOfBirth = dtpBirthday.Value;

                    studentToUpdate.AcademicProfile.ProfileName = cbProfileName.SelectedItem.ToString();
                    studentToUpdate.AcademicProfile.Degree = cbDegree.SelectedItem.ToString();
                    studentToUpdate.AcademicProfile.Year = (int)nudYear.Value;
                    studentToUpdate.AcademicProfile.Group = cbGroups.SelectedItem.ToString();
                    studentToUpdate.AcademicProfile.Specialization = cbSpecjalization.SelectedItem?.ToString();
                }
            }
            else
            {
                var lastStudent = students.OrderByDescending(s => s.Id).FirstOrDefault();
                var newId = (lastStudent == null) ? 1 : lastStudent.Id + 1;

                var newStudent = new Student
                {
                    Id = newId,
                    FirstNAme = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    Pesel = tbPesel.Text,
                    Grades = new List<Grade>(),
                    IndexNumber = tbIndexNumber.Text,
                    DateOfBirth = dtpBirthday.Value,
                    AcademicProfile = new AcademicProfile
                    {
                        ProfileName = cbProfileName.SelectedItem?.ToString(),
                        Degree = cbDegree.SelectedItem?.ToString(),
                        Year = (int)nudYear.Value,
                        Group = cbGroups.SelectedItem?.ToString(),
                        Specialization = cbSpecjalization.SelectedItem?.ToString()
                    }
                };
                students.Add(newStudent);
            }

            _fileHelper.SerializeToFile(students);
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}

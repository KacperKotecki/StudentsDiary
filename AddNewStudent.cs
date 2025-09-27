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
        private string _filePath = Path.Combine(Environment.CurrentDirectory, "..\\..\\", "students.txt");
        private bool _isEditMode = false;

        
        public AddNewStudent()
        {
            InitializeComponent();
            _isEditMode = false;
            tbFirstName.Select();

        }
        public AddNewStudent(int id)
        {
            InitializeComponent();
            _isEditMode = true;
            tbFirstName.Select();

            var students = DeserializeFromFile();
            var thisstudent = students.FirstOrDefault(s => s.Id == id);

            tbId.Text = thisstudent.Id.ToString();
            tbFirstName.Text = thisstudent.FirstNAme;
            tbLastName.Text = thisstudent.LastName;
            tbPesel.Text = thisstudent.Pesel;
            tbIndexNumber.Text = thisstudent.IndexNumber;
            dtpBirthday.Value = thisstudent.DateOfBirth;

            tbFirstName.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var students = DeserializeFromFile();

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
                };
                students.Add(newStudent);
            }

            SerializeToFile(students);
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
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
    }
}

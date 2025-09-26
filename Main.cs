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
            foreach (var student in students)
            {
                MessageBox.Show(student.FirstNAme);
            }
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

        }

        private void btnEditGrades_Click(object sender, EventArgs e)
        {

        }

        private void btnEditStudentDetails_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {

        }
    }
}

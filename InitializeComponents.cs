using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsDiary
{
    public class InitializeComponents
    {

        public void SetColumnHeaders(DataGridView dataGridView, List<string> listHeadersToAdd)
        {
            for (int i = 0; i < listHeadersToAdd.Count; i++)
            {
                dataGridView.Columns[i].HeaderText = listHeadersToAdd[i];

            }

        }

        public void InicjalizeCombobox(ComboBox comboBox, List<string> listOptionsToAdd)
        {
            comboBox.Items.Clear();

            foreach (var item in listOptionsToAdd)
            {
                comboBox.Items.Add(item);
            }
            comboBox.SelectedIndex = 0;
        }

        public void InicjalizeCombobox(ComboBox comboBox, List<Student> listOptionsToAdd, int studentId)
        {
            comboBox.Items.Clear();

            foreach (var item in listOptionsToAdd)
            {
                comboBox.Items.Add(item);
            }
            comboBox.SelectedItem = listOptionsToAdd.FirstOrDefault(s => s.Id == studentId);
        }
    }
}

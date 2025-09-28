namespace StudentsDiary
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnEditGrades = new System.Windows.Forms.Button();
            this.btnEditStudentDetails = new System.Windows.Forms.Button();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.dgvDiary = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiary)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(12, 12);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(136, 23);
            this.btnAddStudent.TabIndex = 0;
            this.btnAddStudent.Text = "Dodaj Studenta";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnEditGrades
            // 
            this.btnEditGrades.Location = new System.Drawing.Point(154, 12);
            this.btnEditGrades.Name = "btnEditGrades";
            this.btnEditGrades.Size = new System.Drawing.Size(136, 23);
            this.btnEditGrades.TabIndex = 1;
            this.btnEditGrades.Text = "Zarządzaj Ocenami";
            this.btnEditGrades.UseVisualStyleBackColor = true;
            this.btnEditGrades.Click += new System.EventHandler(this.btnEditGrades_Click);
            // 
            // btnEditStudentDetails
            // 
            this.btnEditStudentDetails.Location = new System.Drawing.Point(296, 13);
            this.btnEditStudentDetails.Name = "btnEditStudentDetails";
            this.btnEditStudentDetails.Size = new System.Drawing.Size(136, 23);
            this.btnEditStudentDetails.TabIndex = 2;
            this.btnEditStudentDetails.Text = "Edytuj Dane Studenta";
            this.btnEditStudentDetails.UseVisualStyleBackColor = true;
            this.btnEditStudentDetails.Click += new System.EventHandler(this.btnEditStudentDetails_Click);
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.Location = new System.Drawing.Point(438, 13);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(136, 23);
            this.btnDeleteStudent.TabIndex = 3;
            this.btnDeleteStudent.Text = "Usuń Studenta";
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // dgvDiary
            // 
            this.dgvDiary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDiary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiary.Location = new System.Drawing.Point(12, 42);
            this.dgvDiary.Name = "dgvDiary";
            this.dgvDiary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiary.Size = new System.Drawing.Size(775, 396);
            this.dgvDiary.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvDiary);
            this.Controls.Add(this.btnDeleteStudent);
            this.Controls.Add(this.btnEditStudentDetails);
            this.Controls.Add(this.btnEditGrades);
            this.Controls.Add(this.btnAddStudent);
            this.Name = "Main";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnEditGrades;
        private System.Windows.Forms.Button btnEditStudentDetails;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.DataGridView dgvDiary;
    }
}


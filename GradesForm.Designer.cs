namespace StudentsDiary
{
    partial class GradesForm
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
            this.cbChooseStudent = new System.Windows.Forms.ComboBox();
            this.lbChooseStudent = new System.Windows.Forms.Label();
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.lbPesel = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbLastname = new System.Windows.Forms.Label();
            this.lbIndeksNumber = new System.Windows.Forms.Label();
            this.lbBirthDate = new System.Windows.Forms.Label();
            this.lbAddNewGrade = new System.Windows.Forms.Label();
            this.cbListOfSubject = new System.Windows.Forms.ComboBox();
            this.tbGrades = new System.Windows.Forms.TextBox();
            this.btnAddNewGrades = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btcClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            this.SuspendLayout();
            // 
            // cbChooseStudent
            // 
            this.cbChooseStudent.FormattingEnabled = true;
            this.cbChooseStudent.Location = new System.Drawing.Point(12, 31);
            this.cbChooseStudent.Name = "cbChooseStudent";
            this.cbChooseStudent.Size = new System.Drawing.Size(201, 21);
            this.cbChooseStudent.TabIndex = 0;
            this.cbChooseStudent.SelectedIndexChanged += new System.EventHandler(this.cbChooseStudent_SelectedIndexChanged);
            // 
            // lbChooseStudent
            // 
            this.lbChooseStudent.AutoSize = true;
            this.lbChooseStudent.Location = new System.Drawing.Point(12, 9);
            this.lbChooseStudent.Name = "lbChooseStudent";
            this.lbChooseStudent.Size = new System.Drawing.Size(91, 13);
            this.lbChooseStudent.TabIndex = 1;
            this.lbChooseStudent.Text = "Wybierz Studenta";
            // 
            // dgvGrades
            // 
            this.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrades.Location = new System.Drawing.Point(12, 69);
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.Size = new System.Drawing.Size(402, 362);
            this.dgvGrades.TabIndex = 2;
            // 
            // lbPesel
            // 
            this.lbPesel.AutoSize = true;
            this.lbPesel.Location = new System.Drawing.Point(490, 69);
            this.lbPesel.Name = "lbPesel";
            this.lbPesel.Size = new System.Drawing.Size(73, 13);
            this.lbPesel.TabIndex = 3;
            this.lbPesel.Text = "04282500552";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(490, 38);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(24, 13);
            this.lbName.TabIndex = 4;
            this.lbName.Text = "Jan";
            // 
            // lbLastname
            // 
            this.lbLastname.AutoSize = true;
            this.lbLastname.Location = new System.Drawing.Point(609, 39);
            this.lbLastname.Name = "lbLastname";
            this.lbLastname.Size = new System.Drawing.Size(49, 13);
            this.lbLastname.TabIndex = 5;
            this.lbLastname.Text = "Kowalski";
            // 
            // lbIndeksNumber
            // 
            this.lbIndeksNumber.AutoSize = true;
            this.lbIndeksNumber.Location = new System.Drawing.Point(490, 97);
            this.lbIndeksNumber.Name = "lbIndeksNumber";
            this.lbIndeksNumber.Size = new System.Drawing.Size(43, 13);
            this.lbIndeksNumber.TabIndex = 6;
            this.lbIndeksNumber.Text = "557334";
            // 
            // lbBirthDate
            // 
            this.lbBirthDate.AutoSize = true;
            this.lbBirthDate.Location = new System.Drawing.Point(490, 131);
            this.lbBirthDate.Name = "lbBirthDate";
            this.lbBirthDate.Size = new System.Drawing.Size(54, 13);
            this.lbBirthDate.TabIndex = 7;
            this.lbBirthDate.Text = "12-Jun-98";
            // 
            // lbAddNewGrade
            // 
            this.lbAddNewGrade.AutoSize = true;
            this.lbAddNewGrade.Location = new System.Drawing.Point(490, 190);
            this.lbAddNewGrade.Name = "lbAddNewGrade";
            this.lbAddNewGrade.Size = new System.Drawing.Size(97, 13);
            this.lbAddNewGrade.TabIndex = 8;
            this.lbAddNewGrade.Text = "Dodaj nową ocenę";
            // 
            // cbListOfSubject
            // 
            this.cbListOfSubject.FormattingEnabled = true;
            this.cbListOfSubject.Location = new System.Drawing.Point(493, 206);
            this.cbListOfSubject.Name = "cbListOfSubject";
            this.cbListOfSubject.Size = new System.Drawing.Size(201, 21);
            this.cbListOfSubject.TabIndex = 9;
            // 
            // tbGrades
            // 
            this.tbGrades.Location = new System.Drawing.Point(493, 325);
            this.tbGrades.Name = "tbGrades";
            this.tbGrades.Size = new System.Drawing.Size(296, 20);
            this.tbGrades.TabIndex = 10;
            // 
            // btnAddNewGrades
            // 
            this.btnAddNewGrades.Location = new System.Drawing.Point(565, 351);
            this.btnAddNewGrades.Name = "btnAddNewGrades";
            this.btnAddNewGrades.Size = new System.Drawing.Size(145, 23);
            this.btnAddNewGrades.TabIndex = 11;
            this.btnAddNewGrades.Text = "Dodaj Ocenę";
            this.btnAddNewGrades.UseVisualStyleBackColor = true;
            this.btnAddNewGrades.Click += new System.EventHandler(this.btnAddNewGrades_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(493, 408);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(145, 23);
            this.btnSaveChanges.TabIndex = 12;
            this.btnSaveChanges.Text = "Zapisz zmiany";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btcClose
            // 
            this.btcClose.Location = new System.Drawing.Point(644, 408);
            this.btcClose.Name = "btcClose";
            this.btcClose.Size = new System.Drawing.Size(145, 23);
            this.btcClose.TabIndex = 13;
            this.btcClose.Text = "Zamknij";
            this.btcClose.UseVisualStyleBackColor = true;
            this.btcClose.Click += new System.EventHandler(this.btcClose_Click);
            // 
            // GradesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 450);
            this.Controls.Add(this.btcClose);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnAddNewGrades);
            this.Controls.Add(this.tbGrades);
            this.Controls.Add(this.cbListOfSubject);
            this.Controls.Add(this.lbAddNewGrade);
            this.Controls.Add(this.lbBirthDate);
            this.Controls.Add(this.lbIndeksNumber);
            this.Controls.Add(this.lbLastname);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbPesel);
            this.Controls.Add(this.dgvGrades);
            this.Controls.Add(this.lbChooseStudent);
            this.Controls.Add(this.cbChooseStudent);
            this.Name = "GradesForm";
            this.Text = "GradesForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbChooseStudent;
        private System.Windows.Forms.Label lbChooseStudent;
        private System.Windows.Forms.DataGridView dgvGrades;
        private System.Windows.Forms.Label lbPesel;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbLastname;
        private System.Windows.Forms.Label lbIndeksNumber;
        private System.Windows.Forms.Label lbBirthDate;
        private System.Windows.Forms.Label lbAddNewGrade;
        private System.Windows.Forms.ComboBox cbListOfSubject;
        private System.Windows.Forms.TextBox tbGrades;
        private System.Windows.Forms.Button btnAddNewGrades;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btcClose;
    }
}
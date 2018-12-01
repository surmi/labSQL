using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace lab5_1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void loadList()
        {
            try
            {
                string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\source\\repos\\lab5_1\\lab5_1\\MeasurementsDatabase.mdf;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = connString;
                    conn.Open();

                    SqlCommand selectCommand = new SqlCommand("SELECT * FROM Measurements", conn);
                    selectCommand.ExecuteNonQuery();

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    { // while there is another record present
                        while (reader.Read())
                        {
                            // write the data on to the screen
                            listBoxID.Items.Add(reader[0].ToString());
                            listBoxTime.Items.Add(reader[1].ToString());
                            listBoxValue.Items.Add(reader[2].ToString());
                            listBoxComment.Items.Add(reader[3].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void loadLast()
        {
            try
            {
                string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\source\\repos\\lab5_1\\lab5_1\\MeasurementsDatabase.mdf;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = connString;
                    conn.Open();

                    SqlCommand selectCommand = new SqlCommand("SELECT TOP 1 * FROM Measurements ORDER BY ID DESC", conn);
                    selectCommand.ExecuteNonQuery();

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    { // while there is another record present
                        while (reader.Read())
                        {
                            // write the data on to the screen
                            listBoxID.Items.Add(reader[0].ToString());
                            listBoxTime.Items.Add(reader[1].ToString());
                            listBoxValue.Items.Add(reader[2].ToString());
                            listBoxComment.Items.Add(reader[3].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void insertMeas()
        {
            try
            {
                if (valueTextBox.Text == "") throw new System.ArgumentException("Value text box cannot be empty", "original");

                string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\source\\repos\\lab5_1\\lab5_1\\MeasurementsDatabase.mdf;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = connString;
                    conn.Open();

                    SqlCommand sqlCmd = new SqlCommand();

                    sqlCmd.CommandText = "INSERT INTO Measurements (time, value, comment) VALUES ((@time), " + valueTextBox.Text + ", (@comment) )";
                    DateTime dataTimeVar = DateTime.Now;
                    sqlCmd.Parameters.AddWithValue("@time", dataTimeVar);
                    sqlCmd.Parameters.AddWithValue("@comment", commentTextBox.Text);
                    sqlCmd.Connection = conn;
                    int res = sqlCmd.ExecuteNonQuery();

                    if(res != -1)
                    {
                        MessageBox.Show("Saved succesfully");
                        listBoxID.Items.Clear();
                        listBoxComment.Items.Clear();
                        listBoxTime.Items.Clear();
                        listBoxValue.Items.Clear();
                        loadList();
                    }
                    else MessageBox.Show("Command not executed succesfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void deleteMeas( int id)
        {
            try
            {
                if (valueTextBox.Text == "") throw new System.ArgumentException("Value text box cannot be empty", "original");

                string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\source\\repos\\lab5_1\\lab5_1\\MeasurementsDatabase.mdf;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = connString;
                    conn.Open();

                    SqlCommand sqlCmd = new SqlCommand();

                    sqlCmd.CommandText = "DELETE FROM Measurements WHERE Id = @idToDelete";
                    sqlCmd.Parameters.AddWithValue("@idToDelete", id);
                    sqlCmd.Connection = conn;
                    int res = sqlCmd.ExecuteNonQuery();

                    if (res != -1)
                    {
                        MessageBox.Show("Deleted succesfully");
                        listBoxID.Items.Clear();
                        listBoxComment.Items.Clear();
                        listBoxTime.Items.Clear();
                        listBoxValue.Items.Clear();
                        loadList();
                    }
                    else MessageBox.Show("Command not executed succesfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void updateMeas( int id)
        {
            try
            {
                if (valueTextBox.Text == "") throw new System.ArgumentException("Value text box cannot be empty", "original");

                string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\source\\repos\\lab5_1\\lab5_1\\MeasurementsDatabase.mdf;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = connString;
                    conn.Open();

                    SqlCommand sqlCmd = new SqlCommand();

                    sqlCmd.CommandText = "UPDATE Measurements SET time=@time, value=@value, comment=@comment WHERE id=@id";
                    DateTime dataTimeVar = DateTime.Now;
                    sqlCmd.Parameters.AddWithValue("@time", dataTimeVar);
                    sqlCmd.Parameters.AddWithValue("@value", valueTextBox.Text);
                    sqlCmd.Parameters.AddWithValue("@comment", commentTextBox.Text);
                    sqlCmd.Parameters.AddWithValue("@id", id);
                    sqlCmd.Connection = conn;
                    int res = sqlCmd.ExecuteNonQuery();

                    if (res != -1)
                    {
                        MessageBox.Show("Updated succesfully");
                        listBoxID.Items.Clear();
                        listBoxComment.Items.Clear();
                        listBoxTime.Items.Clear();
                        listBoxValue.Items.Clear();
                        loadList();
                    }
                    else MessageBox.Show("Command not executed succesfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.CommentLabel = new System.Windows.Forms.Label();
            this.InsertButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBoxID = new System.Windows.Forms.ListBox();
            this.listBoxTime = new System.Windows.Forms.ListBox();
            this.listBoxValue = new System.Windows.Forms.ListBox();
            this.listBoxComment = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.measurementsDatabaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.measurementsDatabaseDataSet = new lab5_1.MeasurementsDatabaseDataSet();
            this.measurementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.measurementsTableAdapter = new lab5_1.MeasurementsDatabaseDataSetTableAdapters.MeasurementsTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementsDatabaseDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementsDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(92, 44);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(100, 20);
            this.valueTextBox.TabIndex = 0;
            // 
            // commentTextBox
            // 
            this.commentTextBox.Location = new System.Drawing.Point(92, 70);
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(100, 20);
            this.commentTextBox.TabIndex = 1;
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(39, 44);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(34, 13);
            this.ValueLabel.TabIndex = 2;
            this.ValueLabel.Text = "Value";
            // 
            // CommentLabel
            // 
            this.CommentLabel.AutoSize = true;
            this.CommentLabel.Location = new System.Drawing.Point(39, 70);
            this.CommentLabel.Name = "CommentLabel";
            this.CommentLabel.Size = new System.Drawing.Size(51, 13);
            this.CommentLabel.TabIndex = 3;
            this.CommentLabel.Text = "Comment";
            // 
            // InsertButton
            // 
            this.InsertButton.BackColor = System.Drawing.Color.Green;
            this.InsertButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.InsertButton.Location = new System.Drawing.Point(294, 44);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(75, 23);
            this.InsertButton.TabIndex = 4;
            this.InsertButton.Text = "Insert";
            this.InsertButton.UseVisualStyleBackColor = false;
            this.InsertButton.Click += new System.EventHandler(this.insertClick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(375, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.deleteClick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(456, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.updateClick);
            // 
            // listBoxID
            // 
            this.listBoxID.FormattingEnabled = true;
            this.listBoxID.Location = new System.Drawing.Point(42, 132);
            this.listBoxID.Name = "listBoxID";
            this.listBoxID.Size = new System.Drawing.Size(120, 238);
            this.listBoxID.TabIndex = 7;
            // 
            // listBoxTime
            // 
            this.listBoxTime.FormattingEnabled = true;
            this.listBoxTime.Location = new System.Drawing.Point(168, 132);
            this.listBoxTime.Name = "listBoxTime";
            this.listBoxTime.Size = new System.Drawing.Size(120, 238);
            this.listBoxTime.TabIndex = 8;
            // 
            // listBoxValue
            // 
            this.listBoxValue.FormattingEnabled = true;
            this.listBoxValue.Location = new System.Drawing.Point(294, 132);
            this.listBoxValue.Name = "listBoxValue";
            this.listBoxValue.Size = new System.Drawing.Size(120, 238);
            this.listBoxValue.TabIndex = 9;
            // 
            // listBoxComment
            // 
            this.listBoxComment.FormattingEnabled = true;
            this.listBoxComment.Location = new System.Drawing.Point(420, 132);
            this.listBoxComment.Name = "listBoxComment";
            this.listBoxComment.Size = new System.Drawing.Size(120, 238);
            this.listBoxComment.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.timeDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.measurementsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(42, 376);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(498, 150);
            this.dataGridView1.TabIndex = 11;
            // 
            // measurementsDatabaseDataSetBindingSource
            // 
            this.measurementsDatabaseDataSetBindingSource.DataSource = this.measurementsDatabaseDataSet;
            this.measurementsDatabaseDataSetBindingSource.Position = 0;
            this.measurementsDatabaseDataSetBindingSource.CurrentChanged += new System.EventHandler(this.measurementsDatabaseDataSetBindingSource_CurrentChanged);
            // 
            // measurementsDatabaseDataSet
            // 
            this.measurementsDatabaseDataSet.DataSetName = "MeasurementsDatabaseDataSet";
            this.measurementsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // measurementsBindingSource
            // 
            this.measurementsBindingSource.DataMember = "Measurements";
            this.measurementsBindingSource.DataSource = this.measurementsDatabaseDataSet;
            // 
            // measurementsTableAdapter
            // 
            this.measurementsTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "time";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "comment";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 627);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listBoxComment);
            this.Controls.Add(this.listBoxValue);
            this.Controls.Add(this.listBoxTime);
            this.Controls.Add(this.listBoxID);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.CommentLabel);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(this.valueTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementsDatabaseDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementsDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.Label CommentLabel;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBoxID;
        private System.Windows.Forms.ListBox listBoxTime;
        private System.Windows.Forms.ListBox listBoxValue;
        private System.Windows.Forms.ListBox listBoxComment;
        private DataGridView dataGridView1;
        private BindingSource measurementsDatabaseDataSetBindingSource;
        private MeasurementsDatabaseDataSet measurementsDatabaseDataSet;
        private BindingSource measurementsBindingSource;
        private MeasurementsDatabaseDataSetTableAdapters.MeasurementsTableAdapter measurementsTableAdapter;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
    }
}


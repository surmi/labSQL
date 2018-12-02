using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadList();
            updateGrid();
        }

        private void insertClick(object sender, EventArgs e)
        {
            insertMeas();
            updateGrid();

        }

        private void deleteClick(object sender, EventArgs e)
        {
            deleteMeas(int.Parse(listBoxID.SelectedItem.ToString()));
            updateGrid();
        }

        private void updateClick(object sender, EventArgs e)
        {
            updateMeas(int.Parse(listBoxID.SelectedItem.ToString()));
            updateGrid();
        }

        private void measurementsDatabaseDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
                // TODO: Ten wiersz kodu wczytuje dane do tabeli 'measurementsDatabaseDataSet.Measurements' . Możesz go przenieść lub usunąć.
            this.measurementsTableAdapter.Fill(this.measurementsDatabaseDataSet.Measurements);

        }
    }
}

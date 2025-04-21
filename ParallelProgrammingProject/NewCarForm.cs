using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelProgrammingProject
{
    public partial class NewCarForm : Form
    {
        internal Car car { get; private set; }

        public NewCarForm()
        {
            InitializeComponent();
        }

        private void NewCarButton_Click(object sender, EventArgs e)
        {
            int year, hp, weight;

            if (!int.TryParse(CarYear.Text, out year))
            {
                MessageBox.Show("Car year needs to be an integer.");
                return;
            }
            if (!int.TryParse(CarHP.Text, out hp))
            {
                MessageBox.Show("Car horsepower needs to be an integer.");
                return;
            }
            if (!int.TryParse(CarWeight.Text, out weight))
            {
                MessageBox.Show("Car weight needs to be an integer.");
                return;
            }

            car = new(CarMake.Text, CarModel.Text, year, hp, weight);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

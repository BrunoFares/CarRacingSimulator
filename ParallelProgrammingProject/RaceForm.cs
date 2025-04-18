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
    public partial class RaceForm : Form
    {
        public RaceForm()
        {
            InitializeComponent();
        }

        private void Race_Load(object sender, EventArgs e)
        {
            Race race = new();

            List<Car> cars = race.racers;

            int i = 0;
            foreach (Car car in cars) {
                Label lab = new();
                lab.Text = car.Make;
                lab.Location = new Point(222, 90 + i);
                lab.AutoSize = true;
                lab.Font = new Font("Calibri", 14);
                lab.ForeColor = Color.Green;
                lab.Padding = new Padding(6);
                this.Controls.Add(lab);
                i += 50;
            }
        }
    }
}

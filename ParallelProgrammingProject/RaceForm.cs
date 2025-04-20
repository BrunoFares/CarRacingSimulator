using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

            //for (int i = 0; i < race.racers) {
            //    MessageBox.Show(car.Value.Make);
            //}

            Dictionary<int, Car> cars = new();
            Dictionary<int, List<TextBox>> racerValues = new();

            foreach (KeyValuePair<int, Car> car in race.racers) {
                cars[car.Key] = race.racers[car.Key];
                racerValues[car.Key] = LoadCar(cars[car.Key], car.Key);
            }

            Button EditButton = new();
            Button DoneButton = new();

            EditButton.Text = "Edit Car";
            EditButton.Location = new Point(0, 20 + cars.Count * 90);
            EditButton.Click += (sender, EventArgs) => EditRows(sender, EventArgs, racerValues, DoneButton, EditButton);
            this.Controls.Add(EditButton);

            DoneButton.Text = "Apply Edits";
            DoneButton.Enabled = false;
            DoneButton.Location = new Point(200, 20 + cars.Count * 90);
            DoneButton.Click += (sender, EventArgs) => ApplyEdits(sender, EventArgs, racerValues, ref cars, DoneButton, EditButton);
            this.Controls.Add(DoneButton);
        }

        private List<TextBox> LoadCar(Car car, int index)
        {
            List<TextBox> textBoxes = new();
            Label tag = new();
            tag.Text = "Contestant " + (index + 1);
            tag.Location = new Point(0, index * 90);
            tag.AutoSize = true;
            tag.Font = new Font("Default", 10, FontStyle.Bold);
            tag.Padding = new Padding(10, 10, 10, 0);

            TextBox lab1 = new();
            lab1.Text = car.Make;
            lab1.Enabled = false;
            lab1.Location = new Point(0, 20 + index * 90);
            lab1.AutoSize = true;
            lab1.Font = new Font("Default", 14);
            lab1.Padding = new Padding(10, 10, 10, 0);
            this.Controls.Add(lab1);
            textBoxes.Add(lab1);

            TextBox lab2 = new();
            lab2.Text = car.Model;
            lab2.Enabled = false;
            lab2.Location = new Point(200, 20 + index * 90);
            lab2.AutoSize = true;
            lab2.Font = new Font("Default", 14);
            lab2.Padding = new Padding(10);
            this.Controls.Add(lab2);
            textBoxes.Add(lab2);

            TextBox lab3 = new();
            lab3.Text = car.Year.ToString();
            lab3.Enabled = false;
            lab3.Location = new Point(0, 60 + index * 90);
            lab3.AutoSize = true;
            lab3.Font = new Font("Default", 9);
            lab3.Padding = new Padding(10, 0, 10, 0);
            this.Controls.Add(lab3);
            textBoxes.Add(lab3);

            TextBox lab4 = new();
            lab4.Text = car.HorsePower.ToString();
            lab4.Enabled = false;
            lab4.Location = new Point(400, 20 + index * 90);
            lab4.AutoSize = true;
            lab4.Font = new Font("Default", 14);
            lab4.Padding = new Padding(10);
            this.Controls.Add(lab4);
            textBoxes.Add(lab4);

            TextBox lab5 = new();
            lab5.Text = car.Weight.ToString();
            lab5.Enabled = false;
            lab5.Location = new Point(600, 20 + index * 90);
            lab5.AutoSize = true;
            lab5.Font = new Font("Default", 14);
            lab5.Padding = new Padding(10);
            this.Controls.Add(lab5);
            textBoxes.Add(lab5);

            return textBoxes;
        }

        private void EditRows(object sender, EventArgs e, Dictionary<int, List<TextBox>> list, Button doneBtn, Button editBtn)
        {
            foreach(KeyValuePair<int,List<TextBox>> row in list)
            {
                foreach (TextBox tb in row.Value)
                {
                    tb.Enabled = true;
                }
            }
            
            editBtn.Enabled = false;
            doneBtn.Enabled = true;
        }

        private void ApplyEdits(object sender, EventArgs e, Dictionary<int, List<TextBox>> list, ref Dictionary<int, Car> racers, Button doneBtn, Button editBtn)
        {
            foreach (KeyValuePair<int, List<TextBox>> row in list)
            {
                foreach (TextBox tb in row.Value)
                {
                    tb.Enabled = false;
                }

                racers[row.Key].Make = row.Value[0].Text;
                racers[row.Key].Model = row.Value[1].Text;
                racers[row.Key].Year = Int32.Parse(row.Value[2].Text);
                racers[row.Key].HorsePower = Int32.Parse(row.Value[3].Text);
                racers[row.Key].Weight = Int32.Parse(row.Value[4].Text);
            }

            editBtn.Enabled = true;
            doneBtn.Enabled = false;
        }
    }
}

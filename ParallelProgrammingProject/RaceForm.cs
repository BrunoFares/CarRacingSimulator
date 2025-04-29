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
        Race race;
        Dictionary<int, List<TextBox>> racerValues;
        Panel contentPanel;

        public RaceForm()
        {
            InitializeComponent();
            racerValues = new();
            race = new();
        }

        private void Race_Load(object sender, EventArgs e)
        {
            contentPanel = new();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.AutoScroll = true;
            this.Controls.Add(contentPanel);

            foreach (KeyValuePair<int, Car> car in race.Racers)
            {
                racerValues[car.Key] = LoadCar(race.Racers[car.Key], car.Key);
            }

            Panel bottomPanel = new Panel();
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Height = 50;
            this.Controls.Add(bottomPanel);

            Button EditButton = new();
            Button DoneButton = new();
            Button AddCar = new();

            EditButton = LoadButton("Edit Cars", new Point(10, 10), new Size(90, 40), true);
            bottomPanel.Controls.Add(EditButton);
            EditButton.Click += (sender, EventArgs) => EditRows(sender, EventArgs, racerValues, DoneButton, EditButton);

            DoneButton = LoadButton("Apply Edits", new Point(110, 10), new Size(120, 40), false);
            DoneButton.Click += (sender, EventArgs) => ApplyEdits(sender, EventArgs, racerValues, DoneButton, EditButton);
            bottomPanel.Controls.Add(DoneButton);

            AddCar = LoadButton("Add Car", new Point(250, 10), new Size(90, 40), true);
            AddCar.Click += (sender, EventArgs) => AddNewCar(sender, EventArgs);
            bottomPanel.Controls.Add(AddCar);
        }

        private Button LoadButton(string btnText, Point location, Size size, bool enabled)
        {
            Button NewButton = new();

            NewButton.Text = btnText;
            NewButton.Size = size;
            NewButton.Margin = new Padding(50, 0, 50, 0);
            NewButton.Enabled = enabled;
            NewButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            NewButton.Location = location;

            return NewButton;
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
            contentPanel.Controls.Add(tag);

            TextBox lab1 = new();
            lab1.Text = car.Make;
            lab1.Enabled = false;
            lab1.Location = new Point(0, 30 + index * 90);
            lab1.AutoSize = true;
            lab1.Font = new Font("Default", 14);
            lab1.Padding = new Padding(10, 10, 10, 0);
            contentPanel.Controls.Add(lab1);
            textBoxes.Add(lab1);

            TextBox lab2 = new();
            lab2.Text = car.Model;
            lab2.Enabled = false;
            lab2.Location = new Point(200, 30 + index * 90);
            lab2.AutoSize = true;
            lab2.Font = new Font("Default", 14);
            lab2.Padding = new Padding(10);
            contentPanel.Controls.Add(lab2);
            textBoxes.Add(lab2);

            TextBox lab3 = new();
            lab3.Text = car.Year.ToString();
            lab3.Enabled = false;
            lab3.Location = new Point(0, 70 + index * 90);
            lab3.AutoSize = true;
            lab3.Font = new Font("Default", 9);
            lab3.Padding = new Padding(10, 0, 10, 0);
            contentPanel.Controls.Add(lab3);
            textBoxes.Add(lab3);

            TextBox lab4 = new();
            lab4.Text = car.HorsePower.ToString();
            lab4.Enabled = false;
            lab4.Location = new Point(400, 30 + index * 90);
            lab4.AutoSize = true;
            lab4.Font = new Font("Default", 14);
            lab4.Padding = new Padding(10);
            contentPanel.Controls.Add(lab4);
            textBoxes.Add(lab4);

            TextBox lab5 = new();
            lab5.Text = car.Weight.ToString();
            lab5.Enabled = false;
            lab5.Location = new Point(600, 30 + index * 90);
            lab5.AutoSize = true;
            lab5.Font = new Font("Default", 14);
            lab5.Padding = new Padding(10);
            contentPanel.Controls.Add(lab5);
            textBoxes.Add(lab5);

            Button RemoveCarBtn = new();
            RemoveCarBtn = LoadButton("Remove Car", new Point(800, 30 + index * 90), new Size(90, 30), true);
            RemoveCarBtn.Click += (sender, EventArgs) => RemoveCar(sender, EventArgs, index);
            contentPanel.Controls.Add(RemoveCarBtn);

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

        private void ApplyEdits(object sender, EventArgs e, Dictionary<int, List<TextBox>> list, Button doneBtn, Button editBtn)
        {
            foreach (KeyValuePair<int, List<TextBox>> row in list)
            {
                foreach (TextBox tb in row.Value)
                {
                    tb.Enabled = false;
                }

                if (race.Racers.TryGetValue(row.Key, out Car car))
                {
                    car.Make = row.Value[0].Text;
                    car.Model = row.Value[1].Text;
                    car.Year = int.Parse(row.Value[2].Text);
                    car.HorsePower = int.Parse(row.Value[3].Text);
                    car.Weight = int.Parse(row.Value[4].Text);
                }
            }

            editBtn.Enabled = true;
            doneBtn.Enabled = false;
        }


        private void AddNewCar(object sender, EventArgs e)
        {
            NewCarForm newform = new();

            if (newform.ShowDialog() == DialogResult.OK)
            {
                Car car = newform.car;
                int carIndex = race.Racers.Count;
                race.Racers[carIndex] = car;
                racerValues[carIndex] = LoadCar(car, carIndex);

                RefreshCarDisplay();
            }
        }

        private void RemoveCar(object sender, EventArgs e, int index)
        {
            RemoveCarForm newform = new();

            if (newform.ShowDialog() == DialogResult.OK)
            {
                race.Racers.Remove(index);
                racerValues.Remove(index);

                Dictionary<int, Car> newRacers = new();
                Dictionary<int, List<TextBox>> newRacerValues = new();

                int newIndex = 0;
                foreach (var pair in race.Racers.OrderBy(kv => kv.Key))
                {
                    newRacers[newIndex] = pair.Value;
                    newRacerValues[newIndex] = racerValues.ContainsKey(pair.Key) ? racerValues[pair.Key] : new List<TextBox>();
                    newIndex++;
                }

                race.Racers = newRacers;
                racerValues = newRacerValues;

                contentPanel.Controls.Clear();

                foreach (KeyValuePair<int, Car> car in race.Racers)
                {
                    racerValues[car.Key] = LoadCar(car.Value, car.Key);
                }
            }
        }


        private void RefreshCarDisplay()
        {
            contentPanel.Controls.Clear();
            racerValues.Clear();

            int currentIndex = 0;

            foreach (var car in race.Racers.Values)
            {
                racerValues[currentIndex] = LoadCar(car, currentIndex);
                currentIndex++;
            }
        }

    }
}

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
    public partial class RaceForm : Form, IButtonInitialiser
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
            Button StartRaceBtn = new();

            EditButton = LoadButton("Edit Cars", new Point(10, 10), new Size(90, 40), true);
            bottomPanel.Controls.Add(EditButton);
            EditButton.Click += (sender, EventArgs) => EditRows(sender, EventArgs, racerValues, DoneButton, EditButton, AddCar);

            DoneButton = LoadButton("Apply Edits", new Point(110, 10), new Size(120, 40), false);
            DoneButton.Click += (sender, EventArgs) => ApplyEdits(sender, EventArgs, racerValues, DoneButton, EditButton, AddCar);
            bottomPanel.Controls.Add(DoneButton);

            AddCar = LoadButton("Add Car", new Point(250, 10), new Size(90, 40), true);
            AddCar.Click += (sender, EventArgs) => AddNewCar(sender, EventArgs);
            bottomPanel.Controls.Add(AddCar);

            StartRaceBtn = LoadButton("Start Race", new Point(800, 10), new Size(90, 40), true);
            StartRaceBtn.Click += (sender, EventArgs) => StartRace(sender, EventArgs);
            bottomPanel.Controls.Add(StartRaceBtn);
        }

        public Button LoadButton(string btnText, Point location, Size size, bool enabled)
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
            Label tag = new Label
            {
                Text = "Contestant " + (index + 1),
                Location = new Point(0, index * 110),
                AutoSize = true,
                Font = new Font("Default", 10, FontStyle.Bold),
                Padding = new Padding(10, 10, 10, 0)
            };
            contentPanel.Controls.Add(tag);

            Label makeLabel = new Label
            {
                Text = "Make:",
                Location = new Point(0, index * 110 + 30),
                AutoSize = true
            };
            contentPanel.Controls.Add(makeLabel);
            TextBox lab1 = new TextBox
            {
                Text = car.Make,
                Enabled = false,
                Location = new Point(60, index * 110 + 30),
                Width = 120
            };
            contentPanel.Controls.Add(lab1);
            textBoxes.Add(lab1);

            Label modelLabel = new Label
            {
                Text = "Model:",
                Location = new Point(210, index * 110 + 30),
                AutoSize = true
            };
            contentPanel.Controls.Add(modelLabel);
            TextBox lab2 = new TextBox
            {
                Text = car.Model,
                Enabled = false,
                Location = new Point(280, index * 110 + 30),
                Width = 120
            };
            contentPanel.Controls.Add(lab2);
            textBoxes.Add(lab2);

            Label yearLabel = new Label
            {
                Text = "Year:",
                Location = new Point(0, index * 110 + 60),
                AutoSize = true
            };
            contentPanel.Controls.Add(yearLabel);
            TextBox lab3 = new TextBox
            {
                Text = car.Year.ToString(),
                Enabled = false,
                Location = new Point(60, index * 110 + 60),
                Width = 60
            };
            contentPanel.Controls.Add(lab3);
            textBoxes.Add(lab3);

            Label hpLabel = new Label
            {
                Text = "HP:",
                Location = new Point(150, index * 110 + 60),
                AutoSize = true
            };
            contentPanel.Controls.Add(hpLabel);
            TextBox lab4 = new TextBox
            {
                Text = car.HorsePower.ToString(),
                Enabled = false,
                Location = new Point(190, index * 110 + 60),
                Width = 60
            };
            contentPanel.Controls.Add(lab4);
            textBoxes.Add(lab4);

            Label weightLabel = new Label
            {
                Text = "Weight:",
                Location = new Point(260, index * 110 + 60),
                AutoSize = true
            };
            contentPanel.Controls.Add(weightLabel);
            TextBox lab5 = new TextBox
            {
                Text = car.Weight.ToString(),
                Enabled = false,
                Location = new Point(330, index * 110 + 60),
                Width = 60
            };
            contentPanel.Controls.Add(lab5);
            textBoxes.Add(lab5);

            Label speedLabel = new Label
            {
                Text = $"Speed: {car.Speed:F2}",
                Location = new Point(400, index * 110 + 30),
                AutoSize = true,
                Font = new Font("Default", 10, FontStyle.Bold)
            };
            contentPanel.Controls.Add(speedLabel);

            Button RemoveCarBtn = new Button
            {
                Text = "Remove Car",
                Location = new Point(500, index * 110 + 55),
                Size = new Size(90, 30)
            };
            RemoveCarBtn.Click += (sender, e) => RemoveCar(sender, e, index);
            contentPanel.Controls.Add(RemoveCarBtn);

            return textBoxes;
        }

        private void EditRows(object sender, EventArgs e, Dictionary<int, List<TextBox>> list, Button doneBtn, Button editBtn, Button addBtn)
        {
            foreach(KeyValuePair<int,List<TextBox>> row in list)
            {
                foreach (TextBox tb in row.Value)
                {
                    tb.Enabled = true;
                }
            }
            
            editBtn.Enabled = false;
            addBtn.Enabled = false;
            doneBtn.Enabled = true;
        }

        private void ApplyEdits(object sender, EventArgs e, Dictionary<int, List<TextBox>> list, Button doneBtn, Button editBtn, Button addBtn)
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

            RefreshCarDisplay();

            editBtn.Enabled = true;
            addBtn.Enabled = true;
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

        private void StartRace(object sender, EventArgs e)
        {
            NewRaceForm newform = new(race);
            newform.Show();
        }
    }
}

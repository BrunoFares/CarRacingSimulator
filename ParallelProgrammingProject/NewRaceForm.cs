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
    public partial class NewRaceForm : Form, IButtonInitialiser
    {
        Panel contentPanel;
        Race race;
        private Dictionary<Car, ProgressBar> carProgressBars = new();

        public NewRaceForm(Race race)
        {
            InitializeComponent();
            this.race = race;
        }

        private void NewRaceForm_Load(object sender, EventArgs e)
        {
            Panel bottomPanel = new Panel();
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Height = 50;
            this.Controls.Add(bottomPanel);

            Button PitstopBtn = new();
            Button StartRaceBtn = new();

            PitstopBtn = LoadButton("Edit Cars", new Point(10, 10), new Size(90, 40), true);
            bottomPanel.Controls.Add(PitstopBtn);
            PitstopBtn.Click += (sender, EventArgs) => PitStop(sender, EventArgs);

            StartRaceBtn = LoadButton("Edit Cars", new Point(100, 10), new Size(90, 40), true);
            bottomPanel.Controls.Add(StartRaceBtn);
            StartRaceBtn.Click += (sender, EventArgs) => StartRace();

            contentPanel = new FlowLayoutPanel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.AutoScroll = true;
            this.Controls.Add(contentPanel);

            foreach (Car car in race.Racers.Values)
            {
                Label carLabel = new Label();
                carLabel.Text = $"{car.Make} {car.Model} ({car.Year})";
                carLabel.AutoSize = true;

                ProgressBar pb = new ProgressBar();
                pb.Width = 300;
                pb.Minimum = 0;
                pb.Maximum = 100;
                pb.Value = 0;

                carProgressBars[car] = pb;

                Panel carPanel = new Panel();
                carPanel.Width = 320;
                carPanel.Height = 50;
                carPanel.Controls.Add(carLabel);
                carLabel.Location = new Point(0, 0);
                carPanel.Controls.Add(pb);
                pb.Location = new Point(0, 20);

                contentPanel.Controls.Add(carPanel);
            }
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

        void PitStop(object sender, EventArgs e) { }

        private void StartRace()
        {
            int raceLength = 100;
            List<Thread> threads = new();

            foreach (var car in race.Racers.Values)
            {
                Thread t = new Thread(() =>
                {
                    car.RunRace(raceLength, () =>
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            if (carProgressBars.TryGetValue(car, out ProgressBar pb))
                            {
                                pb.Value = Math.Min(car.Progress, pb.Maximum);
                            }
                        }));
                    });
                });

                t.IsBackground = true;
                threads.Add(t);
                t.Start();
            }
        }
    }
}

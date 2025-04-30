using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ParallelProgrammingProject
{
    public partial class NewRaceForm : Form
    {
        private readonly Race race;
        private readonly Dictionary<Car, (ProgressBar Bar, Panel Panel, Label SpeedLabel)> carUis = new();
        private const int DefaultHpChange = 10;
        private const int DefaultWeightChange = 50;

        public NewRaceForm(Race race)
        {
            InitializeComponent();
            this.race = race;
        }

        private void NewRaceForm_Load(object sender, EventArgs e)
        {
            var contentPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10)
            };
            Controls.Add(contentPanel);

            foreach (var car in race.Racers.Values)
            {
                var panel = new Panel
                {
                    Width = 500,
                    Height = 80,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5)
                };

                var lbl = new Label
                {
                    Text = $"{car.Make} {car.Model} ({car.Year})",
                    Location = new Point(5, 5),
                    AutoSize = true
                };

                var speedLbl = new Label
                {
                    Text = $"Speed: {car.Speed:F2}",
                    Location = new Point(5, 25),
                    AutoSize = true
                };

                var pb = new ProgressBar
                {
                    Width = 200,
                    Height = 20,
                    Location = new Point(5, 45),
                    Maximum = 100
                };

                var btnFaster = new Button
                {
                    Text = "Faster (+10HP/-50kg)",
                    Size = new Size(120, 30),
                    Location = new Point(210, 45),
                    Tag = car,
                    BackColor = Color.LightGreen
                };
                btnFaster.Click += MakeCarFaster;

                var btnSlower = new Button
                {
                    Text = "Slower (-10HP/+50kg)",
                    Size = new Size(120, 30),
                    Location = new Point(340, 45),
                    Tag = car,
                    BackColor = Color.LightCoral
                };
                btnSlower.Click += MakeCarSlower;

                panel.Controls.AddRange(new Control[] { lbl, speedLbl, pb, btnFaster, btnSlower });
                contentPanel.Controls.Add(panel);
                carUis[car] = (pb, panel, speedLbl);
            }

            var btnStart = new Button
            {
                Text = "Start Race",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            btnStart.Click += StartRace;
            Controls.Add(btnStart);

            var btnRestart = new Button
            {
                Text = "Restart Race",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            btnRestart.Click += RestartRace;
            Controls.Add(btnRestart);
        }

        private void MakeCarFaster(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var car = (Car)btn.Tag;

            car.EnterPitStop(DefaultHpChange, -DefaultWeightChange);
            UpdateCarDisplay(car);
            Task.Delay(2000).ContinueWith(_ =>
            {
                car.ExitPitStop();
                this.Invoke((MethodInvoker)(() => UpdateCarDisplay(car)));
            });
        }

        private void MakeCarSlower(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var car = (Car)btn.Tag;

            car.EnterPitStop(-DefaultHpChange, DefaultWeightChange);
            UpdateCarDisplay(car);
            Task.Delay(2000).ContinueWith(_ =>
            {
                car.ExitPitStop();
                this.Invoke((MethodInvoker)(() => UpdateCarDisplay(car)));
            });
        }

        private void UpdateCarDisplay(Car car)
        {
            if (carUis.TryGetValue(car, out var ui))
            {
                ui.Panel.BackColor = car.InPitStop ? Color.LightYellow : SystemColors.Control;
                ui.SpeedLabel.Text = $"Speed: {car.Speed:F2} (HP: {car.HorsePower}, Weight: {car.Weight})";
                ui.Bar.Value = Math.Min(car.Progress, ui.Bar.Maximum);
            }
        }

        private void StartRace(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            int raceLength = 100;

            foreach (var car in race.Racers.Values)
            {
                new Thread(() =>
                {
                    car.RunRace(raceLength, () =>
                    {
                        this.Invoke((MethodInvoker)(() => UpdateCarDisplay(car)));
                    });
                })
                { IsBackground = true }.Start();
            }
        }

        private void RestartRace(object sender, EventArgs e)
        {
            race.ResetRace();

            RaceForm raceForm = new(race);
            raceForm.Show();

            this.Hide();
        }
    }
}
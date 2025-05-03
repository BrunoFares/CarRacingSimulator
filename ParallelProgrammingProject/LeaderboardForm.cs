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
    public partial class LeaderboardForm : Form
    {
        private readonly ListView leaderboardList;

        public LeaderboardForm()
        {
            InitializeComponent();
        }

        public LeaderboardForm(List<Car> leaderboard)
        {
            Text = "🏁 Race Leaderboard";
            Size = new Size(720, 450);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            Label title = new Label
            {
                Text = "Final Race Results",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 50,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(title);

            leaderboardList = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Segoe UI", 10),
            };

            leaderboardList.Columns.Add("Position", 80);
            leaderboardList.Columns.Add("Make", 100);
            leaderboardList.Columns.Add("Model", 100);
            leaderboardList.Columns.Add("Year", 80);
            leaderboardList.Columns.Add("Horsepower", 100);
            leaderboardList.Columns.Add("Weight (kg)", 100);
            leaderboardList.Columns.Add("Speed (km/h)", 120);

            int position = 1;
            foreach (var car in leaderboard)
            {
                ListViewItem item = new ListViewItem(position.ToString());
                item.SubItems.Add(car.Make);
                item.SubItems.Add(car.Model);
                item.SubItems.Add(car.Year.ToString());
                item.SubItems.Add(car.HorsePower.ToString());
                item.SubItems.Add(car.Weight.ToString());
                item.SubItems.Add($"{car.Speed:F2}");

                leaderboardList.Items.Add(item);
                position++;
            }

            Controls.Add(leaderboardList);

            Button closeBtn = new Button
            {
                Text = "Close",
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.LightGray
            };
            closeBtn.Click += (s, e) => Close();
            Controls.Add(closeBtn);
        }
    }
}

namespace ParallelProgrammingProject
{
    public partial class Form1 : Form
    {
        private Race race;

        public Form1()
        {
            InitializeComponent();
            race = new Race();
        }

        private void StartRace_Click(object sender, EventArgs e)
        {
            RaceForm raceForm = new(race);
            raceForm.Show();
            this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (Application.MessageLoop) 
                Application.Exit();
            else
                Environment.Exit(1);
        }
    }
}
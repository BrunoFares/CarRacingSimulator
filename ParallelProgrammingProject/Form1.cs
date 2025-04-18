namespace ParallelProgrammingProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartRace_Click(object sender, EventArgs e)
        {
            RaceForm race = new();
            race.Show();
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